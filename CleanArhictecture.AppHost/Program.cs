var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CleanArhictecture_WebAPI>("cleanarhictecture-webapi");

builder.Build().Run();
