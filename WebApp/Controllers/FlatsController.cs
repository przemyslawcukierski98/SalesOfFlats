using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        private readonly IFlatService _flatService;

        public FlatsController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        [SwaggerOperation(Summary = "Retrieves all flats")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var flats = await _flatService.GetAllFlatsAsync();
            return Ok(flats);
        }

        [SwaggerOperation(Summary = "Retrieve flat by ID")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var flat = await _flatService.GetFlatByIdAsync(id);
            if (flat == null)
            {
                return NotFound();
            }

            return Ok(flat);
        }

        [SwaggerOperation(Summary = "Create a new flat")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateFlatDto flat)
        {
            var newFlat = await _flatService.AddNewFlatAsync(flat);

            return Created($"api/flats/{newFlat.Id}", newFlat); ;
        }

        [SwaggerOperation(Summary = "Update an existing flat")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFlatDto flat)
        {
            await _flatService.UpdateFlatAsync(flat);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete an existing flat")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _flatService.DeleteFlatAsync(id);
            return NoContent();
        }
    }
}
