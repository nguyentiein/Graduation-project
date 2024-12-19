using FPM.Core.Database;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses.DTOs;
using FPM.Resourses.DTOs.User.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, IEnumerable<User> Data)> GetAllUserAsync()
        {
            var users = await _db.Users.Include(u => u.Depart).Include(u => u.Roles).ToListAsync();
            return(users.Count > 0,users);
        }

        public async Task<(bool HasData, IEnumerable<User> Data)> GetAllUserRemindAsync()
        {
            var users = await _db.Users.Include(u => u.PreproductionsegmentMembers).ThenInclude(p => p.PreProductionSegment).Include(ur => ur.PreproductionPlanings).ToListAsync();
            return (users.Count > 0, users);
            //var users = await _db.PreproductionSegments.Include(u => u.PreproductionsegmentMembers).ThenInclude(ur => ur.User).Include(pl => pl.PreProduction).ToListAsync();
            //return (users.Count > 0, users);
        }

        public async Task<(bool HasData, User Data)> getUserByEmail(string email)
        {
            var user = await _db.Users.Include(u => u.Depart).Include(u => u.Roles).FirstOrDefaultAsync(u => u.Email == email);
            return (user != null, user);
        }

        public async Task<(bool HasData, User Data)> GetUserById(int id)
        {
            var user = await _db.Users.Include(u => u.Depart).Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == id);
            return (user != null , user);
        }

        public async Task<(bool HasData, IEnumerable<User> Data)> getUserByUserName(string userName)
        {
            var users = await _db.Users
                .Include(u => u.Depart)
                .Include(u => u.Roles)
                .Where(u => EF.Functions.Like(u.UserName, $"%{userName}%")) 
                .ToListAsync();
            return (users.Any(), users);
        }


        public async Task<(IEnumerable<User> data, int numberRecord)> PaginationUserAsync(FilterModelRequest<FilterUserRequest> request)
        {
            var query = _db.Users.AsNoTracking().AsQueryable();

            query = query.Where(u => u.LastName.Contains(request.FilterModel.KeyResearch) || u.FirstName.Contains(request.FilterModel.KeyResearch));
      
            int count = query.Count();

            var data = await query
                        .Include(u => u.Roles)
                        .Skip((request.Page - 1) * request.PageSize)
                        .Take(request.PageSize)
                        .ToListAsync();
            return (data, count);

    }

        public async Task<(bool IsExist, User Data)> ValidateLoginAsync(string userName, string password)
        {
            var user = await _db.Users.Include(u => u.Roles).Where(u => u.UserName == userName && u.PassWord == password).FirstOrDefaultAsync();

            return (user != null,user);
        }

     
    }
}
