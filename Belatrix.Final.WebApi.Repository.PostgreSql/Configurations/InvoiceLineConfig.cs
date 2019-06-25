using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.Repository.PostgreSql.Configurations
{
    internal class InvoiceLineConfig : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.ToTable("invoice_line")
                .HasKey(x => x.InvoiceLineId)
                .HasName("invoice_line_id_pkey");

            builder.Property(x => x.InvoiceLineId)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(x => x.InvoiceId)
                .HasColumnName("InvoiceId".ToLowerWithUnderdash())
                .IsRequired();

            builder.Property(x => x.TrackId)
                .HasColumnName("TrackId".ToLowerWithUnderdash())
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .HasColumnName("UnitPrice".ToLowerWithUnderdash())
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasColumnName("Quantity".ToLowerWithUnderdash())
                .IsRequired();

            builder.HasOne(x => x.Invoice)
                .WithMany(x => x.InvoiceLines)
                .HasForeignKey(x => x.InvoiceId)
                .HasConstraintName("invoice_line__reference_invoice_id__fkey");

            builder.HasOne(x => x.Track)
                .WithMany(x => x.InvoiceLines)
                .HasForeignKey(x => x.TrackId)
                .HasConstraintName("invoice_line__reference_track_id__fkey");
        }
    }
}
