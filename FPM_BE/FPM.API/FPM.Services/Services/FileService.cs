using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Services
{
    public class FileService : IFileService
    {
        #region Method
        private readonly IUploadPartRepository _uploadPartRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Contructor
        public FileService(IUploadPartRepository uploadPartRepository, IUnitOfWork unitOfWork)
        {
            _uploadPartRepository = uploadPartRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Method
        public bool DeleteFileAsync(string fileUrl, string webRootPath)
        {
            var url = string.Concat(GetRootDirectory(), fileUrl);
            if (File.Exists(url))
            {
                File.Delete(url);
                return true;
            }
            return false;
        }

        public (bool IsSuccess, string? Message) RemoveFile(UploadPart? uploadPart, string webRootPath)
        {
            try
            {
                string url = string.Concat(webRootPath, uploadPart.FileLocation);
                if (File.Exists(url))
                {
                    File.Delete(url);
                    uploadPart.IsDeleted = true;
                    _uploadPartRepository.Update(uploadPart);
                    _unitOfWork.SaveChange();
                    return (true, "Delete successul");

                }

                return (false, "File is not found");
            }
            catch (Exception ex)
            {
                return (false, "Something wrong when remove file");
            }

            


        }

        public async Task<(int status, string message)> SaveImageAsync(IFormFile imageFile, string webRootPath)
        {
            try
            {
                //refference to API directory
                //var path = Path.Combine(Directory.GetCurrentDirectory(), "..", "FPM.API");
                //path = Path.Combine(path, "wwwroot", "upload","images");
                var path = string.Concat(webRootPath,"//wwwroot","//upload","//images");
                //if (!Directory.Exists(path))
                //{
                //    Directory.CreateDirectory(path);
                //}
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new(0, msg);
                }
                string uniqueString = Guid.NewGuid().ToString();
                // we are trying to create a unique filename here
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);

                var stream = new FileStream(fileWithPath, FileMode.Create);
                await imageFile.CopyToAsync(stream);
                
                stream.Dispose();

                return new(1, "/upload/images/" + newFileName);
            }
            catch (Exception ex)
            {
                return new(0, "Error has occured");
            }
            
        }

        public async Task<(string Message, UploadPart Data)> SaveVideoAsync(IFormFile file, string webRootPath)
        {
            try
            {
                //refference to API directory
                //var path =Path.Combine(GetRootDirectory(),"upload","videos");
                var path = string.Concat(webRootPath, "//wwwroot", "//upload", "//videos");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!IsVideo(file))
                {
                    string msg = "Loại file không hỗ trợ";
                    return (msg,null);
                }
                var uploadPart = new UploadPart()
                {
                    CreatedAt = DateTime.UtcNow,
                    FileType = 1,
                    TokenId = Guid.NewGuid().ToString(),
                    FileSize = file.Length,
                    IsDeleted = false,
                };

                
                // we are trying to create a unique filename here
                var newFileName = uploadPart.TokenId + Path.GetExtension(file.FileName);
                var fileWithPath = Path.Combine(path, newFileName);

                var stream = new FileStream(fileWithPath, FileMode.Create);
                await file.CopyToAsync(stream);

                stream.Dispose();
                
                uploadPart.TimeFinishUpload = DateTime.UtcNow;
                uploadPart.FileLocation = "//wwwroot//upload//videos//" + newFileName;
                uploadPart.FileUrl = "/upload/videos/" + newFileName;

                //return new(1, "/upload/videos/" + newFileName);

                return ("Thành công", uploadPart);
            }
            catch (Exception ex)
            {
                return (ex.Message,null);
            }
        }


        public async Task<UploadPart> UploadDocAsync(int userId, IFormFile file,string webRootPath)
        {
            if (file == null || file.Length == 0) return null;
            var path = string.Concat(webRootPath, "//wwwroot", "//upload", "//documents");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string tokenId = Guid.NewGuid().ToString();
            string newFileName = tokenId + "-" + file.FileName;
            string fileWithPath = Path.Combine(path, newFileName);
            UploadPart result = new UploadPart()
            {
                CreatedAt = DateTime.UtcNow,
                FileName = newFileName,
                FileLocation = "//wwwroot//upload//documents//" + newFileName,
                FileUrl = "/upload/documents/" + newFileName,
                TimeBeginUpload = DateTime.UtcNow,
                CreatedById = userId,
                TokenId = tokenId,
                FileSize = file.Length
            };

            try
            {
                var stream = new FileStream(fileWithPath, FileMode.Create);
                await file.CopyToAsync(stream);
                stream.Dispose();
                result.TimeFinishUpload = DateTime.UtcNow;
                
                return result;

            }
            catch (Exception ex) {
                return null;
            }

        }

        public async Task<(int status, string? FileName, string? Message)> UploadDocumentAsync(IFormFile file, string webRootPath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..", "FPM.API");
            var uploadFolder = Path.Combine("upload", "documents");

            path = Path.Combine(path, "wwwroot", "upload", "documents");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            string newFileName = Guid.NewGuid().ToString() + "-"+ file.FileName;

            var fileWithPath = Path.Combine(path,newFileName);

            try
            {
                var stream = new FileStream(fileWithPath, FileMode.Create);
                await file.CopyToAsync(stream);
                stream.Dispose();


                return (1,"/upload/documents/" + newFileName, null);
            }
            catch (Exception ex) {
                return (0,null, "Has Error in Uploading file: ");
            }
            
        }
        #endregion

        #region PrivateWork
        private string GetRootDirectory() => Path.Combine(Directory.GetCurrentDirectory(), "..", "FPM.API","wwwroot");
        private static readonly List<string> VideoExtensions = new()
        {
            ".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv", ".webm", ".mpeg", ".mpg", ".3gp", ".ogv", ".ogg"
        };
        private bool IsVideo(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName)?.ToLower();
            return VideoExtensions.Contains(extension);
        }
        #endregion
    }
}
