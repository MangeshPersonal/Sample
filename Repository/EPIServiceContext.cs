using System;
using System.Collections.Generic;
using System.Text;
using DataModels;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EpiServiceContext:DbContext
    {
        public EpiServiceContext(DbContextOptions<EpiServiceContext> options)
            : base(options)
        { }

        public DbSet<Test> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .Property<DateTime>("CreatedOn");
            modelBuilder.Entity<Test>()
                .Property<DateTime>("ModifiedOn");
            modelBuilder.Entity<Test>()
                .Property<DateTime>("CreatedBy");
            modelBuilder.Entity<Test>()
                .Property<DateTime>("ModifledBy");
        }
    }
}
