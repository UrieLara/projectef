using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using projectef.Models;

namespace projectef
{
    public class iTaskContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<iTask> iTasks { get; set; }

        public iTaskContext(DbContextOptions<iTaskContext> options) : base(options){

            
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){


            List<Category> categoriesInit = new List<Category>();
            categoriesInit.Add(new Category(){ CategoryId = Guid.Parse("c27fda36-f8f1-4c56-9435-64bcf01689f7"), Name = "Actividades pendientes", Weight = 20 });
               categoriesInit.Add(new Category(){ CategoryId = Guid.Parse("c27fda36-f8f1-4c56-9435-64bcf0168902"), Name = "Actividades personales", Weight = 50 });

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(p => p.CategoryId);

                category.Property(p => p.Name).IsRequired().HasMaxLength(150);
                category.Property(p => p.Description).IsRequired(false);

                category.Property(p=> p.Weight);

                category.HasData(categoriesInit);

            });


            List<iTask> tasksInit = new List<iTask>();
            
            tasksInit.Add(new iTask() { iTaskId = Guid.Parse("1e4e8aef-411f-45c6-bef0-581660f9b42c"), CategoryId =Guid.Parse("c27fda36-f8f1-4c56-9435-64bcf01689f7"), iTaskPriority = Priority.low, Title = "Revisar pago de servicios", CreationDate = DateTime.Now });
            tasksInit.Add(new iTask() { iTaskId = Guid.Parse("1e4e8aef-411f-45c6-bef0-581660f9b411"), CategoryId =Guid.Parse("c27fda36-f8f1-4c56-9435-64bcf0168902"), iTaskPriority = Priority.medium, Title = "Pagar tarjeta", CreationDate = DateTime.Now });

            modelBuilder.Entity<iTask>(task =>{

                task.ToTable("Task");
                task.HasKey(p => p.iTaskId);

                task.HasOne(p => p.Category).WithMany(p=>p.Tasks).HasForeignKey(p=>p.CategoryId);

                task.Property(p => p.Title).IsRequired().HasMaxLength(200);
                task.Property(p => p.Description).IsRequired(false);
                task.Property(p => p.iTaskPriority);
                task.Property(p => p.CreationDate);
                task.Property(p => p.AssignedPerson).IsRequired(false);

                task.Ignore(p=>p.Resume);

                task.HasData(tasksInit);

            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
}

    }
}