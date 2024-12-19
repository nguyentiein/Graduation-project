using FPM.Resourses.DTOs.Broadcasting.Request;
using FPM.Resourses.DTOs.Broadcasting.Response;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface IBroadcastingService
    {
        Task<BaseResult<BroadcastingResponse>> GetByIdAsync(int id);

        Task<BaseResult<BroadcastingResponse>> CreateAsync(CreateBroadcastingRequest request);
        Task<BaseResult<BroadcastingResponse>> UpdateAsync(UpdateBroadcastingRequest request);
        Task<BaseResult<object>> DeleteAsync(int id);

        Task<BaseResult<BroadcastingDocumentResponse>> UploadDocumentAsync(int userId, UploadBroadcastingDocumentRequest request,string webRootPath);
        Task<BaseResult<IEnumerable<BroadcastingDocumentResponse>>> GetAllDocumentAsync(int broadcastingId);
    }
}
