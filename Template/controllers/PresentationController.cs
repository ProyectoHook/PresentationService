using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.UseCase;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Application.Interfaces.Services;

namespace Template.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class PresentationController : ControllerBase
    {
        private readonly IPresentationService _presentationService;

        public PresentationController(IPresentationService presentationService)
        {
            _presentationService = presentationService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Presentation>> GetPresentations()
        {
            return await _presentationService.GetAllPresentations();
        }

        [HttpGet("GetById/{id}")]
        public async Task<PresentationResponse> GetPresentation(int id)
        {
            return await _presentationService.GetPresentation(id);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(PresentationResponse), 201)]
        public async Task<IActionResult> CreatePresentation(PresentationRequest request)
        {
            try
            {
                var result = await _presentationService.CreatePresentation(request);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(PresentationResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdatePresentation(int id, [FromBody] PresentationRequest request)
        {
            try
            {
                var updatedPresentation = await _presentationService.UpdatePresentation(id, request);
                return Ok(updatedPresentation);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}