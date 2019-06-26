using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Belatrix.Final.WebApi
{
    public static class BelatrixFinalApiConventions
    {
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(200)]
        public static void Get()
        { }

        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public static void Get
            ([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)] [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object id)
        { }

        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public static void Post
            ([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)] [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object id)
        { }
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public static void Put
            ([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)] [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object id)
        { }

        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public static void Delete
            ([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)] [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object id)
        { }

    }
}
