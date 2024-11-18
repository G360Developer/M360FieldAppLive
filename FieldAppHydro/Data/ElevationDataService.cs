using System.Net.Http.Json;
using Blazored.LocalStorage;

namespace FieldAppHydro.Data{

public class ElevationDataService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _http;

    public ElevationDataService(ILocalStorageService localStorage, HttpClient http)
    {
        _localStorage = localStorage;
        _http = http;
    }

    public async Task<List<ElevationData>> GetElevationDataAsync()
    {
        var elevationData = await _localStorage.GetItemAsync<List<ElevationData>>("ElevationData");
        if (elevationData != null)
        {
            return elevationData;
        }

        var response = await _http.GetAsync("https://mg360fieldapplicationapi.azurewebsites.net/elevationData");
        if (response.IsSuccessStatusCode)
        {
            elevationData = await response.Content.ReadFromJsonAsync<List<ElevationData>>();
            await _localStorage.SetItemAsync("ElevationData", elevationData);
            return elevationData;
        }

        // Handle potential errors here (e.g., throw an exception)
        throw new Exception("Failed to retrieve elevation data from API");

        // Or return an empty list with a warning message
        // return new List<ElevationData>() { new ElevationData { Name = "Error retrieving data" } };
    }
}}