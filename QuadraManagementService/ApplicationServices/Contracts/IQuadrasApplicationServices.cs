using QuadraManagementService.Crosscutting.DTO;
using QuadraManagementService.Entities;

namespace QuadraManagementService.ApplicationServices.Contracts
{
    public interface IQuadrasApplicationServices
    {
        Task<List<QuadraDTO>> GetAllQuadras();

        Task<QuadraDTO> GetQuadraById(int id);

        Task CreateQuadra(QuadraDTO QuadraCreate);
        
        Task UpdateQuadra(int id, QuadraDTO QuadraUpdate);
        
        void DeleteQuadra(int id);
    }
}
