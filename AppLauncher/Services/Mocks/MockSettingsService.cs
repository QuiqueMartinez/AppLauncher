using AppLauncher.Contracts;


namespace AppLauncher.Services
{
    public class MockSettingsService : ISettingsService
    {
        private readonly Dictionary<string, string> storage = new();

        public string? LoadSetting(string key)
        {
            storage.TryGetValue(key, out var value);
            return value;
        }

        public void SaveSetting(string key, string value)
        {
            storage[key] = value;
        }
    }
}
