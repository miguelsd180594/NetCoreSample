using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Final.WebApi.Repository.PostgreSql.Configurations
{
    internal class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre")
                .HasKey(x => x.Id)
                .HasName("genre_id_pkey");

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name".ToLowerWithUnderdash());
        }
    }
}
