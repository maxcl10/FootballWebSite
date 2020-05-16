using System;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/events")]
    public class EventsController : ApiController
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsController(IEventsRepository eventsRepository)
        {
            this._eventsRepository = eventsRepository;
        }

        // GET: api/Events
        public IHttpActionResult Get(Guid gameId)
        {
            var events = _eventsRepository.GetEventsByGame(gameId);
            return Ok(events);
        }


        // POST: api/Events
        public IHttpActionResult Post([FromBody] JEvent gameEvent)
        {
            var retEvent = _eventsRepository.CreateEvent(gameEvent);
            return Created(Request.RequestUri + retEvent.EventId.ToString(), retEvent);
        }

        // PUT: api/Events/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Events/5
        public IHttpActionResult Delete(Guid id)
        {

            _eventsRepository.DeleteEvent(id);
            return Ok();

        }
    }
}
