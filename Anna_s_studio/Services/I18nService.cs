using System.Text.Json;

namespace Anna_s_studio.Services;

public class I18nService
{
    public event Action OnChange;
    private Dictionary<string, Dictionary<string, string>> _translations;
    public string CurrentLanguage { get; private set; } = "pl";

    public async Task LoadAsync(HttpClient http)
    {
        var json = await http.GetStringAsync("i18n.json");
        _translations = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json)!;
    }

    public void SetLanguage(string lang)
    {
        CurrentLanguage = lang;
        OnChange?.Invoke();
    }

    public string T(string key)
    {
        if (_translations != null && _translations.TryGetValue(CurrentLanguage, out var dict) && dict.TryGetValue(key, out var value))
        {
            return value;
        }
        return key;
    }
}
