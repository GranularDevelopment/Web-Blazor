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
                string ConnectionString = "Data Source=C:\\Users\\Phil\\Repo\\Serverside\\Models\\database.db";

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
            OnCreateProject(modelBuilder.Entity<ProjectRequest>());
        }
        public DbSet<Person> Person { get; set; }
        private void OnCreatePerson(EntityTypeBuilder<Person> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(r => r.Id);
            entityTypeBuilder.Property(r => r.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.HasData(
                new { Id = -1, FirstName = "Phil" }
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
            var dat = new ServiceList { Id = -1 };
            dat.Services.Add(new Service { Id = -1 });
            dat.Services.Add(new Service { Id = -5 });
            e.HasData(dat);
        }
        protected void OnCreateServiceList_Service(EntityTypeBuilder<ServiceList_Service> e)
        {
            e.HasKey(t => new { t.ServiceId, t.ServiceListId });
            e.HasOne(ili => ili.Service)
                .WithMany(i => i.Joins)
                .HasForeignKey(ili => ili.ServiceListId);
            e.HasOne(ili => ili.ServiceList)
                .WithMany(il => il.Joins)
                .HasForeignKey(ili => ili.ServiceId);
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

