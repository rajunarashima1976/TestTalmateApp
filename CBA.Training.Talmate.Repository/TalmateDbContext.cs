using System;
using Microsoft.EntityFrameworkCore;
using CBA.Training.Talmate.EntityModels;

namespace CBA.Training.Talmate.Repository
{
    public class TalmateDbContext : DbContext
    {
        public TalmateDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<ResourceDetail> ResourceDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }

    }
}
