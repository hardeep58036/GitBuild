namespace GITBuild.Service
{
    public interface ITranslatationService
    {
        public string Translate(string textToConvert, string v);
    }
    public class TranslatationService : ITranslatationService
    {
        private readonly ITranslator _translator;

        public TranslatationService(ITranslator translator)
        {
            _translator = translator;
        }
        public string Translate(string textToConvert, string v)
        {
            if (string.IsNullOrEmpty(textToConvert)) return "";
            return _translator.Translate(textToConvert, v);
        }
    }
}
