using CBA.Training.Talmate.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Services.DemandService
{
    public interface IDemandService
    {
        Task<IQueryable<Demand>> Get();
        Task<bool> Post(Demand demand);
    }
}
