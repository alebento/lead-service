using AutoMapper;
using LeadsService.Application.DTOs;
using LeadsService.Domain.Entities;

public class LeadProfile : Profile
{
    public LeadProfile()
    {
        CreateMap<DbLead, LeadDto>().ReverseMap();
    }
}