using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Resourses.DTOs;
using FPM.Resourses.DTOs.Reminder;
using FPM.Resourses.DTOs.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<(IEnumerable<User> data, int numberRecord)> PaginationUserAsync(FilterModelRequest<FilterUserRequest> request);

        Task<(bool HasData,IEnumerable<User> Data)> GetAllUserAsync();

        Task<(bool IsExist,User Data)> ValidateLoginAsync(string userName, string password);

        Task<(bool HasData, User Data)> GetUserById(int id);

        Task<(bool HasData, IEnumerable<User> Data)> getUserByUserName(string userName);
        Task<(bool HasData, User Data)> getUserByEmail(string email);
        Task<(bool HasData, IEnumerable<User> Data)> GetAllUserRemindAsync();
    }
}
