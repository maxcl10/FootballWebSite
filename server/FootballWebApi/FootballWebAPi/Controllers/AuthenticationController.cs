using FootballWebSiteApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Helpers;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class AuthenticationController : ApiController
    {
        [HttpGet]
        [Route("api/authentication/{alias}/{password}")]
        public IHttpActionResult UserAllowed(string alias, string password)
        {
            using (AuthenticationRepository repository = new AuthenticationRepository())
            {
                var user = Mapper.Map(repository.IsAuthorized(alias, password));
                return Json(user);
            }
        }
    }
}
