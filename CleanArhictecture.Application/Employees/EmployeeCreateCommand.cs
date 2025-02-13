using CleanArhictecture.Domain.Employees;
using FluentValidation;
using GenericRepository;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace CleanArhictecture.Application.Employees
{
    public sealed record EmployeeCreateCommand(
        string FirstName,
        string LastName,
        DateOnly BirthOfDate,
        decimal Salary,
        PersonelInformation PersonelInformation,
        Address? address):IRequest<Result<string>>;


    public sealed class EmployeeCreateCommandValidator : AbstractValidator<EmployeeCreateCommand>
    {
        public EmployeeCreateCommandValidator()
        {
            RuleFor(x => x.FirstName).MinimumLength(3).WithMessage("Ad alanı en az 3 karakter olmalı.");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Soyad alanı en az 3 karakter olmalı.");
            RuleFor(x => x.PersonelInformation.TcNo)
                .MinimumLength(11).WithMessage("Geçerli bir TC kimlik numarası giriniz.")
                .MaximumLength(11).WithMessage("Geçerli bir TC kimlik numarası giriniz.");
        }
    }

    internal sealed class EmplloyeeCreateCommandHandler(
        IEmployeeRepository employeeRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<EmployeeCreateCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            var isEmployeeExists = await employeeRepository.AnyAsync(p => p.PersonelInformation.TcNo == request.PersonelInformation.TcNo, cancellationToken);
            if (isEmployeeExists)
            {
                return Result<string>.Failure("Bu Tc numarası dahaönce kaydedilmiş.");
            }

            Employee employee = request.Adapt<Employee>();
            employeeRepository.Add(employee);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Personel kaydı başarılı bir şeklde yapılmıştır";
        }
    }
}
