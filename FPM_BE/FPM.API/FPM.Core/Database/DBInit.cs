using FPM.Core.Entities;
using FPM.Resourses.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Core.Database
{
    public static class DBInit
    {
        private static List<User> Users = new List<User>()
        {
            new()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@gmail.com",
                UserName = "Admin",
                PassWord = "123456",
                Status = UserEnum.Active,
            },

            new()
            {
                Id = 2,
                FirstName = "abc",
                LastName = "abc",
                Email = "admin@gmail.com",
                UserName = "Leader",
                PassWord = "123456",
                Status = UserEnum.Active,
            },

            new()
            {
                Id = 3,
                FirstName = "abc",
                LastName = "abc",
                Email = "admin@gmail.com",
                UserName = "Director",
                PassWord = "123456",
                Status = UserEnum.Active,
            },

            new()
            {
                Id = 4,
                FirstName = "abc",
                LastName = "abc",
                Email = "admin@gmail.com",
                UserName = "Scriptor",
                PassWord = "123456",
                Status = UserEnum.Active,
            },
            new()
            {
                Id = 5,
                FirstName = "abc",
                LastName = "abc",
                Email = "admin@gmail.com",
                UserName = "Producer",
                PassWord = "123456",
                Status = UserEnum.Active,
            }
        };
        private static List<UserRole> UserRoles = new List<UserRole>()
        {
            new()
            {
                UserId = 1,
                RoleId = 1
            },
            new()
            {
                UserId = 2,
                RoleId = 6
            },
            new()
            {
                UserId = 3,
                RoleId = 2
            },
            new()
            {
                UserId = 4,
                RoleId = 4
            },
            new()
            {
                UserId = 5,
                RoleId = 3
            }
        };
        private static List<Commoncategory> Province = new List<Commoncategory>()
        {
            new()
            {
                Id =1,
                Name = "Hà Nội",
                Type =CommonCategoryEnum.Province,
                Description = "Đại Từ có cảnh đẹp thiên nhiên tươi đẹp với nhiều thác nước và hồ nước. Đây là nơi du khách có thể trải nghiệm không khí yên bình của vùng nông thôn.",

            }

        };

        private static List<Commoncategory> District = new List<Commoncategory>()
        {
            new()
            {
                Id =2,
                Name = "Thuận Thành",
                Type =CommonCategoryEnum.District,
                Description = "Là một trong những huyện phát triển của tỉnh, Thuận Thành có nền kinh tế đa dạng, từ nông nghiệp đến công nghiệp.",

            }

        };

        private static List<Commoncategory> Commune = new List<Commoncategory>()
        {
            new()
            {
                Id =3,
                Name = "Tân Sơn",
                Type =CommonCategoryEnum.Commune,
                Description = "Là một trong những xã  phát triển của tỉnh,có nền kinh tế đa dạng, từ nông nghiệp đến công nghiệp.",

            }

        };

        private static List<Commoncategory> Topic = new List<Commoncategory>()
        {
            new()
            {
                Id =4,
                Name = "Lịch sử và Chính trị",
                Type =CommonCategoryEnum.Topic,
                Description = "Đây là một trong những đề tài quan trọng nhất mà hãng phim thường xuyên chọn để sản xuất. Các tác phẩm này thường tập trung vào việc khám phá và tái hiện các sự kiện lịch sử, nhân vật và giai đoạn quan trọng trong lịch sử và chính trị của Việt Nam.",

            }

        };

        private static List<Commoncategory> Outline = new List<Commoncategory>()
        {
            new()
            {
                Id =5,
                Name = "Đề cương phim về thể thao và sức khỏe",
                Type =CommonCategoryEnum.Outline,
                Description = "Phản ánh về các hoạt động thể thao và rèn luyện thể chất. Nắm bắt các vấn đề về sức khỏe cộng đồng và phòng chống bệnh tật. Tạo ra những hình ảnh và câu chuyện tôn vinh những thành tựu và nỗ lực trong lĩnh vực thể thao .",

            }

        };

        private static List<Commoncategory> FilmCategory = new List<Commoncategory>()
        {
            new()
            {
                Id =6,
                Name = "Phim tài liệu lịch sử",
                Type =CommonCategoryEnum.FilmCategory,
                Description = "Những tác phẩm này thường tập trung vào việc khám phá và tái hiện các sự kiện lịch sử, nhân vật nổi tiếng, và những giai đoạn quan trọng trong lịch sử Việt Nam.",

            }

        };

        private static List<Commoncategory> Fee = new List<Commoncategory>()
        {
            new()
            {
                Id =7,
                Name = "Thiết bị và Kỹ thuật",
                Type =CommonCategoryEnum.Fee,
                Description = "Chi phí thuê hoặc mua thiết bị quay phim, ánh sáng và âm thanh. Chi phí thuê hoặc mua các phần mềm và công cụ kỹ thuật cho quá trình sản xuất và hậu kỳ.",

            }

        };

        private static List<Role> Roles = new List<Role>()
        {
            new()
            {
                Id=1,
                Name = "Quản trị viên",
                Type = RoleEnum.Administrator,
                Description = "Quản trị hệ thống"
            },
            new()
            {
                Id = 2,
                Name = "Đạo diễn",
                Type = RoleEnum.Director,
                Description = "Người lên ý tưởng và chỉ đạo sản xuất bộ phim"
            },
            new()
            {
                Id = 3,
                Name = "Giám đốc sản xuất",
                Type = RoleEnum.Producer,
                Description = "Người quản lý các chi phí, nhân sự trong đoàn phim",
            },
            new()
            {
                Id = 4,
                Name = "Biên kịch",
                Type = RoleEnum.Scriptor,
                Description = "Người chịu trách nghiệm về kịch bản",
            },
            new()
            {
                Id = 5,
                Name = "Quay phim",
                Type = RoleEnum.Cameraman,
                Description = "Người quay phim",
            },
            new()
            {
                Id = 6,
                Name = "Lãnh đạo",
                Type = RoleEnum.Leader,
                Description = "Lãnh đạo xưởng phim",
            },
            new()
            {
                Id = 7,
                Name = "Biên tập viên",
                Type = RoleEnum.Editor,
                Description = "Người biên tập",
            }

        };

        private static List<Commoncategory> Document = new List<Commoncategory>()
        {
            new()
            {
                Id =14,
                Name = ".txt (Text File)",
                Type =CommonCategoryEnum.Document,
                Description = "Đây là loại file đơn giản chỉ chứa văn bản thuần túy, không có định dạng phức tạp như định dạng văn bản được định nghĩa bởi các ứng dụng như Microsoft Word hoặc Google Docs.",

            }

        };



        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(Users);
            modelBuilder.Entity<UserRole>().HasData(UserRoles);

            //modelBuilder.Entity<Commoncategory>().HasData(Province);
            //modelBuilder.Entity<Commoncategory>().HasData(District);

            //modelBuilder.Entity<Commoncategory>().HasData(Commune);

            //modelBuilder.Entity<Commoncategory>().HasData(Topic);

            //modelBuilder.Entity<Commoncategory>().HasData(Outline);
            //modelBuilder.Entity<Commoncategory>().HasData(FilmCategory);

            //modelBuilder.Entity<Commoncategory>().HasData(Fee);
            modelBuilder.Entity<Role>().HasData(Roles);

            //modelBuilder.Entity<Commoncategory>().HasData(Document);
        }
    }
}
