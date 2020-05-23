using System.Web.Http;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{

    [RoutePrefix("api/authentication")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            this._authenticationRepository = authenticationRepository;
        }

        [HttpGet]
        [Route("{alias}/{password}")]
        public IHttpActionResult UserAllowed(string alias, string password)
        {
            var ownerId = Request.Headers.GetOwnerId();
            var user = Mapper.Map(_authenticationRepository.IsAuthorized(ownerId, alias, password));
            return Ok(user);
        }
    }
}
