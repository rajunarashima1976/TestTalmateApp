using CBA.Training.Talmate.EntityModels;
using CBA.Training.Talmate.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Services.DemandService
{
    public class DemandService : IDemandService
    {
        private readonly TalmateDbContext _talmateDbContext;
        public DemandService(TalmateDbContext talmateDbContext)
        {
            _talmateDbContext = talmateDbContext;
        }
        public async Task<IQueryable<Demand>> Get()
        {
            var demand = _talmateDbContext.Demands.AsQueryable().OrderBy(c => c.PrimarySkills);
            return await Task.FromResult(demand);


        }

        public async Task<bool> Post(Demand demand)
        {
            if (demand != null)
            {
                _talmateDbContext.Demands.Add(demand);
                var result = _talmateDbContext.SaveChanges();
                if(result > 0)
                    return await Task.FromResult(true);
            }
           
            return await Task.FromResult(false);
        }
    }
}
