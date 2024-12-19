using FPM.Core.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Property
        protected readonly FPMContext _db;
        protected readonly DbSet<TEntity> _dbSet;
        #endregion

        #region Constructor
        public GenericRepository(FPMContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }
        #endregion

        #region Method
        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<(bool HasData, TEntity Data)> FindAsync(int id)
        {
            var response = await _dbSet.FindAsync(id);
            return (response != null, response);
        }
        public async Task InsertAsync(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
        }
        public void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }
        public void Delete(TEntity obj)
        {
            _dbSet.Remove(obj);
        }

        public void DeleteById(int id)
        {
            var obj = _dbSet.Find(id);
            _dbSet.Remove(obj);
        }

        public int CountAll()
        {
            return _dbSet.Count();
        }

        #endregion


    }
}
