using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;
using FootballWebSiteApi.Repository;

namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/games/events")]
    public class EventsController : ApiController
    {
        private readonly IGameEventsRepository _eventsRepository;

        public EventsController(IGameEventsRepository eventsRepository)
        {
            this._eventsRepository = eventsRepository;
        }

        [Route("~/api/games/{gameId}/events")]
        // GET: api/Events
        public IHttpActionResult Get(Guid gameId)
        {
            var events = _eventsRepository.GetEventsByGame(gameId);
            return Ok(events);
        }

        [HttpGet]
        [Route("~/api/eventTypes")]
        public IHttpActionResult GetGameEventTypes()
        {
            var games = _eventsRepository.GetGameEventTypes();
            return Ok(games);
        }

        // POST: api/Events
        public IHttpActionResult Post([FromBody] JGameEvent gameEvent)
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
