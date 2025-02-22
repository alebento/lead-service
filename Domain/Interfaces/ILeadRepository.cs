using LeadsService.Application.DTOs;

namespace LeadsService.Domain.Interfaces
{
    public interface ILeadRepository
    {
        Task<List<LeadDto>> GetAllAsync();
        Task<LeadDto?> GetByIdAsync(int id);
        Task UpdateAsync(LeadDto lead);
    }
}
