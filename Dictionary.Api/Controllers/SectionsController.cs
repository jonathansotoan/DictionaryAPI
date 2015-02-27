using Dictionary.DataAccess;
using Dictionary.Model;
using System.Collections.Generic;
using System.Web.Http.Cors;
using System.Linq;
using System.Web.Http;

namespace Dictionary.Api.Controllers
{
    [EnableCors(origins: "http://localhost:51994", headers: "*", methods: "*")]
    public class SectionsController : ApiController
    {
        private DictionaryContext dictionaryContext = new DictionaryContext();

        public IEnumerable<Section> Get()
        {
            return dictionaryContext.Sections.ToList();
        }

        public Section Get(int id)
        {
            return dictionaryContext.Sections.First<Section>(section => section.ID == id);
        }
    }
}
