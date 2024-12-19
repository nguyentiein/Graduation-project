using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.IServices;
using FPM.Services.Mapping;
using FPM.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;
using FPM.Services.IServices;
using FPM.Services.Services;
using FPM.API.Controllers.Middlewares;
using FPM.Services.Mapping.Log;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace FPM.API
{
    public static class AddService
    {
        public static void AddDependencyInjection(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<ICommonCategoryRepository, CommonCategoryRepository>();
            services.AddScoped<ICommonCategoryService, CommonCategoryService>();

            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<ITestService, TestService>();

            services.AddScoped<IUploadPartRepository, UploadPartRepository>();
            services.AddTransient<IFileService, FileService>();

            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationService, NotificationService>();

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogService, LogService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAccountService, AccountService>();


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITeamRespository, TeamRepository>();
            services.AddScoped<ITeamService, TeamService>(); 

            services.AddScoped<ITeamMemberRespository, TeamMemberRepository>();
            services.AddScoped<ITeamMemeberService, TeamMemeberService>();

            services.AddScoped<ITopicRepository, TopicReponsitory>();
            services.AddScoped<ITopicServices, TopicServices>();

            services.AddScoped<ITopicMemberReponsitory, TopicMemberReponsitory>();
            services.AddScoped<ITopicMemberService, TopicMemberServices>();

            services.AddScoped<IPreproductionPlaningReponsitory, PreproductionPlaningRepository>();
            services.AddScoped<IPreproductionPlaningServices, PreproductionPlaningServices>();

            services.AddScoped<IApporvedReponsitory, ApporvedReponsitory>();
            services.AddScoped<IApprovedServices, ApprovedServices>();

            services.AddScoped<IEstimateReponsitory, EtimateReponsitory>();
            services.AddScoped<IEtimateServices, EstimateService>();

            services.AddScoped<ITopicDocumentRepository, TopicDocumentRepository>();
            services.AddScoped<ITopicDocumentService, TopicDocumentService>();

            services.AddScoped<IPreproducitonSegmentRepository, PreproductionSegmentRepository>();
            services.AddScoped<IPreproductionMemberRepository, PreproductionMemberRepository>();
            services.AddScoped<IPreproductionSegmentService, PreproductionSegmentService>();


            services.AddScoped<IPreproductionEstimateServices, PreproductionEstimateServices>();
            services.AddScoped<IPreproductionEstimateReponsitory, PreproductionEstimateReponsitory>();

            services.AddScoped<ISegmentMemberRepository, SegmentMemberRepository>();

            services.AddScoped<ISceneRepository, SceneRepository>();
            services.AddScoped<ISceneExpenseRepository, SceneExpenseRepository>();
            services.AddScoped<ISceneService, SceneService>();

            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IVideoService, VideoService>();

            services.AddScoped<IPostproductionPlanRepository, PostproductionPlanRepository>();
            services.AddScoped<IPostproductionPlanService, PostproductionPlanService>();

            services.AddScoped<IPostproductionExpenseRepository, PostproductionExpenseRepository>();
            services.AddScoped<IPostproductionExpenseService, PostproductionExpenseService>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            

            services.AddScoped<IMailService, MailService>();

            services.AddScoped<IBroadcastingRepository, BroadcastingRepository>();
            services.AddScoped<IBroadcastingDocumentRepository, BroadcastingDocumentRepository>();
            services.AddScoped<IBroadcastingService, BroadCastingService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(ModelToResourseProfile));

            services.AddHttpContextAccessor();
          
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext?.Request;
                var uri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent());
                return new UriService(uri);
            });


        }

        public static void AddCustomizeSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FPM", Version = $"v{Global.Version}" });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "FPM",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // Must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });

            });
        }

        public static void AddJwtBearerAuthentication(this IServiceCollection services) {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, // default True
                    ValidIssuer = JwtConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConfig.Secret)),
                    ValidAudience = JwtConfig.Audience,
                    ValidateAudience = true, // default True
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
        }

    }
}
