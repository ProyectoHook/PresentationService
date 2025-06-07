using Application.Interfaces.Services;
using Application.Request;
using Application.UseCase;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class SlideController:ControllerBase
    {
        private readonly ISlideService _service;

        public SlideController(ISlideService slideService)
        {
            _service = slideService;
        }


        [HttpGet("GetById/{slideId}")]
        public async Task<IActionResult> GetSlideId(int slideId)
        {
            {
                try
                {
                    var result = await _service.GetSlideId(slideId);
                    return new JsonResult(result) { StatusCode = 200 };

                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
        }

        [HttpDelete("delete/{slideId}")]
        public IActionResult DeleteSlide(int slideId)
        {
            try
            {
                _service.DeleteSlide(slideId);
                return Ok() ;

            }
            catch (Exception ex)
            {
                return new JsonResult(500, "internal server error");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(SlideRequest request)
        {
            try
            {
                var result = await _service.CreateAsync(request);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (Exception ex)
            { 
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("update/{slideId}")]
        public async Task<IActionResult> UpdateSlide(int slideId, SlideRequest request)
        {
            try
            {
                var result = await _service.UpdateSlide(slideId, request);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
