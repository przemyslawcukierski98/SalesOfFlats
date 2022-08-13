using Application.Dto;
using Application.Interfaces;
using Application.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Filters;
using WebApp.Helpers;
using WebApp.Wrappers;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        private readonly IFlatService _flatService;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger _logger;

        public FlatsController(IFlatService flatService, IMemoryCache memoryCache,
            ILogger<FlatsController> logger)
        {
            _flatService = flatService;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        [SwaggerOperation(Summary = "Retrieves all flats with filter")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter,
            [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            var flats = await _flatService.GetAllFlatsAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
                validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
            var totalRecords = await _flatService.GetAllFlatsCountAsync(filterBy);

            if(totalRecords == 0)
            {
                return NotFound(new Response<bool> { Succeded = false, Message = "No flats found" });
            }

            return Ok(PaginationHelper.CreatePagedResponse(flats, paginationFilter, totalRecords));
        }

        [SwaggerOperation(Summary = "Retrieves all flats")]
        [HttpGet("[action]")]
        public IQueryable<FlatDto> GetAll()
        {
            var flats = _memoryCache.Get<IQueryable<FlatDto>>("flats");

            if(flats == null)
            {
                _logger.LogInformation("Fetching from service");
                flats = _flatService.GetAllFlatsAsync();
                _memoryCache.Set("flats", flats, TimeSpan.FromMinutes(1));
            }
            else
            {
                _logger.LogInformation("Fetching from cache");
            }

            return flats;
        }

        [SwaggerOperation(Summary = "Retrieve flat by ID")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var flat = await _flatService.GetFlatByIdAsync(id);
            if (flat == null)
            {
                return NotFound(new Response<bool> { Succeded = false, Message = "This flat is not found" });
            }

            return Ok(new Response<FlatDto>(flat));
        }

        [SwaggerOperation(Summary = "Create a new flat")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateFlatDto flat)
        {
            var validator = new CreateFlatDtoValidator();
            var result = validator.Validate(flat);

            if(!result.IsValid)
            {
                return BadRequest(new Response<bool>
                {
                    Succeded = false,
                    Message = "Something went wrong.",
                    Errors = result.Errors.Select(x => x.ErrorMessage)
                });
            }
            else
            {
                var newFlat = await _flatService.AddNewFlatAsync(flat);
                return Created($"api/flats/{newFlat.Id}", new Response<FlatDto>(newFlat));
            }
        }

        [SwaggerOperation(Summary = "Update an existing flat")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFlatDto flat)
        {
            if(string.IsNullOrEmpty(flat.Description))
            {
                return BadRequest(new Response(false, "Description is empty"));
            }
            else if (flat.Area <= 0)
            {
                return BadRequest(new Response(false, "Area must be greater than zero"));
            }
            else if (flat.Floor <= 0)
            {
                return BadRequest(new Response(false, "Floor must be greater than zero"));
            }
            else if (flat.Price <= 0)
            {
                return BadRequest(new Response(false, "Price must be greater than zero"));
            }
            else if (flat.NumberOfRooms <= 0)
            {
                return BadRequest(new Response(false, "Number of rooms must be greater than zero"));
            }
            else
            {
                await _flatService.UpdateFlatAsync(flat);
                return NoContent();
            }
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
