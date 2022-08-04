using NUnit.Framework;
namespace GITBuidld.NUnitTestProject
{
    public class TranslatorTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("test words", "fr", "mots d'essai")]
        [TestCase("Hello", "fr", "Bonjour")]
        [Parallelizable(ParallelScope.All)]
        public void Test_English_To_French_Translation_For_short_string(string englishText, string translatateTo, string expectedResult)
        {
            var obj = new GITBuild.Service.Translator();
            var result = obj.Translate(englishText, translatateTo);
            Assert.AreEqual(expectedResult, result);
        }


        [Test]
        [TestCase("Farnborough International Airshow, biennial global aerospace, defence and space trade event which showcases the latest commercial and military aircraft. Manufacturers such as Airbus and Boeing are expected to display their products and announce new orders * 2020 event was held virtually after the physical show was cancelled due to the coronavirus (COVID-19) pandemic", "fr", "Farnborough International Airshow, événement commercial biennal mondial de l'aérospatiale, de la défense et de l'espace qui présente les derniers avions commerciaux et militaires.  Des fabricants tels qu'Airbus et Boeing devraient présenter leurs produits et annoncer de nouvelles commandes * L'événement 2020 a eu lieu pratiquement après l'annulation du salon physique en raison de la pandémie de coronavirus (COVID-19)")]
        [TestCase("Labour market statistics: integrated national release, including the latest data for employment, economic activity, economic inactivity, unemployment, claimant count, average earnings, productivity, unit wage costs, vacancies & labour disputes", "fr", "Statistiques sur le marché du travail : diffusion nationale intégrée, y compris les dernières données sur l'emploi, l'activité économique, l'inactivité économique, le chômage, le nombre de demandeurs, les gains moyens, la productivité, les coûts salariaux unitaires, les postes vacants")]
        [TestCase("City of London Corporation's Financial and Professional Services dinner. Chancellor Rishi Sunak and Bank of England Governor Andrew Bailey make their annual Mansion House speeches at the event hosted by the Lord Mayor of the City of London Vincent Keaveny", "fr", "Dîner des services financiers et professionnels de la City of London Corporation.  Le chancelier Rishi Sunak et le gouverneur de la Banque d'Angleterre Andrew Bailey prononcent leurs discours annuels à Mansion House lors de l'événement organisé par le lord-maire de la ville de Londres Vincent Keaveny")]
        [Parallelizable(ParallelScope.All)]
        public void Test_English_To_French_Translation_for_longer_sentence(string englishText, string translatateTo, string expectedResult)
        {
            var obj = new GITBuild.Service.Translator();
            var result = obj.Translate(englishText, translatateTo);
            Assert.AreEqual(expectedResult, result);
        }
    }
}

