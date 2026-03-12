using Dominio.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.Context _context;
        public IAssinanteRepository AssinanteRepository { get; private set; }

        public UnitOfWork(Context.Context context)
        {
            _context = context;
            AssinanteRepository = new AssinanteRepository(_context);
        }


        public async Task CommitAsync()
        {
          
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
