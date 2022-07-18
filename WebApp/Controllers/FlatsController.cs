using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Get()
        {
            var flats = _flatService.GetAllFlats();
            return Ok(flats);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var flat = _flatService.GetFlatById(id);
            if(flat == null)
            {
                return NotFound();
            }

            return Ok(flat);
        }


    }
}
