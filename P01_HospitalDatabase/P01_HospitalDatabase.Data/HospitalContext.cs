using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.EntityConfiguration;
using P01_HospitalDatabase.Data.Models;
using System;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {

        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnose> Diagnose { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Visitation> Vizitations { get; set; }
        public DbSet<PatientMedicament> PatientMedicament { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*  modelBuilder.Entity<PatientMedicament>().HasKey(x => new { x.MedicamentId, x.PatientId });

              modelBuilder.Entity<PatientMedicament>().HasOne(x => x.Patient)
                  .WithMany(x => x.Prescriptions).HasForeignKey(x => x.PatientId);

              modelBuilder.Entity<PatientMedicament>().HasOne(x => x.Medicament)
                  .WithMany(x => x.Prescriptions).HasForeignKey(x =>x.MedicamentId); */

            modelBuilder.ApplyConfiguration(new PatientConfig());

            modelBuilder.ApplyConfiguration(new DiagnoseConfig());
            modelBuilder.ApplyConfiguration(new VizitationConfig());
            modelBuilder.ApplyConfiguration(new MedicamentConfig());
            modelBuilder.ApplyConfiguration(new PatientMedicamentConfig());




            base.OnModelCreating(modelBuilder);
        }
    }
}
