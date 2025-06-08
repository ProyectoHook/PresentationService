using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Interfaces.Services;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Template.controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _optionService;

        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Option>> GetOptions()
        {
            return await _optionService.GetAllOptions();
        }

        [HttpGet("GetById/{id}")]
        public async Task<Option> GetOption(int id)
        {
            return await _optionService.GetOption(id);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(OptionResponse), 201)]
        public async Task<IActionResult> CreateOption([FromBody] OptionRequest request)
        {
            try
            {
                var result = await _optionService.CreateOption(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(OptionResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateOption(int id, [FromBody] OptionRequest request)
        {
            try
            {
                var updatedOption = await _optionService.UpdateOption(id, request);
                return Ok(updatedOption);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
