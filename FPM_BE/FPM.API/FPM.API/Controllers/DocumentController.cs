using FPM.API.Authorization;
using FPM.Core.Entities;
using FPM.Resourses;
using FPM.Resourses.DTOs.TopicDocument.Request;
using FPM.Resourses.DTOs.Video.Request;
using FPM.Resourses.Enums;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;
using System.IO;

namespace FPM.API.Controllers
{
    [Route("api/v1/document")]
    [ApiController]
    public class DocumentController : ParentController
    {
        private readonly ITopicDocumentService _documentService;
        private readonly IVideoService _videoService;
        private readonly IWebHostEnvironment _env;
        private readonly IHostEnvironment _hostEnvironment;
        public DocumentController(ITopicDocumentService documentService,
                                  IVideoService videoService,
                                  IHostEnvironment hostEnvironment,
                                  IWebHostEnvironment env,
                                  IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _documentService = documentService;
            _videoService = videoService;
            _hostEnvironment = hostEnvironment;
            _env = env;
        }

        [HttpPost("CreateDocument")]
        [Authorize]
        public async Task<IActionResult> PostAsync([FromForm] CreateTopicDocumentRequest request)
        {
            var user = (User)HttpContext.Items["User"];
            var result = await _documentService.CreateTopicDocumentAsync(user.Id, request, _hostEnvironment.ContentRootPath);

            return Ok(result);
        }

        [HttpGet("GetFile")]
        
        public FileResult GetFileAsync([FromQuery]string fileName )
        {
            var filepath = _env.WebRootPath + fileName;
            string contentType = GetContentType(fileName);

            return PhysicalFile(filepath, contentType, Path.GetFileName(fileName));
        }

        [HttpPut("ApproveDocument/{id}")]
        [Authorize(RoleEnum.Director)]
        public async Task<IActionResult> ApproveDocument(int id, ApproveDocumentRequest request)
        {
            var user = (User)HttpContext.Items["User"];
            request.Id = id;
            var result = await _documentService.ApproveDocumentAsync(request.Id, request.Status, user.Id, request.Comment);

            return Ok(result);
        }
        [HttpPut("UpdateDocument/{id}")]
        [Authorize(RoleEnum.Scriptor)]
        public async Task<IActionResult> UpdateDocumentAsync(int id,[FromForm] UpdateDocumentRequest request)
        {
            var user = (User)HttpContext.Items["User"];
            
            var result = await _documentService.UpdateDocumentAsync(user.Id,id, request,_hostEnvironment.ContentRootPath);
            return Ok(result);
        }

        [HttpDelete("DeleteTopicDocument/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var response = await _documentService.DeleteDocumentAsync(id,_hostEnvironment.ContentRootPath);
            return Ok(response);
        }

        [HttpPost("UploadVideo")]
        //[Authorize]
        public async Task<IActionResult> UpdateVideo([FromForm] CreateVideoRequest request)
        {
            var response = await _videoService.AddVideoAsync(request,_hostEnvironment.ContentRootPath);
            return Ok(response);
        }

        [HttpDelete("removeVideo/{videoId}")]
        public async Task<IActionResult> RemoveVideoAsync(int videoId)
        {
            var response = await _videoService.RemoveVideoAsync(videoId,_hostEnvironment.ContentRootPath);
            return Ok(response);
        }


        [HttpPost("SearchVideo")]
        public async Task<ActionResult> SearchVideoAsync(SearchVideoRequest request)
        {
            var response = await _videoService.GetListVideoAsync(request.ObjectId, request.ObjectType);
            return Ok(response);
        }


        [HttpPost("SearchDocument")]
        [Authorize]
        public async Task<IActionResult> ApproveDocumentAsync([FromBody] SearchDocumentModel request) {

            var response = await _documentService.SearchDocumentAsync(request);

            return Ok(response);

        }

        private string GetContentType(string fileName)
        {
            var ext = Path.GetExtension(fileName).ToLowerInvariant();

            return ext switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".mp4" => "video/mp4",
                ".mp3" => "audio/mpeg",
                ".pdf" => "application/pdf",
                ".txt" => "text/plain",
                ".html" => "text/html",
                _ => "application/octet-stream", // Default binary type for unknown types
            };
        }
    }
}
