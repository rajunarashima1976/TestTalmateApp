using CBA.Training.Talmate.EntityModels;
using CBA.Training.Talmate.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Services.RecommendationService
{
    public class RecommendationService : IRecommendationService
    {
        private readonly TalmateDbContext _talmateDbContext;
        public RecommendationService(TalmateDbContext talmateDbContext)
        {
            _talmateDbContext = talmateDbContext;
        }
        public async Task<IQueryable<ResourceDetail>> Seek()
        {
            var resourceDetail = _talmateDbContext.ResourceDetails.AsQueryable().OrderBy(c => c.PrimarySkills);
            return await Task.FromResult(resourceDetail);


        }

        public async Task<bool> RouteToPM(List<Recommendation> recommendation)
        {
            if (recommendation != null)
            {
                foreach (var item in recommendation)
                {
                    _talmateDbContext.Recommendations.Add(item);
                }               
                var result = _talmateDbContext.SaveChanges();
                if (result > 0)
                    return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public async Task<IQueryable<Recommendation>> Get()
        {
            var recommendation = _talmateDbContext.Recommendations.Where(x => x.IsActive == true && x.IsEnrolledForTraining == null).AsQueryable().OrderBy(c => c.PrimarySkills);
            return await Task.FromResult(recommendation);


        }

        public async Task<bool> Accept(int Id)
        {
            if (Id != 0)
            {
                var result = 0;
                var recommedation = _talmateDbContext.Recommendations.Where(x => x.Id == Id).FirstOrDefault();
                if (recommedation != null)
                {
                    recommedation.IsEnrolledForTraining = true;
                    _talmateDbContext.Entry(recommedation).State = EntityState.Modified;
                    result = _talmateDbContext.SaveChanges();
                }

                if (result > 0)
                    return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
        public async Task<bool> Reject(int Id)
        {
            if (Id != 0)
            {
                var result = 0;
                var recommedation = _talmateDbContext.Recommendations.Where(x => x.Id == Id).FirstOrDefault();
                if (recommedation != null)
                {
                    recommedation.IsEnrolledForTraining = false;
                    _talmateDbContext.Entry(recommedation).State = EntityState.Modified;
                    result = _talmateDbContext.SaveChanges();
                }

                if (result > 0)
                    return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
    }
}
