using Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.IRepository
{
    public interface IAssinanteRepository : IRepositoryBase<Assinante>
    {
        Task<IEnumerable<Assinante>> ObterApenasAtivosAsync();
        Task<bool> EmailJaExisteAsync(string email);
    }
}
