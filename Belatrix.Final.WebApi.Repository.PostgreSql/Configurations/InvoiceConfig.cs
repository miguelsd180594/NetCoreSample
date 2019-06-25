using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.Repository.PostgreSql.Configurations
{
    internal class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoice")
                .HasKey(x => x.Id)
                .HasName("invoice_id_pkey");

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .HasColumnName("CustomerId".ToLowerWithUnderdash())
                .IsRequired();

            builder.Property(x => x.InvoiceDate)
                .HasColumnName("InvoiceDate".ToLowerWithUnderdash())
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.BillingAddress)
                .HasColumnName("BillingAddress".ToLowerWithUnderdash())
                .HasMaxLength(70);

            builder.Property(x => x.BillingCity)
                .HasColumnName("BillingCity".ToLowerWithUnderdash())
                .HasMaxLength(40);

            builder.Property(x => x.BillingState)
                .HasColumnName("BillingState".ToLowerWithUnderdash())
                .HasMaxLength(40);

            builder.Property(x => x.BillingCountry)
                .HasColumnName("BillingCountry".ToLowerWithUnderdash())
                .HasMaxLength(40);

            builder.Property(x => x.BillingPostalCode)
                .HasColumnName("BillingPostalCode".ToLowerWithUnderdash())
                .HasMaxLength(10);

            builder.Property(x => x.Total)
                .HasColumnName("Total".ToLowerWithUnderdash())
                .HasColumnType("numeric(10,2)")
                .HasDefaultValueSql("0")
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.CustomerId)
                .HasConstraintName("invoice__reference_customer_id__fkey");
        }
    }
}
