using AutoMapper;
using LeadsService.Application.DTOs;
using LeadsService.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeadsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly LeadService _leadService;

        public LeadsController(LeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeadDto>>> GetLeads()
        {
            return Ok(await _leadService.GetAllLeadsAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LeadDto>> UpdateLeadStatus(int id, [FromBody] LeadDto leadDto)
        {
            var result = await _leadService.UpdateLeadStatusAsync(id, leadDto);
            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
