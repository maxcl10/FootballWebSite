using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interface;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/sponsors")]
    public class SponsorsController : ApiController
    {
        private readonly ISponsorsRepository _sponsorsRepository;

        public SponsorsController(ISponsorsRepository sponsorsRepository)
        {
            this._sponsorsRepository = sponsorsRepository;
        }

        // GET: api/Sponsors
        public IHttpActionResult Get()
        {
            var ownerId = Request.Headers.GetOwnerId();
            var sponsors = _sponsorsRepository.GetSponsors(ownerId);
            return Ok(sponsors);

        }

        // GET: api/Sponsors/5
        public IHttpActionResult Get(string id)
        {
            var ownerId = Request.Headers.GetOwnerId();
            var sponsor = _sponsorsRepository.GetSponsor(ownerId, id);
            return Ok(sponsor);

        }

        // POST: api/Sponsors
        public IHttpActionResult Post([FromBody]JSponsor sponsor)
        {
            var ownerId = Request.Headers.GetOwnerId();
            if (ModelState.IsValid)
            {
                var sponsors = _sponsorsRepository.CreateSponsor(ownerId, sponsor);
                return Ok(sponsors);
            }
            return BadRequest(ModelState);
        }



        // PUT: api/Sponsors/5
        public IHttpActionResult Put(string id, [FromBody]JSponsor sponsor)
        {
            var ownerId = Request.Headers.GetOwnerId();
            if (ModelState.IsValid)
            {

                var ret = _sponsorsRepository.UpdateSponsor(ownerId, id, sponsor);
                return Ok(ret);

            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Sponsors/5
        public IHttpActionResult Delete(string id)
        {
            var ownerId = Request.Headers.GetOwnerId();
            _sponsorsRepository.DeleteSponsor(ownerId, id);
            return Ok(true);

        }
    }
}
