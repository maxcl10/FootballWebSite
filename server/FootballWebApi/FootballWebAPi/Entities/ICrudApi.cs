using System.Web.Http;

namespace FootballWebSiteApi.Models
{
    public interface ICrudApi<T>
    {
        IHttpActionResult Get();
        IHttpActionResult Get(string id);
        IHttpActionResult Post([FromBody]T value);
        IHttpActionResult Put(string id, [FromBody]T value);
        IHttpActionResult Delete(string id);
    }
}
