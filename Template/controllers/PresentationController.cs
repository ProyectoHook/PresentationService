using Microsoft.AspNetCore.Mvc;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Application.Interfaces.Services;
using Application.UseCase;
using Microsoft.AspNetCore.Http.HttpResults;

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
        [ProducesResponseType(typeof(List<PresentationResponse>),200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPresentations()
        {
            try
            {
                var response = await _presentationService.GetAllPresentations();
                                
                return StatusCode(200, response); // 200 con el objeto
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(PresentationResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPresentation(int id)
        {
            try
            {
                var response = await _presentationService.GetPresentation(id);

                if (response == null)
                    return NotFound(); // 404 si no se encuentra

                return StatusCode(200, response); // 200 con el objeto
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message }); 
            }
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


        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(Ok), 200)]
        public async Task<IActionResult> CreatePresentation(int id)
        {
            try
            {
                await _presentationService.delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(PresentationResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdatePresentation(int id, [FromBody] UpdatePresentationRequest request)
        {
            try
            {
                var updatedPresentation = await _presentationService.UpdatePresentation(id,request);
                return Ok(updatedPresentation);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetUserPresentations/{userId}")]
        [ProducesResponseType(typeof(List<PresentationResponse>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPresentationsByUser(Guid userId)
        {
            try
            {
                var response = await _presentationService.GetPresentationsByUserId(userId);

                return StatusCode(200, response); // 200 con el objeto
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}