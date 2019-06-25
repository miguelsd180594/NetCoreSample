using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.Repository.PostgreSql.Configurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer")
                .HasKey(x => x.Id)
                .HasName("customer_id_pkey");

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName".ToLowerWithUnderdash())
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("LastName".ToLowerWithUnderdash())
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Company)
                .HasColumnName("Company".ToLowerWithUnderdash())
                .HasMaxLength(80);

            builder.Property(x => x.Address)
                .HasColumnName("Address".ToLowerWithUnderdash())
                .HasMaxLength(70);

            builder.Property(x => x.City)
                .HasColumnName("City".ToLowerWithUnderdash())
                .HasMaxLength(40);

            builder.Property(x => x.State)
                .HasColumnName("State".ToLowerWithUnderdash())
                .HasMaxLength(40);

            builder.Property(x => x.Country)
                .HasColumnName("Country".ToLowerWithUnderdash())
                .HasMaxLength(40);

            builder.Property(x => x.PostalCode)
                .HasColumnName("PostalCode".ToLowerWithUnderdash())
                .HasMaxLength(10);

            builder.Property(x => x.Phone)
                .HasColumnName("Phone".ToLowerWithUnderdash())
                .HasMaxLength(24);

            builder.Property(x => x.Fax)
                .HasColumnName("Fax".ToLowerWithUnderdash())
                .HasMaxLength(24);

            builder.Property(x => x.Email)
                .HasColumnName("Email".ToLowerWithUnderdash())
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.SupportRepId)
                .HasColumnName("SupportRepId".ToLowerWithUnderdash());

            builder.HasOne(x => x.SupportRep)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.SupportRepId)
                .HasConstraintName("customer__reference_employee__fkey");
        }
    }
}
