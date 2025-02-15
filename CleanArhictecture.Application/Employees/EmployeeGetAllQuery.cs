using CleanArhictecture.Domain.Abstractions;
using CleanArhictecture.Domain.Employees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArhictecture.Application.Employees;

public sealed record EmployeeGetAllQuery():IRequest<IQueryable<EmployeeGetAllQueryResponse>>;

public sealed class EmployeeGetAllQueryResponse : EntityDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly BirthfDate { get; set; }
    public decimal Salary { get; set; }
    public string TcNo { get; set; } = default!;
}

internal sealed class EmployeeGetAllQueryHandler(
    IEmployeeRepository employeeRepository) : IRequestHandler<EmployeeGetAllQuery,
    IQueryable<EmployeeGetAllQueryResponse>>{
    public Task<IQueryable<EmployeeGetAllQueryResponse>> Handle(EmployeeGetAllQuery request, CancellationToken cancellationToken)
    {
        var response = employeeRepository.GetAll().Select(x => new EmployeeGetAllQueryResponse
        {
            FirstName = x.FirstName,
            LastName = x.LastName,
            BirthfDate = x.BirthfDate,
            Salary = x.Salary,
            CreateAt = x.CreateAt,
            DeleteAt = x.DeleteAt,
            Id = x.Id,
            IsDeleted = x.IsDeleted,
            TcNo = x.PersonelInformation.TcNo,
            UpdateAt = x.UpdateAt,
        }).AsQueryable();

        return Task.FromResult(response);
    }
}