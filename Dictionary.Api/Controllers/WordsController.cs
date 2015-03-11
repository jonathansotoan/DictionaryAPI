using System.Web.Http;
using Dictionary.Model;
using Dictionary.DataAccess;
using System.Collections.Generic;
using System.Web.Http.Cors;

namespace Dictionary.UI.Controllers
{
    [EnableCors(origins: "http://localhost:51994", headers: "*", methods: "*")]
    public class WordsController : ApiController
    {
        private IUnitOfWork unitOfWork;

        public WordsController() : this(new UnitOfWork<DictionaryContext>()) { }

        public WordsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET api/Words/
        /*[ResponseType(typeof(Word))]
        public async Task<IHttpActionResult> Get()*/
        public IEnumerable<Word> Get()
        {
            //return this.Ok(db.Words.ToList());
            return unitOfWork.GetRepository<Word>().Get();
        }

        // GET api/Words/5
        public Word Get(int id)
        {
            return unitOfWork.GetRepository<Word>().GetById(id);
        }

        // POST api/Words
        public int Post(Word word)
        {
            int assignedId = unitOfWork.GetRepository<Word>().Insert(word).ID;
            unitOfWork.Save();
            return assignedId;
        }

        // PUT api/Words
        public void Put(Word word)
        {
            unitOfWork.GetRepository<Word>().Update(word);
            unitOfWork.Save();
        }

        // DELETE api/Words/5
        public void Delete(int id)
        {
            unitOfWork.GetRepository<Word>().Delete(id);
            unitOfWork.Save();
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
