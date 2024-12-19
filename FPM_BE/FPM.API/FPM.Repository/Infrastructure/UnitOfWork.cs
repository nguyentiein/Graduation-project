using FPM.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FPMContext context;

        public UnitOfWork(FPMContext context = null)
        {
            this.context = context ?? new FPMContext();
        }

        private bool disposed = false;

        public void SaveChange()
        {
            context.SaveChanges();
        }
        public async Task SaveChangeAsync()
        {
            await context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
