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
            
            if(flat == null)
            {
                return BadRequest(new Response(false, $"Flat with id {flatId} doesn't exist"));
            }

            var picture = await _pictureService.AddPictureToPostAsync(flatId, formFile);
            return Created($"api/pictures/{picture.Id}", new Response<PictureDto>(picture));
        }
    }
}
