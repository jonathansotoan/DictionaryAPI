using Dictionary.Model;
using System.Collections.Generic;

namespace Dictionary.DataAccess
{
    public class DictionaryInitializer : System.Data.Entity.DropCreateDatabaseAlways<DictionaryContext>
    {
        protected override void Seed(DictionaryContext context)
        {
            DefaultObjects.Sections.ForEach(section => context.Sections.Add(section));
            DefaultObjects.Words.ForEach(word => context.Words.Add(word));
            context.SaveChanges();
        }
    }
}
