using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/owner")]
    public class OwnerController : ApiController
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            this._ownerRepository = ownerRepository;
        }

        // GET: api/Owner
        public IHttpActionResult Get()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var owner = _ownerRepository.GetOwner(ownerId);
            return Ok(owner);

        }

    }
}
