using Application.Interfaces.Services;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Template.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AskController : ControllerBase
    {
        private readonly IAskService _askService;

        public AskController(IAskService askService)
        {
            _askService = askService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Ask>> GetAsks()
        {
            return await _askService.GetAllAsks();
        }

        [HttpGet("GetById/{id}")]
        public async Task<Ask> GetAsk(int id)
        {
            return await _askService.GetAsk(id);
        }

        /*
        [HttpPost("create")]
        [ProducesResponseType(typeof(AskResponse), 201)]
        public async Task<IActionResult> CreateAsk([FromBody] AskRequest request)
        {
            try
            {
                var result = await _askService.CreateAsk(request);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        */
        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(AskResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAsk(int id, [FromBody] AskRequest request)
        {
            try
            {
                var updatedAsk = await _askService.UpdateAsk(id, request);
                return Ok(updatedAsk);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
