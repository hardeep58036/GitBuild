using GITBuild.Service;
using System;
using System.Collections.Generic;

namespace GITBuild
{
    public interface IStartup
    {
        public void Start();
    }
    public class Startup : IStartup
    {
        private readonly ITranslatationService _translatationService;

        public Startup(ITranslatationService translatationService)
        {
            _translatationService = translatationService;
        }

        public void Start()
        {
            //Sample translations.
            var englishtextlist = new List<string> { "test words",
                "Farnborough International Airshow, biennial global aerospace, defence and space trade event which showcases the latest commercial and military aircraft. Manufacturers such as Airbus and Boeing are expected to display their products and announce new orders * 2020 event was held virtually after the physical show was cancelled due to the coronavirus (COVID-19) pandemic",
                "Labour market statistics: integrated national release, including the latest data for employment, economic activity, economic inactivity, unemployment, claimant count, average earnings, productivity, unit wage costs, vacancies & labour disputes",
                "City of London Corporation's Financial and Professional Services dinner. Chancellor Rishi Sunak and Bank of England Governor Andrew Bailey make their annual Mansion House speeches at the event hosted by the Lord Mayor of the City of London Vincent Keaveny"
            };

            foreach (var item in englishtextlist)
            {
                Console.WriteLine($"Input text in english :  {item}\n\nTranslated text in french :  {_translatationService.Translate(item, "fr")} \n\n");
            }

            Console.WriteLine("Enter any english text to translate to French : ");
            var EnglishTextToFrench = Console.ReadLine();
            var result = _translatationService.Translate(EnglishTextToFrench, "fr");

            Console.WriteLine($"Translated text - {result}");

            Console.ReadLine();
        }
    }
}
