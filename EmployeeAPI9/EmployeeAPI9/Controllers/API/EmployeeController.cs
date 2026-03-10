using AutoMapper;
using EmployeeAPI9.Domain.EntitiesDB;
using EmployeeAPI9.Services.Interfaces;
using EmployeeAPI9.Domain.EntitiesDB;
using EmployeeAPI9.Services.Interfaces;
using EmployeeAPI9.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeAPI9.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService<Employee> _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IService<Employee> employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the list of all Employees.
        /// </summary>
        /// <returns>The list of Employees.</returns>
        // GET: api/Employee
        [HttpGet, Authorize]

        public async Task<ActionResult<EmployeeVM>> Get()
        {
            try
            {
                //ophalen Employees
                // mapping
                var employees = await _employeeService.GetAllAsync();
                List<EmployeeVM> data = _mapper.Map<List<EmployeeVM>>(employees);
                if (data == null)
                {// Als de gegevens niet worden gevonden, retourneer een 404 Not Found-status
                    return NotFound();
                }
                // Retourneer de gegevens als alles goed is verlopen
                // HTTP-statuscode 200
                return Ok(data);
            }
            catch (Exception ex)
            {
                // Als er een fout optreedt, retourneer een 500 Internal Server Error-status
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get the list of all Employees.
        /// </summary>
        /// <returns>The list of Employees.</returns>
        // GET: api/Employee
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeVM>> Get(int id)
        {
            try
            {
                // ophalen Employee o.b.v. id
                Employee? data = await _employeeService.FindByIdAsync(id);
                // mapping
                EmployeeVM? dataVM = _mapper.Map<EmployeeVM>(data);
                if (dataVM == null)
                {
                    return NotFound(new { message = "No employee data found." });
                }
                // Retourneer data
                return Ok(dataVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Creates an Employee.
        /// </summary>
        /// <remarks>
        /// Sample request
        /// POST api/Employee
        /// {
        /// "firstName": "Karel",
        /// "lastName": "Vermeulen",
        /// "emailId": "Karel.Vermeulen@gmail.com"
        /// }
        /// </remarks>
        // POST: api/Employee
        [HttpPost]
        // [Produces("application/json")]
        // [FromForm] - Gets values from posted form fields. -> Dit verwijderen als je via postman wilt werken

        public async Task<ActionResult<EmployeeVM>> Post([FromForm] EmployeePostVM employeePostVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee employee = _mapper.Map<Employee>(employeePostVM);
                    // Logic to create new Employee
                    await _employeeService.AddAsync(employee);
                    return CreatedAtAction(nameof(Get), new { id = employee.EmployeeId },
                   employee);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            { return BadRequest(); }
        }
    }
}
