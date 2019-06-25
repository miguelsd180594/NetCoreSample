using Belatrix.Final.WebApi.Repository.PostgreSql;
using Microsoft.EntityFrameworkCore;
using System;

namespace Belatrix.Final.WebApi.Tests.Builder.Data
{
    public partial class BelatrixFinalDbContextBuilder : IDisposable
    {
        private BelatrixFinalDbContext _context;
        public BelatrixFinalDbContextBuilder ConfigureInMemory()
        {
            var options = new DbContextOptionsBuilder<BelatrixFinalDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new BelatrixFinalDbContext(options);
            return this;
        }

        public BelatrixFinalDbContext Build()
        {
            return _context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
