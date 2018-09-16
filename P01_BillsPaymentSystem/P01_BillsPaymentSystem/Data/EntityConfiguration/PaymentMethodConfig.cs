using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Enums;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.EntityConfiguration
{
    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasIndex(x => new
            {
                x.BankAccountId,
                x.CreditCardId,
                x.UserId
            }).IsUnique();

            builder.Property(x=>x.Type).HasConversion(
            v => v.ToString(),
            v => (PaymentMethodType)Enum.Parse(typeof(PaymentMethodType), v));
        }
    }
}
