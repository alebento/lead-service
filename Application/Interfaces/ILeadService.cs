using LeadsService.Application.DTOs;

public interface ILeadService
{
    Task<List<LeadDto>> GetAllLeadsAsync();
    Task<LeadDto> UpdateLeadStatusAsync(int id, LeadDto leadDto);
}
