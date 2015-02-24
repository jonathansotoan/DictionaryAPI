using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Dictionary.Model;
using Dictionary.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;

namespace Dictionary.UI.Controllers
{
    [EnableCors(origins: "http://localhost:51994", headers: "*", methods: "*")]
    public class WordsController : ApiController
    {
        private DictionaryContext dictionaryContext = new DictionaryContext();

        // GET api/Dictionary/
        /*[ResponseType(typeof(Word))]
        public async Task<IHttpActionResult> Get()*/
        public IEnumerable<Word> Get()
        {
            //return this.Ok(db.Words.ToList());
            return dictionaryContext.Words.ToList();
        }

        // GET api/Dictionary/5
        public Word Get(int id)
        {
            return dictionaryContext.Words.First<Word>(word => word.ID == id);
        }

        // POST api/Dictionary
        public int Post(Word word)
        {
            dictionaryContext.Words.Add(word);
            dictionaryContext.SaveChanges();

            return word.ID;
        }

        // PUT api/Dictionary
        public void Put(Word word)
        {
            dictionaryContext.Words.Add(word);
            dictionaryContext.Entry(word).State = System.Data.Entity.EntityState.Modified;
            dictionaryContext.SaveChanges();
        }

        // DELETE api/Dictionary/5
        public void Delete(int id)
        {
            dictionaryContext.Words.Remove(dictionaryContext.Words.Find(id));
            dictionaryContext.SaveChanges();
        }
    }
}
