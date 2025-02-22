using AutoMapper;
using LeadsService.Application.DTOs;
using LeadsService.Domain.Interfaces;

namespace LeadsService.Application.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;
        private readonly FakeEmailService? _emailService;

        public LeadService(ILeadRepository leadRepository, IMapper mapper, FakeEmailService emailService)
        {
            _leadRepository = leadRepository ?? throw new ArgumentNullException(nameof(leadRepository));
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<List<LeadDto>> GetAllLeadsAsync()
        {
            var leads = await _leadRepository.GetAllAsync();
            return _mapper.Map<List<LeadDto>>(leads);
        }

        public async Task<LeadDto> UpdateLeadStatusAsync(int id, LeadDto leadDto)
        {
            var lead = await _leadRepository.GetByIdAsync(id);
            if (lead == null) throw new KeyNotFoundException("Lead not found!"); ;

            lead.Status = leadDto.Status;

            if (lead.Status == "Accepted")
            {
                if (lead.Price > 500)
                {
                    lead.Price *= 0.9m;
                }
                _emailService?.SendEmail("test@example.com", "Lead Accepted", $"New lead {lead.ContactFullName} was successfully accepted. Lead value: {lead.Price}");
            }

            await _leadRepository.UpdateAsync(lead);
            return _mapper.Map<LeadDto>(lead);
        }
    }
}
