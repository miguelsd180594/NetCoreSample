using Belatrix.Final.WebApi.Repository.PostgreSql;
using GenFu;

namespace Belatrix.Final.WebApi.Tests.Builder.Data
{
    public partial class BelatrixFinalDbContextBuilder
    {
        public BelatrixFinalDbContextBuilder AddTenAlbums()
        {
            AddAlbums(_context, 10);
            return this;
        }
        private void AddAlbums(BelatrixFinalDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].Id = i;
            }

            _context.AddRange(albumList);
            _context.SaveChanges();
        }
    }
}
