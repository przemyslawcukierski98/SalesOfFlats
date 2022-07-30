﻿using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public FlatsController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        [SwaggerOperation(Summary = "Retrieves all flats")]
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
            var newFlat = await _flatService.AddNewFlatAsync(flat);

            if(string.IsNullOrEmpty(newFlat.Title))
            {
                return BadRequest(new Response(false, "Title is empty"));
            }
            else if(string.IsNullOrEmpty(newFlat.Description))
            {
                return BadRequest(new Response(false, "Description is empty"));
            }
            else
            {
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
