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
        private IWordRepository wordRepository;

        public WordsController()
        {
            wordRepository = new WordRepository(new DictionaryContext());
        }

        // GET api/Words/
        /*[ResponseType(typeof(Word))]
        public async Task<IHttpActionResult> Get()*/
        public IEnumerable<Word> Get()
        {
            //return this.Ok(db.Words.ToList());
            return wordRepository.GetWords();
        }

        // GET api/Words/5
        public Word Get(int id)
        {
            return wordRepository.GetWordById(id);
        }

        // POST api/Words
        public int Post(Word word)
        {
            int assignedId = wordRepository.InsertWord(word);
            wordRepository.Save();
            return assignedId;
        }

        // PUT api/Words
        public void Put(Word word)
        {
            wordRepository.UpdateWord(word);
            wordRepository.Save();
        }

        // DELETE api/Words/5
        public void Delete(int id)
        {
            wordRepository.DeleteWord(id);
            wordRepository.Save();
        }
    }
}
