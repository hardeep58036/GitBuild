using NUnit.Framework;
using Moq;
using GITBuild.Service;

namespace GITBuidld.NUnitTestProject
{
    public class TranslatationServiceTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("test words", "fr", "mots d'essai")]
        [TestCase("Hello", "fr", "Bonjour")]
        [TestCase("any", "fr", "any")]
        [Parallelizable(ParallelScope.All)]
        public void Test_English_To_French_Translation_For_short_string(string englishText, string translatateTo, string expectedResult)
        {
            Mock<ITranslator> mockTranslator = new Mock<ITranslator>();
            mockTranslator.Setup(x => x.Translate(It.IsAny<string>(), It.IsAny<string>())).Returns(expectedResult);
            var obj = new GITBuild.Service.TranslatationService(mockTranslator.Object);
            var result = obj.Translate(englishText, translatateTo);

            mockTranslator.Verify(x => x.Translate(englishText, translatateTo), Times.Once);
            Assert.AreEqual(expectedResult, result);
        }


        [Test]
        [TestCase("", "", "")]
        [TestCase(null, "", "")]
        [Parallelizable(ParallelScope.All)]
        public void Test_English_To_French_Translation_For_when_string_is_Empty(string englishText, string translatateTo, string expectedResult)
        {
            Mock<ITranslator> mockTranslator = new Mock<ITranslator>();
            mockTranslator.Setup(x => x.Translate(It.IsAny<string>(), It.IsAny<string>())).Returns(expectedResult);
            var obj = new GITBuild.Service.TranslatationService(mockTranslator.Object);
            var result = obj.Translate(englishText, translatateTo);

            mockTranslator.Verify(x => x.Translate(englishText, translatateTo), Times.Never);
            Assert.AreEqual(expectedResult, result);
        }
    }
}