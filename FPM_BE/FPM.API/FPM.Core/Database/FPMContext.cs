using FPM.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Core.Database
{
    public class FPMContext : DbContext
    {
        #region Constructor
        public FPMContext()
        {
        }

        public FPMContext(DbContextOptions options) : base(options)
        {
            //Database.Migrate();
        }
        #endregion 

         
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Approved> Approveds { get; set; } = null!;
        public virtual DbSet<Broadcasting> Broadcastings { get; set; } = null!;
        public virtual DbSet<Broadcastingdocument> Broadcastingdocuments { get; set; } = null!;
        public virtual DbSet<Commoncategory> Commoncategories { get; set; } = null!;
        public virtual DbSet<Config> Configs { get; set; } = null!;
        public virtual DbSet<Contacttemplate> Contacttemplates { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<DocumentFile> DocumentFiles { get; set; } = null!;
        public virtual DbSet<Estimate> Estimates { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Movieapproval> Movieapprovals { get; set; } = null!;
        public virtual DbSet<MovieapprovalDetail> MovieapprovalDetails { get; set; } = null!;
        public virtual DbSet<Notify> Notifies { get; set; } = null!;
        public virtual DbSet<PostproductionPlaning> PostproductionPlanings { get; set; } = null!;
        public virtual DbSet<PostproductionProgress> PostproductionProgresses { get; set; } = null!;
        public virtual DbSet<PostproductionprogressMember> PostproductionprogressMembers { get; set; } = null!;
        public virtual DbSet<PreproductionEstimate> PreproductionEstimates { get; set; } = null!;
        public virtual DbSet<PreproductionMember> PreproductionMembers { get; set; } = null!;
        public virtual DbSet<PreproductionPlaning> PreproductionPlanings { get; set; } = null!;
        public virtual DbSet<PreproductionProgress> PreproductionProgresses { get; set; } = null!;
        public virtual DbSet<PreproductionSegment> PreproductionSegments { get; set; } = null!;
        public virtual DbSet<PreproductionprogressMember> PreproductionprogressMembers { get; set; } = null!;
        public virtual DbSet<PreproductionsegmentMember> PreproductionsegmentMembers { get; set; } = null!;
        public virtual DbSet<ReportCost> ReportCosts { get; set; } = null!;
        public virtual DbSet<ReportProgress> ReportProgresses { get; set; } = null!;
        public virtual DbSet<RoleRight> RoleRights { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TeamMember> TeamMembers { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;
        public virtual DbSet<TopicDocument> TopicDocuments { get; set; } = null!;
        public virtual DbSet<TopicMember> TopicMembers { get; set; } = null!;
        public virtual DbSet<UploadPart> UploadParts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        //public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<Video> Videos { get; set; } = null!;
        public virtual DbSet<VideoCompress> VideoCompresses { get; set; } = null!;
        public virtual DbSet<VreportSegment> VreportSegments { get; set; } = null!;
        public virtual DbSet<Scene> Scenes { get; set; } = null!;
        public virtual DbSet<SceneExpense> SceneExpenses { get; set; } = null!;
        public virtual DbSet<PostproductionExpense> PostproductionExpenses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ViewReport> ViewReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"..","FPM.API"))
                .AddJsonFile("appsettings.json", true, true)
                .Build();
                string connectionString = config["ConnectionStrings:MyDatabase"];
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Approved>(entity =>
            {
                entity.ToTable("approved");

                entity.Property(e => e.Comment).HasMaxLength(4000);

                entity.Property(e => e.ProcessedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Broadcasting>(entity =>
            {
                entity.ToTable("broadcasting");

                entity.Property(e => e.BroadcastingTime).HasColumnType("datetime");

                entity.Property(e => e.Reciever).HasMaxLength(200);

                entity.Property(e => e.SubmissionTime).HasColumnType("datetime");

                entity.Property(e => e.IsDelete).HasDefaultValue(false);

                entity.HasQueryFilter(e => e.IsDelete == false);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Broadcastings)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK_broadcasting_commoncategory");

                entity.HasOne(d => d.PostProductionPlaning)
                    .WithMany(p => p.Broadcastings)
                    .HasForeignKey(d => d.PostProductionPlaningId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_broadcasting_postproduction_planing");
            });

            modelBuilder.Entity<Broadcastingdocument>(entity =>
            {
                entity.ToTable("broadcastingdocument");

                entity.HasOne(d => d.Broadcasting)
                    .WithMany(p => p.Broadcastingdocuments)
                    .HasForeignKey(d => d.BroadcastingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_broadcastingdocument_broadcasting");

                entity.HasOne(d => d.UploadPart)
                    .WithMany(p => p.Broadcastingdocuments)
                    .HasForeignKey(d => d.UploadPartId)
                    .HasConstraintName("FK_broadcastingdocument_UploadPart");
            });

            modelBuilder.Entity<Commoncategory>(entity =>
            {
                entity.ToTable("commoncategory");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.IsDeleted).HasDefaultValue(false);

                entity.HasQueryFilter(e => e.IsDeleted == false);

                entity.HasOne(e => e.Parent)
                    .WithMany(e => e.Children)
                    .HasForeignKey(e => e.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_commoncategory_Parent");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("config");

                entity.Property(e => e.AllowFileType).HasMaxLength(2000);

                entity.Property(e => e.LogDir).HasMaxLength(200);

                entity.HasQueryFilter(e => e.IsDelete == false);
            });

            modelBuilder.Entity<Contacttemplate>(entity =>
            {
                entity.ToTable("contacttemplate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.DocName).HasMaxLength(200);

                entity.HasOne(d => d.DocTypeNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocType)
                    .HasConstraintName("FK_Document_commoncategory");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Document_user");
            });

            modelBuilder.Entity<DocumentFile>(entity =>
            {
                entity.ToTable("DocumentFile");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocumentFiles)
                    .HasForeignKey(d => d.DocumentId)
                    .HasConstraintName("FK_DocumentFile_Document");

                entity.HasOne(d => d.UploadPart)
                    .WithMany(p => p.DocumentFiles)
                    .HasForeignKey(d => d.UploadPartId)
                    .HasConstraintName("FK_DocumentFile_UploadPart");
            });

            modelBuilder.Entity<Estimate>(entity =>
            {
                entity.ToTable("estimate");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.HumanResourceEstimate).HasColumnType("decimal(12, 4)");

                entity.Property(e => e.OtherResourceEstimate).HasColumnType("decimal(12, 4)");

                entity.Property(e => e.TaskName).HasMaxLength(250);

                entity.Property(e => e.TimeEstimate).HasColumnType("decimal(12, 4)");
                entity.HasQueryFilter(e => e.IsDeleted == false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Estimates)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_estimate_user");

                entity.HasOne(d => d.PreProductPlaning)
                    .WithOne(p => p.Estimate)
                    .HasForeignKey<Estimate>(d => d.PreProductPlaningId)
                    .HasConstraintName("FK_estimate_preproduction_planing");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.Node)
                    .HasColumnName("NODE")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.ClientIp)
                    .HasColumnName("CLIENT_IP")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.TraceId)
                    .HasColumnName("TRACE_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.RequestDatetimeUtc)
                    .HasColumnName("REQUEST_DATETIME_UTC")
                    .HasPrecision(6);

                entity.Property(e => e.RequestPath)
                    .HasColumnName("REQUEST_PATH")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.RequestQuery)
                    .HasColumnName("REQUEST_QUERY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RequestMethod)
                    .HasColumnName("REQUEST_METHOD")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.RequestHost)
                    .HasColumnName("REQUEST_HOST")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.RequestBody)
                    .HasColumnName("REQUEST_BODY")
                    .IsUnicode(false);

                entity.Property(e => e.RequestContentType)
                    .HasColumnName("REQUEST_CONTENT_TYPE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseDatetimeUtc)
                    .HasColumnName("RESPONSE_DATETIME_UTC")
                    .HasPrecision(6);

                entity.Property(e => e.ResponseStatus)
                    .HasColumnName("RESPONSE_STATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseBody)
                    .HasColumnName("RESPONSE_BODY")
                    .IsUnicode(false);

                entity.Property(e => e.ResponseContentType)
                    .HasColumnName("RESPONSE_CONTENT_TYPE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HasException)
                    .HasColumnName("HAS_EXCEPTION")
                    .HasPrecision(1);

                entity.Property(e => e.ExceptionMessage)
                    .HasColumnName("EXCEPTION_MESSAGE")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionStackTrace)
                    .HasColumnName("EXCEPTION_STACK_TRACE")
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<Movieapproval>(entity =>
            {
                entity.ToTable("movieapproval");

                entity.HasIndex(e => e.PostProductionPlaningId, "FK_movieapproval_postproduction_planing_idx");

                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.Comment).HasMaxLength(4000);

                entity.Property(e => e.Content).HasMaxLength(4000);

                entity.Property(e => e.EndAt).HasColumnType("datetime");

                entity.Property(e => e.StartAt).HasColumnType("datetime");

                entity.Property(e => e.Suggested).HasMaxLength(4000);

                entity.HasOne(d => d.PostProductionPlaning)
                    .WithMany(p => p.Movieapprovals)
                    .HasForeignKey(d => d.PostProductionPlaningId)
                    .HasConstraintName("FK_movieapproval_postproduction_planing");
            });

            modelBuilder.Entity<MovieapprovalDetail>(entity =>
            {
                entity.ToTable("movieapproval_detail");

                entity.HasIndex(e => e.UserId, "FK_moviceapproval_detail_User_idx");

                entity.HasIndex(e => e.MovieApprovalId, "FK_movieapproval_detail_movieapproval_idx");

                entity.Property(e => e.Comment).HasMaxLength(4000);

                entity.Property(e => e.Role).HasMaxLength(2000);

                entity.Property(e => e.Suggested).HasMaxLength(4000);

                entity.HasOne(d => d.MovieApproval)
                    .WithMany(p => p.MovieapprovalDetails)
                    .HasForeignKey(d => d.MovieApprovalId)
                    .HasConstraintName("FK_movieapproval_detail_movieapproval");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MovieapprovalDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_moviceapproval_detail_User");
            });

            modelBuilder.Entity<Notify>(entity =>
            {
                entity.ToTable("notify");

                entity.Property(e => e.ActionType).HasComment("1-Tao moi\r\n2-Sua\r\n3-Xoa\r\n4-Duyet\r\n5-Tu choi Duyet");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Detail).HasMaxLength(2000);

                entity.Property(e => e.ObjectType).HasComment("1-De tai\r\n2-De cuong\r\n3-Ke hoach tien san xuat\r\n4-Duyet  ket thuc san xuat tien ky\r\n5-Ke hoach hau ky\r\n6-Duyet ket thuc san xuat hau ky\r\n7-Duyet phim");

                entity.Property(e => e.Status).HasComment("0-new\r\n1- Da xem\r\n2-Da xu ly");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.NotifySenders)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK_notify_user");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NotifyUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_notify_user1");
            });

            modelBuilder.Entity<PostproductionPlaning>(entity =>
            {
                entity.ToTable("postproduction_planing");

                entity.HasIndex(e => e.PreProductionId, "FK_postproduction_planing_preproduction_planing_idx");

                entity.Property(e => e.Budget).HasColumnType("decimal(14, 2)");
                entity.Property(e => e.OtherFee).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.CloseDate).HasColumnType("datetime");

                entity.Property(e => e.CloseNote).HasMaxLength(4000);

                entity.Property(e => e.CloseReason).HasMaxLength(2000);

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.WorkContent).HasMaxLength(4000);

                entity.HasOne(d => d.PreProduction)
                    .WithOne(p => p.PostproductionPlaning)
                    .HasForeignKey<PostproductionPlaning>(d => d.PreProductionId)
                    .HasConstraintName("FK_postproduction_planing_preproduction_planing");
            });

            modelBuilder.Entity<PostproductionProgress>(entity =>
            {
                entity.ToTable("postproduction_progress");

                entity.HasIndex(e => e.PostProductionId, "FK_postproduction_progress_postproduction_plaing_idx");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Expense).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.TotalProgress).HasColumnType("decimal(14, 2)");

                entity.HasOne(d => d.ExpenseTypeNavigation)
                    .WithMany(p => p.PostproductionProgresses)
                    .HasForeignKey(d => d.ExpenseType)
                    .HasConstraintName("FK_postproduction_progress_commoncategory");

                entity.HasOne(d => d.PostProduction)
                    .WithMany(p => p.PostproductionProgresses)
                    .HasForeignKey(d => d.PostProductionId)
                    .HasConstraintName("FK_postproduction_progress_postproduction_plaing");
            });

            modelBuilder.Entity<PostproductionprogressMember>(entity =>
            {
                entity.ToTable("postproductionprogress_member");

                entity.HasIndex(e => e.UserId, "FK_postproductionprogress_member_user_idx");

                entity.HasIndex(e => e.PostProductionProgressId, "postproductionprogress_member_postproduction_progress_idx");

                entity.Property(e => e.Comment).HasMaxLength(4000);

                entity.Property(e => e.PercentCompleted).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.Role).HasMaxLength(200);

                entity.HasOne(d => d.PostProductionProgress)
                    .WithMany(p => p.PostproductionprogressMembers)
                    .HasForeignKey(d => d.PostProductionProgressId)
                    .HasConstraintName("FK_postproductionprogress_member_postproduction_progress");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostproductionprogressMembers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_postproductionprogress_member_user");
            });

            modelBuilder.Entity<PreproductionEstimate>(entity =>
            {
                entity.ToTable("preproduction_estimate");

                entity.HasIndex(e => e.SegmentId, "FK_preproduction_estimate_preproduction_segment_idx");

                entity.HasIndex(e => e.PreProductionId, "FK_preproduction_estimate_preproduction_planing_idx");

                entity.Property(e => e.Amount).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Reason).HasMaxLength(2000);

                entity.HasQueryFilter(e => e.IsDeleted == false);
                entity.HasOne(d => d.PreProduction)
                    .WithMany(p => p.PreproductionEstimates)
                    .HasForeignKey(d => d.PreProductionId)
                    .HasConstraintName("FK_preproduction_estimate_preproduction_planing");

                entity.HasOne(d => d.Segment)
                    .WithMany(p => p.PreproductionEstimates)
                    .HasForeignKey(d => d.SegmentId)
                    .HasConstraintName("FK_preproduction_estimate_preproduction_segment");

                entity.HasOne(d => d.ExpenseType)
                    .WithMany(p => p.PreproductionEstimates)
                    .HasForeignKey(d => d.ExpenseTypeId)
                    .HasConstraintName("FK_preproduction_estimate_commoncategory");
            });

            modelBuilder.Entity<PreproductionMember>(entity =>
            {
                entity.ToTable("preproduction_member");

                entity.HasIndex(e => e.PreProductionId, "FK_preproduction_member_preproduction_planing_idx");

                entity.HasIndex(e => e.MemberId, "FK_preproduction_member_user_idx");

                entity.Property(e => e.Description).HasMaxLength(4000);


                entity.HasOne(d => d.Member)
                    .WithMany(p => p.PreproductionMembers)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_preproduction_member_user");

                entity.HasOne(d => d.PreProduction)
                    .WithMany(p => p.PreproductionMembers)
                    .HasForeignKey(d => d.PreProductionId)
                    .HasConstraintName("FK_preproduction_member_preproduction_planing");



            });

            modelBuilder.Entity<PreproductionPlaning>(entity =>
            {
                entity.ToTable("preproduction_planing");

                entity.HasIndex(e => e.TeamId, "FK_preproduction_planing_team_idx");

                entity.HasIndex(e => e.TopicId, "FK_preproduction_planing_topic_idx");

                entity.HasIndex(e => e.ApprovedMember, "FK_preproduction_planing_user_idx");

                entity.Property(e => e.Budget).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.CloseDate).HasColumnType("datetime");

                entity.Property(e => e.CloseExpense).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.CloseNote).HasMaxLength(4000);

                entity.Property(e => e.CloseReason).HasMaxLength(2000);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Scenario).HasColumnType("longtext");

                entity.HasQueryFilter(e => e.IsDeleted == false);

                entity.HasOne(d => d.ApprovedMemberNavigation)
                    .WithMany(p => p.PreproductionPlanings)
                    .HasForeignKey(d => d.ApprovedMember)
                    .HasConstraintName("FK_preproduction_planing_user");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PreproductionPlanings)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_preproduction_planing_commoncategory");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PreproductionPlanings)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_preproduction_planing_team");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.PreproductionPlanings)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK_preproduction_planing_topic");
            });

            modelBuilder.Entity<PreproductionProgress>(entity =>
            {
                entity.ToTable("preproduction_progress");

                entity.HasIndex(e => e.PreProductionId, "FK_preproduction_progress_preproduction_planing_idx");

                entity.HasIndex(e => e.SegmentId, "FK_preproduction_progress_preproduction_segment_idx");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Expense).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.SegmentProgress).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.Status).HasComment("0: New; 1 : Duyet; -1: Tu choi");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.TotalProgress).HasColumnType("decimal(14, 2)");

                entity.HasOne(d => d.ExpenseTypeNavigation)
                    .WithMany(p => p.PreproductionProgresses)
                    .HasForeignKey(d => d.ExpenseType)
                    .HasConstraintName("FK_preproduction_progress_commoncategory");

                entity.HasOne(d => d.PreProduction)
                    .WithOne(p => p.PreproductionProgress)
                    .HasForeignKey<PreproductionProgress>(d => d.PreProductionId)
                    .HasConstraintName("FK_preproduction_progress_preproduction_planing");

                entity.HasOne(d => d.Segment)
                    .WithMany(p => p.PreproductionProgresses)
                    .HasForeignKey(d => d.SegmentId)
                    .HasConstraintName("FK_preproduction_progress_preproduction_segment");
            });

            modelBuilder.Entity<PreproductionSegment>(entity =>
            {
                entity.ToTable("preproduction_segment");

                entity.HasIndex(e => e.PreProductionId, "FK_preproduction_segment_preproduction_planing_idx");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Budget).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Scenario).HasColumnType("longtext");
                entity.Property(e => e.Description).HasMaxLength(4000).HasColumnType("longtext");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValue(false);

                entity.HasQueryFilter(e => e.IsDeleted == false);

                entity.HasOne(d => d.PreProduction)
                    .WithMany(p => p.PreproductionSegments)
                    .HasForeignKey(d => d.PreProductionId)
                    .HasConstraintName("FK_preproduction_segment_preproduction_planing");


            });

            modelBuilder.Entity<PreproductionprogressMember>(entity =>
            {
                entity.ToTable("preproductionprogress_member");

                entity.HasIndex(e => e.PreProductionProgressId, "FK_preproductionprogress_member_preoproduction_progress_idx");

                entity.HasIndex(e => e.UserId, "FK_preproductionprogress_member_user_idx");

                entity.Property(e => e.Comment).HasMaxLength(4000);

                entity.Property(e => e.PercentComplete).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.Role).HasMaxLength(200);

                entity.HasOne(d => d.PreProductionProgress)
                    .WithMany(p => p.PreproductionprogressMembers)
                    .HasForeignKey(d => d.PreProductionProgressId)
                    .HasConstraintName("FK_preproductionprogress_member_preoproduction_progress");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PreproductionprogressMembers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_preproductionprogress_member_user");
            });

            modelBuilder.Entity<PreproductionsegmentMember>(entity =>
            {
                entity.ToTable("preproductionsegment_member");

                entity.HasIndex(e => e.PreProductionSegmentId, "FK_preproductionsegment_member_preproduction_segment_idx");

                entity.HasIndex(e => e.UserId, "FK_preproductionsegment_member_user_idx");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Role).HasMaxLength(200);

                entity.Property(e => e.WorkingHour).HasColumnType("decimal(14, 2)");

                entity.HasOne(d => d.PreProductionSegment)
                    .WithMany(p => p.PreproductionsegmentMembers)
                    .HasForeignKey(d => d.PreProductionSegmentId)
                    .HasConstraintName("FK_preproductionsegment_member_preproduction_segment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PreproductionsegmentMembers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_preproductionsegment_member_user");

                entity.HasOne(d => d.PreproductionMember)
                    .WithMany(d => d.SegmentMembers)
                    .HasForeignKey(d => d.PlanMemberId)
                    .HasConstraintName("PK_SegmentMember_PreproductionMember");

            });

            modelBuilder.Entity<ReportCost>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ReportCost");

                entity.Property(e => e.EstimatedBudget).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.EstimatedEnd).HasColumnType("datetime");

                entity.Property(e => e.ExpenseDifference).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.MinEstimatedBegin).HasColumnType("datetime");

                entity.Property(e => e.OutName).HasMaxLength(200);

                entity.Property(e => e.PercentageDifference).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.PostProductionFromDate).HasColumnType("datetime");

                entity.Property(e => e.PostProductionToDate).HasColumnType("datetime");

                entity.Property(e => e.PreProductionPlanName).HasMaxLength(200);

                entity.Property(e => e.SumExpense).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.TopicName).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<ReportProgress>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ReportProgress");

                entity.Property(e => e.CombinedStatus)
                    .HasMaxLength(154)
                    .IsUnicode(false);

                entity.Property(e => e.EstimatedBudget).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.EstimatedEnd).HasColumnType("datetime");

                entity.Property(e => e.MinEstimatedBegin).HasColumnType("datetime");

                entity.Property(e => e.OutlineName).HasMaxLength(200);

                entity.Property(e => e.PostProductionFromDate).HasColumnType("datetime");

                entity.Property(e => e.PostProductionToDate).HasColumnType("datetime");

                entity.Property(e => e.PreProductionPlanName).HasMaxLength(200);

                entity.Property(e => e.TopicName).HasMaxLength(200);

                entity.Property(e => e.TotalProgress).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<RoleRight>(entity =>
            {
                entity.ToTable("role_right");

                entity.HasIndex(e => e.RightId, "roleright_right_idx");

                entity.HasIndex(e => e.RoleId, "roleright_role_idx");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Right)
                    .WithMany(p => p.RoleRightRights)
                    .HasForeignKey(d => d.RightId)
                    .HasConstraintName("roleright_right");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleRightRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("roleright_role");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.HasIndex(e => e.LeaderId, "FK_team_user_idx");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.HasQueryFilter(e => e.IsDeleted == false);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.Leader)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.LeaderId)
                    .HasConstraintName("FK_team_user");
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.ToTable("team_member");

                entity.HasIndex(e => e.TeamId, "FK_team_member_team_idx");

                entity.HasIndex(e => e.UserId, "FK_team_member_user_idx");
                entity.HasQueryFilter(e => e.IsDeleted == false);

                entity.Property(e => e.Role).HasMaxLength(200);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_team_member_team");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_team_member_user");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("topic");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.EstimatedBegin).HasColumnType("datetime");

                entity.Property(e => e.EstimatedBroadcasting).HasColumnType("datetime");

                entity.Property(e => e.EstimatedBudget).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.Budget).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EstimatedEnd).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Scenario).HasMaxLength(4000);
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.HasQueryFilter(e => e.IsDeleted == false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_topic_commoncategory");
                entity.HasOne(t => t.User)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(t => t.CreatedBy)
                    .HasConstraintName("FK_topic_user");

            });

            modelBuilder.Entity<TopicDocument>(entity =>
            {
                entity.ToTable("topic_document");

                entity.HasIndex(e => e.TopicId, "FK_topic_document_topic_idx");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.FileUrl).HasMaxLength(200);

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicDocuments)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK_topic_document_topic");

                entity.HasOne(d => d.UploadPart)
                    .WithMany(p => p.TopicDocuments)
                    .HasForeignKey(d => d.UploadPartId)
                    .HasConstraintName("FK_topic_document_UploadPart");
            });

            modelBuilder.Entity<TopicMember>(entity =>
            {
                entity.ToTable("topic_member");

                entity.HasIndex(e => e.TopicId, "FK_topic_member_topic_idx");

                entity.HasIndex(e => e.MemberId, "FK_topic_member_user_idx");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Role).HasMaxLength(200);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TopicMembers)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_topic_member_user");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicMembers)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK_topic_member_topic");
            });

            modelBuilder.Entity<UploadPart>(entity =>
            {
                entity.ToTable("UploadPart");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.FileLocation).HasMaxLength(2000);

                entity.Property(e => e.FileUrl).HasMaxLength(2000);
 
                entity.Property(e => e.FileName).HasMaxLength(2000);

                entity.Property(e => e.Snapshot).HasMaxLength(2000);

                entity.Property(e => e.TimeBeginUpload).HasColumnType("datetime");

                entity.Property(e => e.TimeFinishUpload).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.TokenId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValue(false);

                entity.HasQueryFilter(e => e.IsDeleted == false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.DepartId, "user_depart_idx");

                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.verificationCode).HasMaxLength(200);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.PassWord)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AvatarUrl).HasMaxLength(200).IsUnicode(false);

                entity.Property(e => e.Status).HasComment("1-Active; -1 -Delete");

                entity.Property(e => e.Tel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.HasOne(d => d.Depart)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartId)
                    .HasConstraintName("user_depart");
                
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("TBL_user_role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");


                
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("video");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.VideoLength).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.VideoName).HasMaxLength(200);

                entity.Property(e => e.VideoSize).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.VideoUrl).HasMaxLength(200);

                entity.HasOne(d => d.UploadPart)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.UploadPartId)
                    .HasConstraintName("FK_video_UploadPart");
            });

            modelBuilder.Entity<VideoCompress>(entity =>
            {
                entity.ToTable("VideoCompress");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.FileLocation).HasMaxLength(1000);

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.Url).HasMaxLength(2000);

                entity.HasOne(d => d.UploadPart)
                    .WithMany(p => p.VideoCompresses)
                    .HasForeignKey(d => d.UploadPartId)
                    .HasConstraintName("FK_VideoCompress_UploadPart");
            });

            modelBuilder.Entity<VreportSegment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VReportSegment");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.BudgetSegment).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.CommuneId).HasMaxLength(200);

                entity.Property(e => e.DistrictId).HasMaxLength(200);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EstimatedEndDateSegment).HasColumnType("datetime");

                entity.Property(e => e.EstimatedStartDateSegment).HasColumnType("datetime");

                entity.Property(e => e.ExpenseProgress).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ProvinceId).HasMaxLength(200);

                entity.Property(e => e.Scenario).HasColumnType("longtext");

                entity.Property(e => e.SegmentProgress).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            //modelBuilder.Entity<Test>(entity =>
            //{
            //    entity.ToTable("TBL_Test");

            //    entity.HasKey(e => e.Id);

            //    entity.HasQueryFilter(e => e.IsDeleted == false);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //});

            modelBuilder.Entity<Scene>(entity =>
            {
                entity.ToTable("TBL_Scene");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Scene_id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(p => p.PreproductionSegment).WithMany(d => d.Scenes)
                        .HasForeignKey(e => e.PreproductionSegmentId)
                        .HasConstraintName("FK_Scene_PreproductionSegment");

                entity.Property(x => x.IsDeleted).HasDefaultValue(false);

                entity.HasQueryFilter(x => x.IsDeleted == false);
            });

            modelBuilder.Entity<SceneExpense>(entity =>
            {
                entity.ToTable("TBL_Scene_Expense");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Scene_expense_id");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(p => p.Scene).WithMany(d => d.SceneExpenses)
                        .HasForeignKey(e => e.SceneId)
                        .HasConstraintName("FK_SceneExpense_Scense");

                entity.Property(x => x.IsDeleted).HasDefaultValue(false);

                entity.HasQueryFilter(x => x.IsDeleted == false);
            });


            modelBuilder.Entity<PostproductionExpense>(entity =>
            {
                entity.ToTable("TBL_Postproduction_expense");
                entity.Property(x => x.Id).HasColumnName("Postproduction_expense_id");

                entity.Property(x => x.IsDeleted).HasDefaultValue(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(e => e.PostProductPlaning)
                    .WithMany(p => p.PostproductionExpenses)
                    .HasForeignKey(e => e.PostProductPlaningId)
                    .HasConstraintName("PK_PostproductionExpense_Postproduction");

                entity.HasOne(e => e.CreatedByNavigation)
                        .WithMany(p => p.PostproductionExpenses)
                        .HasForeignKey(e => e.CreatedBy)
                        .HasConstraintName("PK_PostproductionExpense_CreateByUser");


                entity.HasQueryFilter(e => e.IsDeleted == false);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("TBL_Role");
                entity.Property(x => x.Id).HasColumnName("Role_id");

                entity.HasMany(x => x.Users)
                      .WithMany(u => u.Roles)
                      .UsingEntity<UserRole>(
                        j => j.HasOne(ur => ur.User).WithMany(),
                        j => j.HasOne(ur => ur.Role).WithMany(),
                        j => j.HasKey(ur => new { ur.UserId, ur.RoleId })
                      );

            });

            modelBuilder.Entity<ViewReport>().HasNoKey().ToView(null);

            //seed data
            modelBuilder.SeedData();

        }
    }
}
