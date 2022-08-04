using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace GITBuild.Service
{
    public interface ITranslator
    {
        public string Translate(string input, string destinationLanguage);
        public string Translate(string input, string sourceLanguage, string destinationLanguage);
    }

    /// <summary>
    /// This is just an free service used to translate. Here we can use some better paid service for translations. 
    /// And then url and other keys can be made configurable in config file. 
    /// For the sake of demo url is hard coded and code is tightly coupled in this class.
    /// </summary>
    public class Translator : ITranslator
    {
        public string Translate(string input, string destinationLanguage)
        {
            //Set Deafult source language to english
            return Translate(input, "en", destinationLanguage);
        }

        public string Translate(string input, string sourceLanguage, string destinationLanguage)
        {
            if (!IsLanguageSupported(sourceLanguage)) return $"Translation from {sourceLanguage} not supported";
            if (!IsLanguageSupported(destinationLanguage)) return $"Translation to {destinationLanguage} not supported";

            // Set the language from/to in the url (or pass it into this function)
            string url = String.Format
            ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
             sourceLanguage, destinationLanguage, Uri.EscapeUriString(input));
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;
            // Get all json data
            List<dynamic> jsonData = JsonConvert.DeserializeObject<List<dynamic>>(result);


            //var jsonData = new JsonConvert.DeserializeObject(List<dynamic>>(result);

            // Extract just the first array element (This is the only data we are interested in)
            var translationItems = jsonData[0];

            // Translation Data
            string translation = "";

            // Loop through the collection extracting the translated objects
            foreach (object item in translationItems)
            {
                // Convert the item array to IEnumerable
                IEnumerable translationLineObject = item as IEnumerable;

                // Convert the IEnumerable translationLineObject to a IEnumerator
                IEnumerator translationLineString = translationLineObject.GetEnumerator();

                // Get first object in IEnumerator
                translationLineString.MoveNext();

                // Save its value (translated text)
                translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
            }

            // Remove first blank character
            if (translation.Length > 1) { translation = translation.Substring(1); };

            // Return translation
            return translation;

        }

        private bool IsLanguageSupported(string langAbbr)
        {
             Dictionary<string, string> My_dict1 = new Dictionary<string, string>(){
                                  {"en","English"},
                                  {"fr","French" },
                                  {"ja","Japanese" },
                                  {"de","German" } };

            if (My_dict1.ContainsKey(langAbbr)) return true;

            return false;
        }
    }
}
