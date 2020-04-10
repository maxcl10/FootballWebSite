using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FootballWebSiteApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class EventsController : ApiController
    {
        // GET: api/Events
        public IHttpActionResult Get(Guid gameId)
        {
            using (EventsRepository repository = new EventsRepository())
            {
                var events = repository.GetEventsByGame(gameId);
                return Ok(events);
            }
        }

        // GET: api/Events/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Events
        public IHttpActionResult Post([FromBody] JEvent gameEvent)
        {
            using (EventsRepository repository = new EventsRepository())
            {
                var retEvent = repository.CreateEvent(gameEvent);
                return Created<JEvent>(Request.RequestUri + retEvent.eventId.ToString(), retEvent);
            }
        }

        // PUT: api/Events/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Events/5
        public IHttpActionResult Delete(Guid id)
        {
            using (EventsRepository repository = new EventsRepository())
            {
                repository.DeleteEvent(id);
                return Ok();
            }
        }
    }
}
