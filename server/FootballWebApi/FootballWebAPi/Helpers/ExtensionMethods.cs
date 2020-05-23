using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace FootballWebSiteApi.Helpers
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns an individual HTTP Header value
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Guid GetOwnerId(this HttpRequestHeaders headers)
        {
            IEnumerable<string> keys = null;
            if (!headers.TryGetValues("ownerid", out keys))
                throw new Exception("ownerId missing");

            return new Guid(keys.First());
        }
    }
}
