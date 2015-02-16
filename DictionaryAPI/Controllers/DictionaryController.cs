using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DictionaryAPI.Models;

namespace DictionaryAPI.Controllers
{
    public class DictionaryController : ApiController
    {
        [ResponseType(typeof(Word))]
        public async Task<IHttpActionResult> Get()
        {
            Word[] words = new Word[]
            {
                new Word {
                    name = "Fancy",
                    definition = "of extra high quality or exceptional appeal"
                },
                 new Word {
                    name = "Hello",
                    definition = "Formal and informal farewell"
                },
                 new Word {
                    name = "Mouse",
                    definition = "External device for computers"
                },
                 new Word {
                    name = "Window",
                    definition = "Building artifact used to let light pass"
                }
            };

            return this.Ok(words);
        }
    }
}
