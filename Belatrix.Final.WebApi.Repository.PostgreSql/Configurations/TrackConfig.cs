using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.Repository.PostgreSql.Configurations
{
    internal class TrackConfig : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("track")
                .HasKey(x => x.Id)
                .HasName("track_id_pkey");

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name".ToLowerWithUnderdash())
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(x => x.AlbumId)
                .HasColumnName("AlbumId".ToLowerWithUnderdash());

            builder.Property(x => x.MediaTypeId)
                .HasColumnName("MediaTypeId".ToLowerWithUnderdash())
                .IsRequired();

            builder.Property(x => x.GenreId)
                .HasColumnName("GenreId".ToLowerWithUnderdash());

            builder.Property(x => x.Composer)
                .HasColumnName("Composer".ToLowerWithUnderdash())
                .HasMaxLength(220);

            builder.Property(x => x.MilliSeconds)
                .HasColumnName("MilliSeconds".ToLowerWithUnderdash())
                .IsRequired();

            builder.Property(x => x.Bytes)
                .HasColumnName("Bytes".ToLowerWithUnderdash());

            builder.Property(x => x.UnitPrice)
                .HasColumnName("UnitPrice".ToLowerWithUnderdash())
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            builder.HasOne(x => x.Album)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.AlbumId)
                .HasConstraintName("track__reference_album_id_fkey");

            builder.HasOne(x => x.MediaType)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.MediaTypeId)
                .HasConstraintName("track__reference_media_type_id_fkey");

            builder.HasOne(x => x.Genre)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.GenreId)
                .HasConstraintName("track__reference_genre_id_fkey");
        }
    }
}
