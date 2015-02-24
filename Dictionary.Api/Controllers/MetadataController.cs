using Breeze.ContextProvider.EF6;
using Dictionary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Dictionary.Api.Controllers
{
    [EnableCors(origins: "http://localhost:51994", headers: "*", methods: "*")]
    public class MetadataController : ApiController
    {
        public string Get()
        {
            var contextProvider = new EFContextProvider<DictionaryContext>();
            return contextProvider.Metadata();
        }
    }
}
