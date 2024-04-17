using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using VirtualVisaCenter.Shared.Entities;

namespace VirtualVisaCenter.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TypeVIsa> TypeVIsas { get; set; }   
        public DbSet<Request> Requests { get; set; }
        public DbSet<Rate> Rates { get; set; }  
        public DbSet<Embassy> Embassies { get; set; }   
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Agenda> Agendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}