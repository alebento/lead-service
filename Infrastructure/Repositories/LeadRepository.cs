using AutoMapper;
using LeadsService.Application.DTOs;
using LeadsService.Domain.Entities;
using LeadsService.Domain.Interfaces;
using LeadsService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LeadsService.Infrastructure.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly LeadsDbContext _context;
        private readonly IMapper _mapper;

        public LeadRepository(LeadsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LeadDto>> GetAllAsync()
        {
            var leads = await _context.Leads.ToListAsync();
            return _mapper.Map<List<LeadDto>>(leads);
        }

        public async Task<LeadDto?> GetByIdAsync(int id)
        {
            var lead = await _context.Leads.FindAsync(id);

            if (lead == null)
                return null;

            return _mapper.Map<LeadDto>(lead);
        }

        public async Task UpdateAsync(LeadDto leadDto)
        {
            var existingLead = await _context.Leads.FindAsync(leadDto.Id);
            if (existingLead == null) throw new KeyNotFoundException("Lead not found!");

            _mapper.Map(leadDto, existingLead);

            await _context.SaveChangesAsync();
        }

    }
}
