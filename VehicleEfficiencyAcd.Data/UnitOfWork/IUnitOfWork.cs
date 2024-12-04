using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable // -> UOW Interface for transactions and memory management with garbace collector ( I will trigger dispose manualy on some scnearios )
    {
        Task<int> SaveChangesAsync(); // -> this returns of count that as effect on data records so 'int' and Task for async

        // ▼ Transaction steps defining ▼
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollBackTransaction();

    }
}
