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
        public IActionResult Get()
        {
            var flats = _flatService.GetAllFlats();
            return Ok(flats);
        }

        [SwaggerOperation(Summary = "Retrieve flat by ID")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var flat = _flatService.GetFlatById(id);
            if (flat == null)
            {
                return NotFound();
            }

            return Ok(flat);
        }

        [SwaggerOperation(Summary = "Create a new flat")]
        [HttpPost]
        public IActionResult Create(CreateFlatDto flat)
        {
            var newFlat = _flatService.AddNewFlat(flat);

            return Created($"api/flats/{newFlat.Id}", newFlat); ;
        }

        [SwaggerOperation(Summary = "Update an existing flat")]
        [HttpPut]
        public IActionResult Update(UpdateFlatDto flat)
        {
            _flatService.UpdateFlat(flat);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete an existing flat")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _flatService.DeleteFlat(id);
            return NoContent();
        }
    }
}
