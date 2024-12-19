using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Infrastructure
{
    public interface IUnitOfWork
    {
        void SaveChange();
        Task SaveChangeAsync();
    }
}
