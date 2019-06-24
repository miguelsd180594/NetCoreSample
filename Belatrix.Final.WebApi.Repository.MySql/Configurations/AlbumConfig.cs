using Belatrix.Final.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.Repository.MySql.Configurations
{
    internal class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            //builder.ToTable("album")
            //    .HasKey(c => c.AlbumId)
            //    .HasName("album_id_key");

            builder.Property(e => e.AlbumId)
                .HasColumnName("album_id");

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasMaxLength(40);

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasMaxLength(40);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasMaxLength(40);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("last_name")
                .HasMaxLength(40);

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20);
        }
    }
}
