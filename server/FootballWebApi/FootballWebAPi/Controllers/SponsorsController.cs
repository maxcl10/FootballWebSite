using System.Web.Http;
using System.Web.Http.Cors;
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

            var sponsors = _sponsorsRepository.GetSponsors();
            return Ok(sponsors);

        }

        // GET: api/Sponsors/5
        public IHttpActionResult Get(string id)
        {

            var sponsor = _sponsorsRepository.GetSponsor(id);
            return Ok(sponsor);

        }

        // POST: api/Sponsors
        public IHttpActionResult Post([FromBody]JSponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                var sponsors = _sponsorsRepository.CreateSponsor(sponsor);
                return Ok(sponsors);
            }
            return BadRequest(ModelState);
        }



        // PUT: api/Sponsors/5
        public IHttpActionResult Put(string id, [FromBody]JSponsor sponsor)
        {
            if (ModelState.IsValid)
            {

                var ret = _sponsorsRepository.UpdateSponsor(id, sponsor);
                return Ok(ret);

            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Sponsors/5
        public IHttpActionResult Delete(string id)
        {

            _sponsorsRepository.DeleteSponsor(id);
            return Ok(true);

        }
    }
}
