using Dictionary.Api.Controllers;
using Dictionary.DataAccess;
using Dictionary.Model;
using Dictionary.Tests.Api.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Tests.Api
{
    [TestClass]
    public class SectionsControllerTests
    {
        private MockUnitOfWork unitOfWork;
        private SectionsController sectionsController;

        [TestInitialize]
        public void SetUp()
        {
            unitOfWork = new MockUnitOfWork();
            sectionsController = new SectionsController(unitOfWork);

            unitOfWork.SetRepositoryData<Section>(DefaultObjects.Sections);
        }

        [TestMethod]
        public void Get_ShouldReturnAllTheSections()
        {
            Assert.IsTrue(DefaultObjects.Sections.SequenceEqual(sectionsController.Get()));
        }

        [TestMethod]
        public void GetById_ShouldReturnRightSection()
        {
            for (int index = 0; index < DefaultObjects.Sections.Count; ++index)
            {
                DefaultObjects.Sections[index].ID = index + 1;
                Assert.AreEqual(DefaultObjects.Sections[index], sectionsController.Get(index + 1));
            }
        }

        [TestMethod]
        public void GetById_ShouldReturnNullWhenTheSectionDoesNotExist()
        {
            Assert.IsNull(sectionsController.Get(192));
        }

        [TestCleanup]
        public void TearDown()
        {
            unitOfWork = null;
            sectionsController = null;
        }
    }
}
