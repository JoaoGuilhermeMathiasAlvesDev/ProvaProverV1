using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IAssinanteRepository AssinanteRepository { get; }
        Task CommitAsync();
    }
}
