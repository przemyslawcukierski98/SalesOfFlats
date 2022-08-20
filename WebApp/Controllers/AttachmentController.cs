using Application.Dto.Attachments;
using Application.Interfaces;
using Microsoft.AspNetCore.Components;
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
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;
        private readonly IFlatService _flatService;

        public AttachmentController(IAttachmentService attachmentService,
            IFlatService flatService)
        {
            _attachmentService = attachmentService;
            _flatService = flatService;
        }

        [SwaggerOperation(Summary = "Retrieves a attachments by unique flat id")]
        [HttpGet("[action]/{flatId}")]
        public async Task<IActionResult> GetByFlatId(int flatId)
        {
            var attachments = await _attachmentService.GetAttachmentsByFlatIdAsync(flatId);
            return Ok(new Response<IEnumerable<AttachmentDto>>(attachments));
        }

        [SwaggerOperation(Summary = "Download a specific attachment by unique id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var attachment = await _attachmentService.DownloadAttachmentByIdAsync(id);
            if(attachment == null)
            {
                return NotFound();
            }
            return File(attachment.Content, System.Net.Mime.MediaTypeNames.Application.Octet, attachment.Name);
        }

        [SwaggerOperation(Summary = "Add a new attachment to flat")]
        [HttpPost("{flatId}")]
        public async Task<IActionResult> AddToFlat(int flatId, IFormFile file)
        {
            var flat = await _flatService.GetFlatByIdAsync(flatId);
            if(flat == null)
            {
                return BadRequest(new Response(false, $"Flat with id {flatId} does not exist."));
            }

            var attachment = await _attachmentService.AddAttachmentToFlatAsync(flatId, file);
            return Created($"api/attachments/{attachment.Id}", new Response<AttachmentDto>(attachment));
        }
    }
}
