using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace EF
{
    public class EF
    {
        private class Db : DbContext
        {
            public virtual DbSet<ComEnity> ComEnities { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuiler)
            {
                optionsBuiler.UseSqlServer(@"Server=(local);Database=Nutsheel;Trusted_Connection=True");
            }

            protected override void OnModelCreating(ModelBuilder model)
            {
                model.Entity<ComEnity>().ToTable("ComEnity").HasKey(c => c.Id);
            }

            public Db(DbContextOptions<Db> options) : base(options)
            {

            }
        }


        public class ComEnity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
        }
    }
}