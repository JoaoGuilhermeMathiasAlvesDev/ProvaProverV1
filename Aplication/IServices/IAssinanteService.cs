using Aplication.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.IServices
{
    public interface IAssinanteService
    {
        Task<AsssinanteReponserModel> ObterPorId(Guid Id);
        Task<IEnumerable<AsssinanteReponserModel>> ObterTodosAtivos();
        Task Adicionar(AssinanteRequestModel request);
        Task Atualizar(Guid id, EditarAssinanteModel request);
        Task Desativar(Guid id);
        Task Ativar(Guid id);
    }
}
