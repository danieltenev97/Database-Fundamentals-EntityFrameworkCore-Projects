using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.PatientId);
            builder.Property(x => x.Email).IsUnicode(false);
         
        }
    }
}
