using System.Text.Json;


namespace BlazingLocalStorage.LocalStorage
{
    public class ProgrammingLanguageService
	{
        private readonly LocalStorageService _localStorageService;

        public ProgrammingLanguageService(LocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task AddOrUpdateLanguageAsync(string languageName, ProgrammingLanguage languageToAdd)
        {
            var jsonLanguage = JsonSerializer.Serialize(languageToAdd);
            await _localStorageService.AddItem(languageName, jsonLanguage);
        }

        public async Task DeleteLanguageAsync(string languageName)
        {
            await _localStorageService.RemoveItem(languageName);
        }

        public async Task<ProgrammingLanguage> GetLanguageAsync(string languageName)
        {
            ProgrammingLanguage language = null; ;
            var jsonLanguage = await _localStorageService.GetItem(languageName);
            if (jsonLanguage != null)
            {
                language = JsonSerializer.Deserialize<ProgrammingLanguage>(jsonLanguage);
            }
        
            return language;
        }
    }
}

 