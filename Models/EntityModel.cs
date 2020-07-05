using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceProtocol;
using System;

namespace Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string ConnectionString = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "need4.db");
                string ConnectionString = "Data Source=C:\\Users\\Phil\\Repo\\Web-Blazor\\Models\\database.db";

                try
                {
                    optionsBuilder.UseSqlite(ConnectionString);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PERSISTED ENTITIES
            OnCreatePerson(modelBuilder.Entity<Person>());
            OnCreateService(modelBuilder.Entity<Service>());
            OnCreateServiceList(modelBuilder.Entity<ServiceList>());
            OnCreateServiceListService(modelBuilder.Entity<ServiceListService>());
            OnCreateProject(modelBuilder.Entity<ProjectRequest>());
        }


        public DbSet<Person> Person { get; set; }
        private void OnCreatePerson(EntityTypeBuilder<Person> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(r => r.Id);
            entityTypeBuilder.Property(r => r.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.HasData(
                new { Id = -1, FirstName = "Phil", LastName = "Miller", Email = "phil.miller84@gmail.com", PhoneNumber = "818-531-8197", CompanyName = "XYZ", CompanyType = "Web" }
                );
        }

        public DbSet<Service> Service { get; set; }
        protected void OnCreateService(EntityTypeBuilder<Service> e)
        {
            e.HasKey(r => r.Id);
            e.Property(r => r.Id).ValueGeneratedOnAdd();

            e.HasData(
                new { Id = -1, Description = "Consulting" },
                new { Id = -2, Description = "UX/UI Design" },
                new { Id = -3, Description = "Project Management" },
                new { Id = -4, Description = "Mobile Development" },
                new { Id = -5, Description = "Web Development" },
                new { Id = -6, Description = "Cloud Services" },
                new { Id = -7, Description = "Quality Assurance" },
                new { Id = -8, Description = "Internet Of Things" }
                );
        }
        public DbSet<ServiceList> ServiceList { get; set; }
        protected void OnCreateServiceList(EntityTypeBuilder<ServiceList> e)
        {
            e.HasKey(r => r.Id);
            e.Property(r => r.Id).ValueGeneratedOnAdd();
            e.Ignore(r => r.Services);

            e.HasData(new ServiceList { Id = -1 });
        }

        private void OnCreateServiceListService(EntityTypeBuilder<ServiceListService> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(sls => new { sls.ServiceId, sls.ServiceListId });
            entityTypeBuilder.HasOne(sls => sls.ServiceList)
                .WithMany(sl => sl.ServiceListServices)
                .HasForeignKey(sls => sls.ServiceListId);
            entityTypeBuilder.HasOne(sls => sls.Service)
                .WithMany(s => s.ServiceListServices)
                .HasForeignKey(sls => sls.ServiceId);

            entityTypeBuilder.HasData(
                new { ServiceId = -1, ServiceListId = -1 },
                new { ServiceId = -5, ServiceListId = -1 }
                );
        }

        public DbSet<ProjectRequest> ProjectRequests { get; set; }
        private void OnCreateProject(EntityTypeBuilder<ProjectRequest> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(r => r.Id);
            entityTypeBuilder.Property(r => r.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.HasData(
                new { Id = -1, PersonId = -1, ServiceListId = -1, Message = "This is a big project" }
                );
        }
      }
}

