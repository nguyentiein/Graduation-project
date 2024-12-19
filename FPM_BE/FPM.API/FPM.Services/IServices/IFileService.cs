using FPM.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface IFileService
    {
        Task<(int status, string message)> SaveImageAsync(IFormFile imageFile,string webRootPath);
        bool DeleteFileAsync(string imageFileName, string webRootPath);

        Task<(int status, string? FileName, string? Message)> UploadDocumentAsync(IFormFile file,string webRootPath);

        Task<UploadPart> UploadDocAsync(int userId, IFormFile file, string webRootPath);

        (bool IsSuccess,string? Message) RemoveFile(UploadPart? uploadPart, string webRootPath);

        Task<(string Message, UploadPart Data)> SaveVideoAsync(IFormFile file, string webRootPath);
    }
}
