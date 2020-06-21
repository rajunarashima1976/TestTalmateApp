using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBA.Training.Talmate.Services.DemandService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CBA.Training.Talmate.EntityModels;
using CBA.Training.Talmate.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using CBA.Training.Talmate.Api.Filter;

namespace CBA.Training.Talmate.Api.Controllers
{
    [Route("api/demand")]
    [ApiController]
    [ServiceFilter(typeof(TalmateActionFilterAttribute))]
    public class DemandController : ControllerBase
    {
        private readonly IDemandService _demandService;
        private readonly IMapper _mapper;
        public DemandController(IDemandService demandService, IMapper mapper)
        {
            _demandService = demandService;
            _mapper = mapper;
        }        
        
        [HttpGet]
        [Authorize(Roles = "BM")]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _demandService.Get();
            return Ok(response);
        }

        
        [HttpPost]
        [Authorize(Roles = "PM")]
        public async Task<IActionResult> Post([FromBody]Demand demand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var response = await _demandService.Post(demand);
            return Ok(response);
        }
    }
}
