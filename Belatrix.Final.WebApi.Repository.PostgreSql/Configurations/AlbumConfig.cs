using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.Repository.PostgreSql.Configurations
{
    internal class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("album")
                .HasKey(c => c.Id)
                .HasName("album_id_pkey");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(e => e.Title)
                .HasColumnName("Title".ToLowerWithUnderdash())
                .HasMaxLength(160);

            builder.HasIndex(e => e.ArtistId)
                .HasName("album_artist_idx");

            builder.Property(e => e.ArtistId)
                .HasColumnName("ArtistId".ToLowerWithUnderdash());

            builder.HasOne(d => d.Artist)
                .WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("album__reference_artist_id__fkey");
        }
    }
}
