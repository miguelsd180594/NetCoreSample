using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.Repository.PostgreSql.Configurations
{
    internal class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("artist")
                .HasKey(x => x.Id)
                .HasName("artist_id_pkey");

            builder.Property(x => x.Id)
               .HasColumnName("id")
               .UseNpgsqlIdentityColumn()
               .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("Name".ToLowerWithUnderdash())
                .HasMaxLength(120);

        }
    }
}
