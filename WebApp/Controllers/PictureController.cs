using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Wrappers;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private static IPictureService _pictureService;
        private static IFlatService _flatService;

        public PictureController(IPictureService pictureService, IFlatService flatService)
        {
            _pictureService = pictureService;
            _flatService = flatService;
        }

        [SwaggerOperation(Summary = "Add a picture to advertisement")]
        [HttpPost("{flatId}")]
        public async Task<IActionResult> AddPictureToAd(int flatId, IFormFile formFile)
        {
            var flat = await _flatService.GetFlatByIdAsync(flatId);

            if (flat == null)
            {
                return BadRequest(new Response(false, $"Flat with id {flatId} doesn't exist"));
            }

            var picture = await _pictureService.AddPictureToFlatAsync(flatId, formFile);
            return Created($"api/pictures/{picture.Id}", new Response<PictureDto>(picture));
        }

        [SwaggerOperation(Summary = "Retrieve a pictures by flat id")]
        [HttpGet("{action}/{flatId}")]
        public async Task<IActionResult> GetByFlatId(int flatId)
        {
            var pictures = await _pictureService.GetPicturesByFlatIdAsync(flatId);
            return Ok(new Response<IEnumerable<PictureDto>>(pictures));
        }

        [SwaggerOperation(Summary = "Retrieves a specific picture by ID")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var picture = await _pictureService.GetPictureByIdAsync(id);
            if(picture == null)
            {
                return NotFound();
            }
            return Ok(new Response<PictureDto>(picture));
        }

        [SwaggerOperation(Summary = "Delete a specific picture by ID")]
        [HttpDelete("{flatId}/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pictureService.DeletePictureAsync(id);
            return NoContent();
        }
    }
}
