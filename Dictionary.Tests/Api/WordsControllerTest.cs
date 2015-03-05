using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dictionary.UI.Controllers;
using Dictionary.DataAccess;
using Dictionary.Tests.Api.Mock;
using Dictionary.Model;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Dictionary.Tests.Api
{
    [TestClass]
    public class WordsControllerTest
    {
        private MockUnitOfWork unitOfWork;
        private WordsController wordsController;

        [TestInitialize]
        public void SetUp()
        {
            unitOfWork = new MockUnitOfWork();
            wordsController = new WordsController(unitOfWork);

            unitOfWork.SetRepositoryData<Word>(DefaultObjects.Words);
            unitOfWork.SetRepositoryData<Section>(DefaultObjects.Sections);
        }

        [TestMethod]
        public void Get_ShouldReturnAllTheWords()
        {
            Assert.IsTrue(DefaultObjects.Words.SequenceEqual(wordsController.Get()));
        }

        [TestMethod]
        public void GetById_ShouldReturnRightWord()
        {
            for (int index = 0; index < DefaultObjects.Words.Count; ++index)
            {
                DefaultObjects.Words[index].ID = index + 1;
                Assert.AreEqual(DefaultObjects.Words[index], wordsController.Get(index + 1));
            }
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

        [TestCleanup]
        public void TearDown()
        {
            unitOfWork = null;
            wordsController = null;
        }
    }
}
