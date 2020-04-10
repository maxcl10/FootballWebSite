using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class SponsorsController : ApiController
    {
        // GET: api/Sponsors
        public IHttpActionResult Get()
        {
            using (SponsorsRepository repository = new SponsorsRepository())
            {
                var sponsors = repository.Get();
                return Json(sponsors);
            }
        }

        // GET: api/Sponsors/5
        public IHttpActionResult Get(string id)
        {
            using (SponsorsRepository repository = new SponsorsRepository())
            {
                var sponsor = repository.Get(id);
                return Json(sponsor);
            }
        }

        // POST: api/Sponsors
        public IHttpActionResult Post([FromBody]JSponsor sponsor)
        {
            using (SponsorsRepository repository = new SponsorsRepository())
            {
                var sponsors = repository.Post(sponsor);
                return Json(sponsors);
            }
        }



        // PUT: api/Sponsors/5
        public IHttpActionResult Put(string id, [FromBody]JSponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                using (SponsorsRepository repository = new SponsorsRepository())
                {

                    var ret = repository.Put(id, sponsor);
                    return Json(ret);
                }
            }
            return null;
        }

        // DELETE: api/Sponsors/5
        public IHttpActionResult Delete(string id)
        {
            using (SponsorsRepository repository = new SponsorsRepository())
            {
                repository.Delete(id);
                return Json(true);
            }
        }
    }
}
