using AutoMapper;
using FPM.Resourses.DTOs.Broadcasting.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Broadcasting
{
    public sealed class ModelToResourseProfile: Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Core.Entities.Broadcasting, BroadcastingResponse>()
                .ForMember(x => x.FilmName, opt => opt.MapFrom(src => src.PostProductionPlaning.PreProduction.Name))
                .ForMember(x => x.Channel, opt => opt.MapFrom(src => src.Channel));

            CreateMap<Core.Entities.Broadcastingdocument, BroadcastingDocumentResponse>()
                .ForMember(x => x.FileName, opt => opt.MapFrom(src => src.UploadPart.FileName))
                .ForMember(x => x.FileType, opt => opt.MapFrom(src => src.UploadPart.FileType))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.UploadPart.Description))
                .ForMember(x => x.FileUrl, opt => opt.MapFrom(src => src.UploadPart.FileUrl))
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(src => src.UploadPart.CreatedAt));


                
        }
    }
}
