using AutoFixtureDemo.Data.Abstraction;
using AutoFixtureDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoFixtureDemo.Data
{
    public class PeopleContext : DbContext, IPeopleContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
        }
    }
}