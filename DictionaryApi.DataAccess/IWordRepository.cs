using Dictionary.Model;
using System.Collections.Generic;

namespace Dictionary.DataAccess
{
    public interface IWordRepository
    {
        IEnumerable<Word> GetWords();
        Word GetWordById(int wordId);
        int InsertWord(Word word);
        void DeleteWord(int wordId);
        void UpdateWord(Word word);
        void Save();
    }
}
