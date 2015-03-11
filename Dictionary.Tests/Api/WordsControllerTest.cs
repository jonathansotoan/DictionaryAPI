using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dictionary.UI.Controllers;
using Dictionary.DataAccess;
using Dictionary.Model;
using System.Linq;
using Moq;

namespace Dictionary.Tests.Api
{
    [TestClass]
    public class WordsControllerTest
    {
        private WordsController wordsController;

        private MockRepository mockRepository;
        private Mock<IUnitOfWork> mockUnitOfWork;
        private Mock<IRepository<Word>> mockWordRepository;

        [TestInitialize]
        public void SetUp()
        {
            // mocks initialization
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockUnitOfWork = mockRepository.Create<IUnitOfWork>();
            mockWordRepository = mockRepository.Create<IRepository<Word>>();
            mockUnitOfWork.Setup(unitOfWork => unitOfWork.GetRepository<Word>()).Returns(mockWordRepository.Object);
            
            wordsController = new WordsController(mockUnitOfWork.Object);

            for(int index = 0; index < DefaultObjects.Words.Count; ++index)
            {
                DefaultObjects.Words[index].ID = index + 1;
            }

            // mocks building
            mockUnitOfWork.Setup(unitOfWork => unitOfWork.Save());//for being able to use Strict behaviour
            mockWordRepository.Setup(wordRepo => wordRepo.Get(null, null, "")).Returns(DefaultObjects.Words);
            mockWordRepository.Setup(wordRepo => wordRepo.GetById(It.IsAny<int>()))
                .Returns<int>(id =>
                {
                    return DefaultObjects.Words.FirstOrDefault(word => word.ID == id);
                });
            mockWordRepository.Setup(wordRepo => wordRepo.Insert(It.IsAny<Word>()))
                .Returns<Word>(word =>
                {
                    DefaultObjects.Words.Add(word);
                    return word;
                });
            mockWordRepository.Setup(wordRepo => wordRepo.Update(It.IsAny<Word>()))
                .Callback<Word>(word =>
                    {
                        DefaultObjects.Words[DefaultObjects.Words.IndexOf(mockWordRepository.Object.GetById(word.ID))] = word;
                    });
            mockWordRepository.Setup(wordRepo => wordRepo.Delete(It.IsAny<int>()))
                .Callback<int>(id =>
                {
                    DefaultObjects.Words.Remove(mockWordRepository.Object.GetById(id));
                });
        }

        [TestMethod]
        public void Get_ShouldReturnAllTheWords()
        {
            Assert.IsTrue(DefaultObjects.Words.SequenceEqual(wordsController.Get()));
        }

        [TestMethod]
        public void Get_WhenRightIdIsProvided_ShouldReturnRightWord()
        {
            for (int index = 0; index < DefaultObjects.Words.Count; ++index)
            {
                Assert.AreEqual(DefaultObjects.Words[index], wordsController.Get(index + 1));
            }
        }

        [TestMethod]
        public void Get_WhenWrongIdIsProvided_ShouldReturnNull()
        {
            Assert.IsNull(wordsController.Get(192));
        }

        [TestMethod]
        public void Post_ShouldSaveWordWithIdAndSectionId()
        {
            Word newWord = new Word
            {
                ID = 20,
                Name = "Test",
                Definition = "This is a word for testing",
                SectionID = 1
            };

            wordsController.Post(newWord);

            Assert.AreEqual(newWord, wordsController.Get(20));
        }

        [TestMethod]
        public void Post_ShouldSaveWordWithIdAndWithoutSectionId()
        {
            Word newWord = new Word
            {
                ID = 21,
                Name = "Test",
                Definition = "This is a word for testing that should have sectionID as null"
            };

            wordsController.Post(newWord);
            Assert.IsNull(wordsController.Get(21).SectionID);
            Assert.AreEqual(newWord, wordsController.Get(21));
        }

        [TestMethod]
        public void Post_ShouldSaveWordWithoutIdAndWithSectionId()
        {
            Word newWord = new Word
            {
                Name = "Test",
                Definition = "This is a word for testing that should have an ID auto asigned",
                SectionID = 1
            };

            wordsController.Post(newWord);
            newWord.ID = DefaultObjects.Words.Count;
            Assert.AreEqual(newWord, wordsController.Get(newWord.ID));
        }

        [TestMethod]
        public void Post_ShouldSaveWordWithoutIdAndWithoutSectionId()
        {
            Word newWord = new Word
            {
                Name = "Test",
                Definition = "This is a word for testing that should have an ID auto asigned"
            };

            wordsController.Post(newWord);
            newWord.ID = DefaultObjects.Words.Count;
            Assert.IsNull(wordsController.Get(DefaultObjects.Words.Count).SectionID);
            Assert.AreEqual(newWord, wordsController.Get(newWord.ID));
        }

        [TestMethod]
        public void Put_ShouldBeAbleToUpdateTheNameOfAword()
        {
            Word wordToUpdate = new Word
            {
                ID = 3,
                Name = "NewName",
                Definition = DefaultObjects.Words[3].Definition,
                SectionID = DefaultObjects.Words[3].SectionID
            };

            string previousName = wordsController.Get(3).Name;
            wordsController.Put(wordToUpdate);

            Assert.AreNotEqual(previousName, wordsController.Get(3).Name);
            Assert.AreEqual(wordToUpdate, wordsController.Get(3));
        }

        [TestMethod]
        public void Put_ShouldBeAbleToUpdateTheDefinitionOfAword()
        {
            Word wordToUpdate = new Word
            {
                ID = 4,
                Name = DefaultObjects.Words[4].Name,
                Definition = "Updated definition for testing",
                SectionID = DefaultObjects.Words[4].SectionID
            };

            string previousDefinition = wordsController.Get(4).Definition;
            wordsController.Put(wordToUpdate);

            Assert.AreNotEqual(previousDefinition, wordsController.Get(4).Definition);
            Assert.AreEqual(wordToUpdate, wordsController.Get(4));
        }
        
        [TestMethod]
        public void Put_ShouldBeAbleToUpdateTheSectionIdOfAword()
        {
            Word wordToUpdate = new Word
            {
                ID = 1,
                Name = DefaultObjects.Words[4].Name,
                Definition = DefaultObjects.Words[4].Definition,
                SectionID = 3
            };

            int? previousSectionID = wordsController.Get(1).SectionID;
            wordsController.Put(wordToUpdate);

            Assert.AreNotEqual(previousSectionID, wordsController.Get(1).SectionID);
            Assert.AreEqual(wordToUpdate, wordsController.Get(1));
        }

        [TestMethod]
        public void Delete_ShouldDeleteTheSpecifiedWord()
        {
            int previousLength = wordsController.Get().Count();
            wordsController.Delete(2);

            Assert.AreEqual(previousLength - 1, wordsController.Get().Count());
            Assert.IsNull(wordsController.Get(2));
        }

        [TestCleanup]
        public void TearDown()
        {
            // it was commented out, for it would throw an exception for every method when all the mocked methods are not used
            // (just for saving code)
            //mockRepository.VerifyAll();
        }
    }
}
