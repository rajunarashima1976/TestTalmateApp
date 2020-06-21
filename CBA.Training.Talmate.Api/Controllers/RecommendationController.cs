using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CBA.Training.Talmate.Api.Filter;
using CBA.Training.Talmate.EntityModels;
using CBA.Training.Talmate.Services.RecommendationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CBA.Training.Talmate.Api.Controllers
{
    [Route("api/recommendation/")]
    [ApiController]
    [ServiceFilter(typeof(TalmateActionFilterAttribute))]
    public class RecommendationController : Controller
    {


        private readonly IRecommendationService _recommendationService;
        private readonly IMapper _mapper;

        public RecommendationController(IRecommendationService recommendationService, IMapper mapper)
        {
            _recommendationService = recommendationService;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize(Roles = "BM")]
        [Route("seek")]
        public async Task<IActionResult> Seek()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _recommendationService.Seek();
            return Ok(response);
        }
        [HttpPost("routerecommendation")]
        [Authorize(Roles = "BM")]
        public async Task<IActionResult> RouteToPM([FromBody]List<Recommendation> recommendation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _recommendationService.RouteToPM(recommendation);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "PM")]        
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _recommendationService.Get();
            return Ok(response);
        }
        [HttpPost("accept")]
        [Authorize(Roles = "PM")]
        public async Task<IActionResult> Accept([FromBody]int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _recommendationService.Accept(Id);
            return Ok(response);
        }

        [HttpPost("reject")]
        [Authorize(Roles = "PM")]
        public async Task<IActionResult> Reject([FromBody]int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _recommendationService.Reject(Id);
            return Ok(response);
        }
    }
}