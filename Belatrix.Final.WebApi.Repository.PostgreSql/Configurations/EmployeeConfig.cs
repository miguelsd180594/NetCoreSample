using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.Repository.PostgreSql.Configurations
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employee")
                .HasKey(x => x.EmployeeId)
                .HasName("employee_id_pkey");

            builder.Property(x => x.EmployeeId)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(x => x.FirstName)
               .HasColumnName("FirstName".ToLowerWithUnderdash())
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("LastName".ToLowerWithUnderdash())
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnName("Title".ToLowerWithUnderdash())
                .HasMaxLength(30);

            builder.Property(x => x.ReportsToId)
                .HasColumnName("ReportsToId".ToLowerWithUnderdash());

            builder.Property(e => e.BirthDate)
                .HasColumnName("BirthDate".ToLowerWithUnderdash())
                .HasColumnType("date");

            builder.Property(e => e.HireDate)
                .HasColumnName("HireDate".ToLowerWithUnderdash())
                .HasColumnType("date");

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
                .HasMaxLength(60);

            builder.HasOne(x => x.ReportsTo)
                .WithMany(x => x.InChargeOf)
                .HasForeignKey(x => x.ReportsToId)
                .HasConstraintName("employee__reference_employee__fkey");
        }
    }
}
