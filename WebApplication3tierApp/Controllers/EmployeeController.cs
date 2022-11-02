using _2DataAccessLayer.Services;
using _3BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3tierApp.Models;

namespace WebApplication3tierApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EmployeeController : BaseController
    {

        private readonly IEmployeeService _EmployeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService EmployeeService, ILogger<EmployeeController> logger)
        {
            _EmployeeService = EmployeeService;
            _logger = logger;
        }

        [HttpGet("", Name = "GetAllEmployees")]
        public async Task<List<EmployeeDto>> GetAll()
        {
            var result = await _EmployeeService.GetAll();
            return result.Select(x => x.ToEmployeeDto()).ToList();
        }

        [HttpGet("{EmployeeId}", Name = "GetEmployee")]
        public async Task<EmployeeDto?> Get(int EmployeeId)
        {
            var result = await _EmployeeService.GetById(EmployeeId);
            return result?.ToEmployeeDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] EmployeeDto requestDto)
        {
            var EmployeeModel = requestDto.ToEmployeeModel();
            return await _EmployeeService.CreateEmployee(EmployeeModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] EmployeeDto requestDto)
        {
            await _EmployeeService.UpdateEmployee(requestDto.ToEmployeeModel());
            return Ok();
        }

        [HttpDelete, Route("{EmployeeId}")]
        public async Task<IActionResult> Delete(int EmployeeId)
        {
            await _EmployeeService.DeleteEmployee(EmployeeId);
            return Ok();
        }
    }
}
