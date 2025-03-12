using FinanceAPI.Application.Employee.Commands.CreateEmployee;
using FinanceAPI.Application.Employee.Commands.UpdateEmployee;
using FinanceAPI.Application.Employee.DTOs;
using FinanceAPI.Application.Employee.Queries.GetEmployeeById;
using FinanceAPI.Application.Employee.Queries.GetEmployees;
using MediatR;

namespace FinanceAPI.Endpoints;

public static class EmployeeEndpoints
{
    public static WebApplication MapEmployeeEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/employees")
            .WithTags("Employees")
            .WithOpenApi();

        root.MapGet("/GetEmployees/", GetEmployees)
            .Produces<List<EmployeeResponseDto>>()
            .WithName("Get All Employees")
            .WithSummary("Lookup all Employees registered in the system");

        root.MapGet("/GetEmployeeById/{id}", GetEmployeeById)
            .Produces<EmployeeResponseDto>()
            .WithName("Get Employee by Id")
            .WithSummary("Lookup an Employee by their Id");

        root.MapPost("/CreateEmployee/", CreateEmployee)
            .Produces<EmployeeResponseDto>(StatusCodes.Status201Created)
            .WithName("Create Employee")
            .WithSummary("Create an Employee");

        root.MapPost("/UpdateEmployee/", UpdateEmployee)
            .Produces<EmployeeResponseDto>(StatusCodes.Status200OK)
            .WithName("Update Employee")
            .WithSummary("Update an Employee");

        return app;
    }

    public static async Task<IResult> GetEmployees(IMediator mediator)
    {
        var employees = await mediator.Send(new GetEmployeesQuery());
        return Results.Ok(employees);
    }

    public static async Task<IResult> GetEmployeeById(IMediator mediator, int id)
    {
        var employee = await mediator.Send(new GetEmployeeByIdQuery(id));
        return Results.Ok(employee);
    }

    public static async Task<IResult> CreateEmployee(IMediator mediator, CreateEmployeeCommand command)
    {
        var newEmployee = await mediator.Send(command);
        return Results.Created($"/employees/{newEmployee.Id}", newEmployee);
    }

    public static async Task<IResult> UpdateEmployee(IMediator mediator, int Id, UpdateEmployeeCommand command)
    {
        var updateEmployee = await mediator.Send(CreateUpdateCommand(Id, command));
        return Results.Ok(updateEmployee);
    }

    private static UpdateEmployeeCommand CreateUpdateCommand(int Id, UpdateEmployeeCommand command) =>
        new(Id, command.FirstName, command.LastName, command.DateOfBirth, command.Email, command.DateJoined, command.DepartmentId, command.PostTitleId);
}
