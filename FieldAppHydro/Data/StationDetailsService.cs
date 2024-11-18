using System.Net.Http.Json;
using Blazored.LocalStorage;

public class StationDataService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _http;

    public StationDataService(ILocalStorageService localStorage, HttpClient http)
    {
        _localStorage = localStorage;
        _http = http;
    }

    public async Task<List<StationDetails>> GetStationsAsync()
    {
        var stations = await _localStorage.GetItemAsync<List<StationDetails>>("stations");
        if (stations != null)
        {
            return stations;
        }

        var response = await _http.GetAsync("https://mg360fieldapplicationapi.azurewebsites.net/all");
        if (response.IsSuccessStatusCode)
        {
            stations = await response.Content.ReadFromJsonAsync<List<StationDetails>>();
            await _localStorage.SetItemAsync("stations", stations);
            return stations;
        }

        return new List<StationDetails>();
    }
}
