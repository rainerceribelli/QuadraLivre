using Microsoft.EntityFrameworkCore;
using QuadraManagementService.ApplicationServices.Contracts;
using QuadraManagementService.Crosscutting.DTO;
using QuadraManagementService.Entities;
using QuadraManagementService.Infrastructure.Repositories.Contracts;
using System.Collections.Generic;

namespace QuadraManagementService.ApplicationServices
{
    public class QuadrasApplicationServices : IQuadrasApplicationServices
    {
        private readonly IQuadrasRepository _quadrasRepository;

        public QuadrasApplicationServices(IQuadrasRepository quadrasRepository)
        {
            _quadrasRepository = quadrasRepository;
        }

        #region Query
        private IQueryable<QuadraDTO> GetQueryQuadras()
        {
            IQueryable<Quadras> queryQuadras = _quadrasRepository.GetAllReadOnly();

            IQueryable<QuadraDTO> query = (from Quadra in queryQuadras
                                           select new QuadraDTO
                                           {
                                               Id = Quadra.Id,
                                               Nome = Quadra.Nome,
                                               Localizacao = Quadra.Localizacao,
                                               Tipo = Quadra.Tipo,
                                               DtCriacao = Quadra.DtCriacao,
                                               DtUltimaAlteracao = Quadra.DtUltimaAlteracao,
                                               BitAtivo = Quadra.BitAtivo,
                                           });
            return query;
        }

        #endregion

        public async Task<List<QuadraDTO>> GetAllQuadras()
        {
            List<QuadraDTO> Quadra = await GetQueryQuadras().ToListAsync();

            return Quadra;
        }

        public async Task<QuadraDTO> GetQuadraById(int id)
        {

            QuadraDTO Quadra = await GetQueryQuadras().Where(x => x.Id == id).FirstOrDefaultAsync();

            return Quadra;
        }

        public async Task CreateQuadra(QuadraDTO QuadraCreate)
        {
            Quadras quadra = new Quadras(QuadraCreate.Nome, QuadraCreate.Localizacao, QuadraCreate.Tipo);

            await _quadrasRepository.AddAsync(quadra);
            await _quadrasRepository.CommitAsync();
        }

        public async Task UpdateQuadra(int id, QuadraDTO QuadraUpdate)
        {
            var quadra = await _quadrasRepository.GetByIdAsync(id);

            if (quadra == null)
                throw new ArgumentException("Quadra não encontrada.");

            quadra.AtualizarInformacoes(QuadraUpdate.Nome, QuadraUpdate.Localizacao, QuadraUpdate.Tipo);

            await _quadrasRepository.CommitAsync();
        }

        public void DeleteQuadra(int id)
        {
            throw new NotImplementedException();
        }
    }
}
