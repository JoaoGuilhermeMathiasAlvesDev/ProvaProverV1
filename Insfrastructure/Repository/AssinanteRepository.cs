using Dominio.Entity;
using Dominio.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.Repository
{
    public class AssinanteRepository : RepositoryBase<Assinante>, IAssinanteRepository
    {
        private readonly Context.Context _context;

        public AssinanteRepository(Context.Context context) : base(context) 
        {
            _context = context;
        }

        public async Task<bool> EmailJaExisteAsync(string email)
        {
            return await _context.Assinantes.AnyAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<Assinante>> ObterApenasAtivosAsync()
        {
            return await _context.Assinantes.Where(a => a.Status == true).ToListAsync();
        }
    }
}
