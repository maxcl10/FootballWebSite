using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Controllers
{
    [RoutePrefix("api/clubevents")]
    public class ClubEventsController : ApiController
    {
        private readonly IClubEventsRepository _clubEventRepository;

        public ClubEventsController(IClubEventsRepository clubEventRepository)
        {
            this._clubEventRepository = clubEventRepository;
        }

        // GET: api/ClubEvents
        [HttpGet]
        [ResponseType(typeof(IEnumerable<JClubEvent>))]
        public async Task<IHttpActionResult> GetClubEvents()
        {
            var ownerId = Request.Headers.GetOwnerId();
            return Ok(await _clubEventRepository.GetClubEvents(ownerId));
        }


        // GET: api/ClubEvents/5
        [HttpGet]
        [ResponseType(typeof(JArticle))]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetClubEvent(Guid id)
        {
            var ownerId = Request.Headers.GetOwnerId();
            var clubEvent = await _clubEventRepository.GetClubEvent(ownerId, id);

            if (clubEvent == null)
            {
                return NotFound();
            }
            return Ok(clubEvent);
        }

        // POST: api/ClubEvents
        [HttpPost]
        public IHttpActionResult CreateClubEvent([FromBody]JClubEvent clubEvent)
        {
            var ownerId = Request.Headers.GetOwnerId();
            if (ModelState.IsValid)
            {
                return Ok(_clubEventRepository.CreateClubEvent(ownerId, clubEvent));
            }

            return BadRequest(ModelState);
        }

        // PUT: api/ClubEvents/5
        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> UpdateClubEvent(Guid id, [FromBody]JClubEvent clubEvent)
        {
            var ownerId = Request.Headers.GetOwnerId();
            if (ModelState.IsValid)
            {
                var retArticle = await _clubEventRepository.UpdateClubEvent(ownerId, id, clubEvent);
                return Ok(retArticle);
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/ClubEvents/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var ownerId = Request.Headers.GetOwnerId();
            await _clubEventRepository.DeleteClubEvent(ownerId, id);
            return Ok();
        }
    }
}
