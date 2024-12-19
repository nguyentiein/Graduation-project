using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<(bool HasData, TEntity Data)> FindAsync(int id);
        Task InsertAsync(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void DeleteById(int id);
        int CountAll();
    }
}
