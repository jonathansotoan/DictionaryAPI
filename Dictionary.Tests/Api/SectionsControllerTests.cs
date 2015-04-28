using Dictionary.Api.Controllers;
using Dictionary.DataAccess;
using Dictionary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Dictionary.Tests.Api
{
    [TestClass]
    public class SectionsControllerTests
    {
        private SectionsController sectionsController;

        private MockRepository mockRepository;
        private Mock<IUnitOfWork> mockUnitOfWork;
        private Mock<IRepository<Section>> mockSectionRepository;

        [TestInitialize]
        public void SetUp()
        {
            // mocks initialization
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockUnitOfWork = mockRepository.Create<IUnitOfWork>();
            mockSectionRepository = mockRepository.Create<IRepository<Section>>();
            sectionsController = new SectionsController(mockUnitOfWork.Object);

            // mocks building
            for (int index = 0; index < DefaultObjects.Sections.Count; ++index)
            {
                DefaultObjects.Sections[index].ID = index + 1;
            }

            mockSectionRepository.Setup(sectionRepo => sectionRepo.Get(null, null, "")).Returns(DefaultObjects.Sections);
            mockUnitOfWork.Setup(unitOfWork => unitOfWork.GetRepository<Section>()).Returns(mockSectionRepository.Object);
        }

        [TestMethod]
        public void Get_ShouldReturnAllTheSections()
        {

            Assert.IsTrue(DefaultObjects.Sections.SequenceEqual(sectionsController.Get()));
        }

        [TestMethod]
        public void Get_WhenRightIdIsProvided_ShouldReturnRightSection()
        {
            for (int index = 0; index < DefaultObjects.Sections.Count; ++index)
            {
                //DefaultObjects.Sections[index].ID = index + 1;
                Assert.AreEqual(DefaultObjects.Sections[index], sectionsController.Get(index + 1));
            }
        }

        [TestMethod]
        public void Get_WhenWrongIdIsProvided_ShouldReturnNull()
        {
            Assert.IsNull(sectionsController.Get(192));
        }

        [TestCleanup]
        public void TearDown()
        {
            sectionsController = null;
        }
    }
}
