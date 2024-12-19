using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface IPreproductionEstimateReponsitory: IGenericRepository<PreproductionEstimate>
    {
        Task<(bool HasData, IEnumerable<PreproductionEstimate> Data)> GetAllPreproductionExpenseBySegIdAsync(int id);
        Task<(bool HasData, IEnumerable<PreproductionEstimate> Data)> GetAllTeamAsync();
        //Task<(bool HasData, IEnumerable<PreproductionExpense> Data)> CreatePreproductionExpenseAsync(Team newTeam);
        //Task<(bool HasData, IEnumerable<PreproductionExpense> Data)> UpdatePreproductionExpenseAsync(Team updateRequest);
    }
}
