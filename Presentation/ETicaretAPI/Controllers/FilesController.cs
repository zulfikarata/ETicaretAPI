using ETicaretAPI.Application.Consts;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.Enums;
using ETicaretAPI.Application.Features.Commands.File.UploadFile;
using ETicaretAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        readonly IConfiguration _configuration;
        readonly IMediator _mediator;

        public FilesController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public IActionResult GetBaseUrl()
        {
            return Ok(new
            {
                Url = _configuration["BasestorageUrl"]
            });
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> UploadFile([FromQuery] UploadFileCommandRequest uploadFileCommandRequest)
        {
            uploadFileCommandRequest.Files = Request.Form.Files;
            UploadFileCommandResponse response = await _mediator.Send(uploadFileCommandRequest);
            return Ok();
        }
    }
}
