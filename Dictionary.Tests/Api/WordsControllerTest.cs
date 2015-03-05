using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dictionary.UI.Controllers;
using Dictionary.DataAccess;
using Dictionary.Tests.Api.Mock;
using Dictionary.Model;
using System.Linq;
using System.Collections.Generic;

namespace Dictionary.Tests.Api
{
    [TestClass]
    public class WordsControllerTest
    {
        [TestMethod]
        public void Get_ShouldReturnAllTheWords()
        {
            MockUnitOfWork uow = new MockUnitOfWork();
            WordsController wordsController = new WordsController(uow);

            uow.SetRepositoryData<Word>(DefaultObjects.Words);
            uow.SetRepositoryData<Section>(DefaultObjects.Sections);

            Assert.IsTrue(DefaultObjects.Words.SequenceEqual(wordsController.Get()));
        }
    }
}
