using Aplication.IServices;
using Aplication.model;
using Dominio.Entity;
using Dominio.IRepository;

namespace Aplication
{
    public class AssinanteServices : IAssinanteService
    {
        private readonly IUnitOfWork _uow;
        
        public AssinanteServices(IAssinanteRepository assinanteRepository, IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Adicionar(AssinanteRequestModel request)
        {
            if (await _uow.AssinanteRepository.EmailJaExisteAsync(request.Email))
                throw new Exception("Este e-mail já está cadastrado no sistema.");

            var novoAssinante = new Assinante(
                 request.Nome,
                 request.Email,
                 request.Plano,
                 request.Valor,
                 request.DataInicio
             );

            await _uow.AssinanteRepository.AddAsync(novoAssinante);

            await _uow.CommitAsync();
        }

        public async Task Ativar(Guid id)
        {
            var assinante = await _uow.AssinanteRepository.GetByIdAsync(id);
            if (assinante == null) throw new Exception("Assinante não encontrado.");

            assinante.Ativa();

            await _uow.AssinanteRepository.UpdateAsync(assinante);
            await _uow.CommitAsync();
        }

        public async Task Atualizar(Guid id, EditarAssinanteModel request)
        {
            var assinante = await _uow.AssinanteRepository.GetByIdAsync(id);

            if (assinante == null || !assinante.Status)
                throw new Exception("Assinante não encontrado ou está inativo.");

            // O método Editar já deve validar Nome e Valor internamente
            assinante.Editar(request.Nome, request.Plano, request.Valor);

            await _uow.AssinanteRepository.UpdateAsync(assinante);
            await _uow.CommitAsync();
        }

        public async Task Desativar(Guid id)
        {
            var assinante = await _uow.AssinanteRepository.GetByIdAsync(id);
            if (assinante == null) throw new Exception("Assinante não encontrado.");

            assinante.Desativa();

            await _uow.AssinanteRepository.UpdateAsync(assinante);
            await _uow.CommitAsync();
        }

        public async Task<AsssinanteReponserModel> ObterPorId(Guid id)
        {
            var assinante = await _uow.AssinanteRepository.GetByIdAsync(id);

            if (assinante == null || !assinante.Status) return null;

            return AsssinanteReponserModel.DeEntidade(assinante);
        }

        public async Task<IEnumerable<AsssinanteReponserModel>> ObterTodosAtivos()
        {
            var assinantes = await _uow.AssinanteRepository.ObterApenasAtivosAsync();

            return assinantes.Select(a => AsssinanteReponserModel.DeEntidade(a));
        }
    }
}