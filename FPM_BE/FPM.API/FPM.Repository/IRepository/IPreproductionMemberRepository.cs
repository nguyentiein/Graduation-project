using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface IPreproductionMemberRepository : IGenericRepository<PreproductionMember>
    {
        Task<(bool HasData, IEnumerable<PreproductionMember> Data)> GetAllMemberInPreproductionAsync(int PreproductionId);

        Task<(bool HasData, PreproductionMember Data)> GetMemberByIdAsync(int Id);

        Task<(bool HasData, PreproductionMember Data)> SearchMemberAsync(int userId, int preproductionId);
    }
}
