using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.EntityConfiguration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email).IsUnicode(false);
            builder.Property(x => x.Password).IsUnicode(false);

        }
    }


}
