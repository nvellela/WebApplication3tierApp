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
    public class PersonController : ControllerBase   
    {

        private readonly IPersonService _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet("", Name = "GetAll")]
        public async Task<List<PersonDto>> GetAll()
        {
            var result = await _personService.GetAll();
            return result.Select(x => x.ToPersonDto()).ToList();
        }

        [HttpGet("{personId}", Name = "GetPerson")]
        public async Task<PersonDto?> Get(int personId)
        {
            var result = await _personService.GetById(personId);
            return result?.ToPersonDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] PersonDto requestDto)
        {
            var personModel = requestDto.ToPersonModel();
            return await _personService.CreatePerson(personModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] PersonDto requestDto)
        {
            await _personService.UpdatePerson(requestDto.ToPersonModel());
            return Ok();
        }

        [HttpDelete, Route("{personId}")]
        public async Task<IActionResult> Delete(int personId)
        {
            await _personService.DeletePerson(personId);
            return Ok();
        }
    }
}
