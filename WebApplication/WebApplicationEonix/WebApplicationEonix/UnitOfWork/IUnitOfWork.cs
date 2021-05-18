using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplicationEonix.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
