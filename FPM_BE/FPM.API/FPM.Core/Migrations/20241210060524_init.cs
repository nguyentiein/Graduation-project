using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPM.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Approved",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectId = table.Column<int>(type: "int", nullable: true),
                    ProcessedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProcessedBy = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Result = table.Column<int>(type: "int", nullable: true),
                    ObjectType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Approved", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Commoncategory",
                columns: table => new
                {
                    commonCategory_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Commoncategory", x => x.commonCategory_id);
                    table.ForeignKey(
                        name: "FK_commoncategory_Parent",
                        column: x => x.ParentId,
                        principalTable: "tbl_Commoncategory",
                        principalColumn: "commonCategory_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TokenExpire = table.Column<int>(type: "int", nullable: true),
                    PageSize = table.Column<int>(type: "int", nullable: true),
                    LogDir = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaxFileSize = table.Column<long>(type: "bigint", nullable: true),
                    AllowFileType = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Config", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Log",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(38)", unicode: false, maxLength: 38, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NODE = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CLIENT_IP = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TRACE_ID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REQUEST_DATETIME_UTC = table.Column<DateTime>(type: "datetime(6)", precision: 6, nullable: false),
                    REQUEST_PATH = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REQUEST_QUERY = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REQUEST_METHOD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REQUEST_HOST = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REQUEST_BODY = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REQUEST_CONTENT_TYPE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RESPONSE_DATETIME_UTC = table.Column<DateTime>(type: "datetime(6)", precision: 6, nullable: false),
                    RESPONSE_STATUS = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RESPONSE_BODY = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RESPONSE_CONTENT_TYPE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HAS_EXCEPTION = table.Column<bool>(type: "tinyint(1)", precision: 1, nullable: false),
                    EXCEPTION_MESSAGE = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXCEPTION_STACK_TRACE = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Log", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBL_Role",
                columns: table => new
                {
                    Role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Role", x => x.Role_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_UploadPart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileSize = table.Column<long>(type: "bigint", nullable: true),
                    TokenId = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileLocation = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileUrl = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeBeginUpload = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeFinishUpload = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    NumberOfChunks = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileType = table.Column<int>(type: "int", nullable: true),
                    Snapshot = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UploadPart", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PassWord = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AvatarUrl = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tel = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "1-Active; -1 -Delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.Id);
                    table.ForeignKey(
                        name: "user_depart",
                        column: x => x.DepartId,
                        principalTable: "tbl_Commoncategory",
                        principalColumn: "commonCategory_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectId = table.Column<int>(type: "int", nullable: true),
                    ObjectType = table.Column<int>(type: "int", nullable: true),
                    VideoName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VideoUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VideoLength = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    VideoSize = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    Note = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UploadPartId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_video_UploadPart",
                        column: x => x.UploadPartId,
                        principalTable: "tbl_UploadPart",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Document",
                columns: table => new
                {
                    document_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DocName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Document", x => x.document_id);
                    table.ForeignKey(
                        name: "FK_Document_commoncategory",
                        column: x => x.DocType,
                        principalTable: "tbl_Commoncategory",
                        principalColumn: "commonCategory_id");
                    table.ForeignKey(
                        name: "FK_Document_user",
                        column: x => x.UserId,
                        principalTable: "tbl_User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Notify",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ActionType = table.Column<int>(type: "int", nullable: true, comment: "1-Tao moi\r\n2-Sua\r\n3-Xoa\r\n4-Duyet\r\n5-Tu choi Duyet"),
                    ObjectType = table.Column<int>(type: "int", nullable: true, comment: "1-De tai\r\n2-De cuong\r\n3-Ke hoach tien san xuat\r\n4-Duyet  ket thuc san xuat tien ky\r\n5-Ke hoach hau ky\r\n6-Duyet ket thuc san xuat hau ky\r\n7-Duyet phim"),
                    ObjectId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detail = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: true, comment: "0-new\r\n1- Da xem\r\n2-Da xu ly")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Notify", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notify_user",
                        column: x => x.SenderId,
                        principalTable: "tbl_User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_notify_user1",
                        column: x => x.UserId,
                        principalTable: "tbl_User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LeaderId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_team_user",
                        column: x => x.LeaderId,
                        principalTable: "tbl_User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Scenario = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstimatedBegin = table.Column<DateTime>(type: "datetime", nullable: true),
                    EstimatedEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    EstimatedBroadcasting = table.Column<DateTime>(type: "datetime", nullable: true),
                    EstimatedBudget = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topic_commoncategory",
                        column: x => x.CategoryId,
                        principalTable: "tbl_Commoncategory",
                        principalColumn: "commonCategory_id");
                    table.ForeignKey(
                        name: "FK_topic_user",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBL_User_role",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_User_role", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_TBL_User_role_TBL_Role_role_id",
                        column: x => x.role_id,
                        principalTable: "TBL_Role",
                        principalColumn: "Role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_User_role_tbl_User_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_DocumentFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    UploadPartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DocumentFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentFile_Document",
                        column: x => x.DocumentId,
                        principalTable: "tbl_Document",
                        principalColumn: "document_id");
                    table.ForeignKey(
                        name: "FK_DocumentFile_UploadPart",
                        column: x => x.UploadPartId,
                        principalTable: "tbl_UploadPart",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Team_member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Team_member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_team_member_team",
                        column: x => x.TeamId,
                        principalTable: "tbl_Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_team_member_user",
                        column: x => x.UserId,
                        principalTable: "tbl_User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_preproduction_planing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TopicId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    ApprovedMember = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CloseDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CloseExpense = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    CloseNote = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CloseReason = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Scenario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_preproduction_planing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_preproduction_planing_commoncategory",
                        column: x => x.CategoryId,
                        principalTable: "tbl_Commoncategory",
                        principalColumn: "commonCategory_id");
                    table.ForeignKey(
                        name: "FK_preproduction_planing_team",
                        column: x => x.TeamId,
                        principalTable: "tbl_Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_preproduction_planing_topic",
                        column: x => x.TopicId,
                        principalTable: "tbl_Topic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_preproduction_planing_user",
                        column: x => x.ApprovedMember,
                        principalTable: "tbl_User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Topic_document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TopicId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    ApproveBy = table.Column<int>(type: "int", nullable: true),
                    FileUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UploadPartId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Topic_document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topic_document_topic",
                        column: x => x.TopicId,
                        principalTable: "tbl_Topic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_topic_document_UploadPart",
                        column: x => x.UploadPartId,
                        principalTable: "tbl_UploadPart",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Topic_member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TopicId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Topic_member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topic_member_topic",
                        column: x => x.TopicId,
                        principalTable: "tbl_Topic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_topic_member_user",
                        column: x => x.MemberId,
                        principalTable: "tbl_User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Estimate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PreProductPlaningId = table.Column<int>(type: "int", nullable: true),
                    TaskName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeEstimate = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    HumanResourceEstimate = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    OtherResourceEstimate = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    Phase = table.Column<int>(type: "int", nullable: true),
                    TypeFilm = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duration = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    ScriptFee = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ProducerFee = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DirectorFee = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CameramanFee = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EditorFee = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Estimate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estimate_preproduction_planing",
                        column: x => x.PreProductPlaningId,
                        principalTable: "tbl_preproduction_planing",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_estimate_user",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Postproduction_planing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PreProductionId = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    WorkContent = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Budget = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CloseDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CloseReason = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CloseNote = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OtherFee = table.Column<decimal>(type: "decimal(14,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Postproduction_planing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_postproduction_planing_preproduction_planing",
                        column: x => x.PreProductionId,
                        principalTable: "tbl_preproduction_planing",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_preproductionMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PreProductionId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SalaryType = table.Column<int>(type: "int", nullable: false),
                    TotalWorkingHour = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalSalary = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_preproductionMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_preproduction_member_preproduction_planing",
                        column: x => x.PreProductionId,
                        principalTable: "tbl_preproduction_planing",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_preproduction_member_user",
                        column: x => x.MemberId,
                        principalTable: "tbl_User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblPreproduction_segment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PreProductionId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Scenario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPreproduction_segment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_preproduction_segment_preproduction_planing",
                        column: x => x.PreProductionId,
                        principalTable: "tbl_preproduction_planing",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Broadcasting",
                columns: table => new
                {
                    broadcasting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostProductionPlaningId = table.Column<int>(type: "int", nullable: false),
                    ChannelId = table.Column<int>(type: "int", nullable: true),
                    BroadcastingTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Duration = table.Column<long>(type: "bigint", nullable: true),
                    SubmissionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reciever = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Broadcasting", x => x.broadcasting_id);
                    table.ForeignKey(
                        name: "FK_broadcasting_commoncategory",
                        column: x => x.ChannelId,
                        principalTable: "tbl_Commoncategory",
                        principalColumn: "commonCategory_id");
                    table.ForeignKey(
                        name: "FK_broadcasting_postproduction_planing",
                        column: x => x.PostProductionPlaningId,
                        principalTable: "tbl_Postproduction_planing",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Preproduction_estimate",
                columns: table => new
                {
                    preproduction_estimate_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PreProductionId = table.Column<int>(type: "int", nullable: true),
                    SegmentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ExpenseTypeId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    Reason = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Preproduction_estimate", x => x.preproduction_estimate_id);
                    table.ForeignKey(
                        name: "FK_preproduction_estimate_commoncategory",
                        column: x => x.ExpenseTypeId,
                        principalTable: "tbl_Commoncategory",
                        principalColumn: "commonCategory_id");
                    table.ForeignKey(
                        name: "FK_preproduction_estimate_preproduction_planing",
                        column: x => x.PreProductionId,
                        principalTable: "tbl_preproduction_planing",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_preproduction_estimate_preproduction_segment",
                        column: x => x.SegmentId,
                        principalTable: "tblPreproduction_segment",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Preproductionsegment_member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PreProductionSegmentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkingHour = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    PlanMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Preproductionsegment_member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_preproductionsegment_member_preproduction_segment",
                        column: x => x.PreProductionSegmentId,
                        principalTable: "tblPreproduction_segment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_preproductionsegment_member_user",
                        column: x => x.UserId,
                        principalTable: "tbl_User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "PK_SegmentMember_PreproductionMember",
                        column: x => x.PlanMemberId,
                        principalTable: "tbl_preproductionMember",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBL_Scene",
                columns: table => new
                {
                    Scene_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PreproductionId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EditBudget = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: false),
                    PreproductionSegmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Scene", x => x.Scene_id);
                    table.ForeignKey(
                        name: "FK_Scene_PreproductionSegment",
                        column: x => x.PreproductionSegmentId,
                        principalTable: "tblPreproduction_segment",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Broadcastingdocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BroadcastingId = table.Column<int>(type: "int", nullable: false),
                    UploadPartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Broadcastingdocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_broadcastingdocument_broadcasting",
                        column: x => x.BroadcastingId,
                        principalTable: "tbl_Broadcasting",
                        principalColumn: "broadcasting_id");
                    table.ForeignKey(
                        name: "FK_broadcastingdocument_UploadPart",
                        column: x => x.UploadPartId,
                        principalTable: "tbl_UploadPart",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBL_Scene_Expense",
                columns: table => new
                {
                    Scene_expense_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SceneId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ExpenseTypeId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Scene_Expense", x => x.Scene_expense_id);
                    table.ForeignKey(
                        name: "FK_SceneExpense_Scense",
                        column: x => x.SceneId,
                        principalTable: "TBL_Scene",
                        principalColumn: "Scene_id");
                    table.ForeignKey(
                        name: "FK_TBL_Scene_Expense_tbl_Commoncategory_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "tbl_Commoncategory",
                        principalColumn: "commonCategory_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TBL_Role",
                columns: new[] { "Role_id", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Quản trị hệ thống", "Quản trị viên", 0 },
                    { 2, "Người lên ý tưởng và chỉ đạo sản xuất bộ phim", "Đạo diễn", 1 },
                    { 3, "Người quản lý các chi phí, nhân sự trong đoàn phim", "Giám đốc sản xuất", 5 },
                    { 4, "Người chịu trách nghiệm về kịch bản", "Biên kịch", 3 },
                    { 5, "Người quay phim", "Quay phim", 4 },
                    { 6, "Lãnh đạo xưởng phim", "Lãnh đạo", 2 },
                    { 7, "Người biên tập", "Biên tập viên", 6 }
                });

            migrationBuilder.InsertData(
                table: "tbl_User",
                columns: new[] { "Id", "AvatarUrl", "DepartId", "Email", "FirstName", "LastName", "PassWord", "Status", "Tel", "UserName" },
                values: new object[,]
                {
                    { 1, null, null, "admin@gmail.com", "Admin", "Admin", "123456", 1, null, "Admin" },
                    { 2, null, null, "admin@gmail.com", "abc", "abc", "123456", 1, null, "Leader" },
                    { 3, null, null, "admin@gmail.com", "abc", "abc", "123456", 1, null, "Director" },
                    { 4, null, null, "admin@gmail.com", "abc", "abc", "123456", 1, null, "Scriptor" },
                    { 5, null, null, "admin@gmail.com", "abc", "abc", "123456", 1, null, "Producer" }
                });

            migrationBuilder.InsertData(
                table: "TBL_User_role",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 2 },
                    { 2, 3 },
                    { 4, 4 },
                    { 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Broadcasting_ChannelId",
                table: "tbl_Broadcasting",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Broadcasting_PostProductionPlaningId",
                table: "tbl_Broadcasting",
                column: "PostProductionPlaningId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Broadcastingdocument_BroadcastingId",
                table: "tbl_Broadcastingdocument",
                column: "BroadcastingId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Broadcastingdocument_UploadPartId",
                table: "tbl_Broadcastingdocument",
                column: "UploadPartId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Commoncategory_ParentId",
                table: "tbl_Commoncategory",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Document_DocType",
                table: "tbl_Document",
                column: "DocType");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Document_UserId",
                table: "tbl_Document",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DocumentFile_DocumentId",
                table: "tbl_DocumentFile",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DocumentFile_UploadPartId",
                table: "tbl_DocumentFile",
                column: "UploadPartId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Estimate_CreatedBy",
                table: "tbl_Estimate",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Estimate_PreProductPlaningId",
                table: "tbl_Estimate",
                column: "PreProductPlaningId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Notify_SenderId",
                table: "tbl_Notify",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Notify_UserId",
                table: "tbl_Notify",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "FK_postproduction_planing_preproduction_planing_idx",
                table: "tbl_Postproduction_planing",
                column: "PreProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Postproduction_planing_PreProductionId",
                table: "tbl_Postproduction_planing",
                column: "PreProductionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_preproduction_estimate_preproduction_planing_idx",
                table: "tbl_Preproduction_estimate",
                column: "PreProductionId");

            migrationBuilder.CreateIndex(
                name: "FK_preproduction_estimate_preproduction_segment_idx",
                table: "tbl_Preproduction_estimate",
                column: "SegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Preproduction_estimate_ExpenseTypeId",
                table: "tbl_Preproduction_estimate",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "FK_preproduction_planing_team_idx",
                table: "tbl_preproduction_planing",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "FK_preproduction_planing_topic_idx",
                table: "tbl_preproduction_planing",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "FK_preproduction_planing_user_idx",
                table: "tbl_preproduction_planing",
                column: "ApprovedMember");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_preproduction_planing_CategoryId",
                table: "tbl_preproduction_planing",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "FK_preproduction_member_preproduction_planing_idx",
                table: "tbl_preproductionMember",
                column: "PreProductionId");

            migrationBuilder.CreateIndex(
                name: "FK_preproduction_member_user_idx",
                table: "tbl_preproductionMember",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "FK_preproductionsegment_member_preproduction_segment_idx",
                table: "tbl_Preproductionsegment_member",
                column: "PreProductionSegmentId");

            migrationBuilder.CreateIndex(
                name: "FK_preproductionsegment_member_user_idx",
                table: "tbl_Preproductionsegment_member",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Preproductionsegment_member_PlanMemberId",
                table: "tbl_Preproductionsegment_member",
                column: "PlanMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Scene_PreproductionSegmentId",
                table: "TBL_Scene",
                column: "PreproductionSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Scene_Expense_ExpenseTypeId",
                table: "TBL_Scene_Expense",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Scene_Expense_SceneId",
                table: "TBL_Scene_Expense",
                column: "SceneId");

            migrationBuilder.CreateIndex(
                name: "FK_team_user_idx",
                table: "tbl_Team",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "FK_team_member_team_idx",
                table: "tbl_Team_member",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "FK_team_member_user_idx",
                table: "tbl_Team_member",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Topic_CategoryId",
                table: "tbl_Topic",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Topic_CreatedBy",
                table: "tbl_Topic",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "FK_topic_document_topic_idx",
                table: "tbl_Topic_document",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Topic_document_UploadPartId",
                table: "tbl_Topic_document",
                column: "UploadPartId");

            migrationBuilder.CreateIndex(
                name: "FK_topic_member_topic_idx",
                table: "tbl_Topic_member",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "FK_topic_member_user_idx",
                table: "tbl_Topic_member",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "user_depart_idx",
                table: "tbl_User",
                column: "DepartId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_User_role_role_id",
                table: "TBL_User_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Video_UploadPartId",
                table: "tbl_Video",
                column: "UploadPartId");

            migrationBuilder.CreateIndex(
                name: "FK_preproduction_segment_preproduction_planing_idx",
                table: "tblPreproduction_segment",
                column: "PreProductionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Approved");

            migrationBuilder.DropTable(
                name: "tbl_Broadcastingdocument");

            migrationBuilder.DropTable(
                name: "tbl_Config");

            migrationBuilder.DropTable(
                name: "tbl_DocumentFile");

            migrationBuilder.DropTable(
                name: "tbl_Estimate");

            migrationBuilder.DropTable(
                name: "tbl_Log");

            migrationBuilder.DropTable(
                name: "tbl_Notify");

            migrationBuilder.DropTable(
                name: "tbl_Preproduction_estimate");

            migrationBuilder.DropTable(
                name: "tbl_Preproductionsegment_member");

            migrationBuilder.DropTable(
                name: "TBL_Scene_Expense");

            migrationBuilder.DropTable(
                name: "tbl_Team_member");

            migrationBuilder.DropTable(
                name: "tbl_Topic_document");

            migrationBuilder.DropTable(
                name: "tbl_Topic_member");

            migrationBuilder.DropTable(
                name: "TBL_User_role");

            migrationBuilder.DropTable(
                name: "tbl_Video");

            migrationBuilder.DropTable(
                name: "tbl_Broadcasting");

            migrationBuilder.DropTable(
                name: "tbl_Document");

            migrationBuilder.DropTable(
                name: "tbl_preproductionMember");

            migrationBuilder.DropTable(
                name: "TBL_Scene");

            migrationBuilder.DropTable(
                name: "TBL_Role");

            migrationBuilder.DropTable(
                name: "tbl_UploadPart");

            migrationBuilder.DropTable(
                name: "tbl_Postproduction_planing");

            migrationBuilder.DropTable(
                name: "tblPreproduction_segment");

            migrationBuilder.DropTable(
                name: "tbl_preproduction_planing");

            migrationBuilder.DropTable(
                name: "tbl_Team");

            migrationBuilder.DropTable(
                name: "tbl_Topic");

            migrationBuilder.DropTable(
                name: "tbl_User");

            migrationBuilder.DropTable(
                name: "tbl_Commoncategory");
        }
    }
}
