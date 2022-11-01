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
    public class StudentController : BaseController
    {

        private readonly IStudentService _StudentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService StudentService, ILogger<StudentController> logger)
        {
            _StudentService = StudentService;
            _logger = logger;
        }

        [HttpGet("", Name = "GetAllStudents")]
        public async Task<List<StudentDto>> GetAll()
        {
            var result = await _StudentService.GetAll();
            return result.Select(x => x.ToStudentDto()).ToList();
        }

        [HttpGet("{StudentId}", Name = "GetStudent")]
        public async Task<StudentDto?> Get(int StudentId)
        {
            var result = await _StudentService.GetById(StudentId);
            return result?.ToStudentDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] StudentDto requestDto)
        {
            var StudentModel = requestDto.ToStudentModel();
            return await _StudentService.CreateStudent(StudentModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] StudentDto requestDto)
        {
            await _StudentService.UpdateStudent(requestDto.ToStudentModel());
            return Ok();
        }

        [HttpDelete, Route("{StudentId}")]
        public async Task<IActionResult> Delete(int StudentId)
        {
            await _StudentService.DeleteStudent(StudentId);
            return Ok();
        }
    }
}
