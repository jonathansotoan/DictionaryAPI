using Dictionary.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Dictionary.DataAccess
{
    public class WordRepository : IWordRepository, IDisposable
    {
        private DictionaryContext context;
        private bool disposed = false;

        public WordRepository(DictionaryContext context)
        {
            this.context = context;
        }

        public IEnumerable<Word> GetWords()
        {
            return context.Words;
        }

        public Word GetWordById(int wordId)
        {
            return context.Words.Find(wordId);
        }

        public int InsertWord(Word word)
        {
            context.Words.Add(word);

            return word.ID;
        }

        public void DeleteWord(int wordId)
        {
            context.Words.Remove(context.Words.Find(wordId));
        }

        public void UpdateWord(Word word)
        {
            context.Entry(word).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected void Dispose(bool disposing) {
            if(!this.disposed && disposing)
            {
                context.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
