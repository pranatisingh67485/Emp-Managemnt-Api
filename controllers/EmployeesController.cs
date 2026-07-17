using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private static readonly List<Employee> Employees =
    [
        new Employee
        {
            Id = 1,
            Name = "John",
            Department = "IT"
        },
        new Employee
        {
            Id = 2,
            Name = "Alice",
            Department = "HR"
        }
    ];

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Employees);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var employee = Employees.FirstOrDefault(x => x.Id == id);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Add(Employee employee)
    {
        employee.Id = Employees.Max(x => x.Id) + 1;

        Employees.Add(employee);

        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
    }
}
