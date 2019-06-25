using Belatrix.Final.WebApi.Controllers;
using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository.PostgreSql;
using Belatrix.Final.WebApi.Tests.Builder.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Belatrix.Final.WebApi.Tests
{
    public class AlbumControllerTest
    {
        private readonly BelatrixFinalDbContextBuilder _builder;

        public AlbumControllerTest()
        {
            _builder = new BelatrixFinalDbContextBuilder();
        }

        [Fact]
        public async Task AlbumController_GetAlbum_Ok()
        {
            var db = _builder
                .ConfigureInMemory()
                .AddTenAlbums()
                .Build();

            var repository = new GenericRepository<Album>(db);
            var controller = new AlbumController(repository);

            var response = (await controller.GetAlbums()).Result as OkObjectResult;

            var values = response.Value as List<Album>;

            values.Count.Should().Be(10);
        }
    }
}
