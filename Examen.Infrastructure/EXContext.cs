using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class EXContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Piste> Pistes { get; set; }
        public DbSet<Robot> Robots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                            Initial Catalog=ExamenSIM;
                                            Integrated Security=true;
                                            MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Robot - Participation: one-to-many
            modelBuilder.Entity<Participation>()
                .HasOne(p => p.Robot)
                .WithMany(r => r.Participations)
                .HasForeignKey(p => p.RobotFk);

            // Course - Participation: one-to-many
            modelBuilder.Entity<Participation>()
                .HasOne(p => p.Course)
                .WithMany(c => c.Participations)
                .HasForeignKey(p => p.CourseFk);

            modelBuilder.Entity<Participation>()
                .HasKey(p => new {p.RobotFk, p.CourseFk });

                
            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<double>()
                .HaveColumnType("float");

            base.ConfigureConventions(configurationBuilder);
        }
    }
}
