using System.Net.Http.Json;
using Blazored.LocalStorage;

namespace FieldAppHydro.Data{

public class PersonnelService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _http;

    public PersonnelService(ILocalStorageService localStorage, HttpClient http)
    {
        _localStorage = localStorage;
        _http = http;
    }

    public async Task<List<PersonnelLookupData>> GetPersonnelAsync()
    {
        var personnelData = await _localStorage.GetItemAsync<List<PersonnelLookupData>>("Personnel");
        if (personnelData != null)
        {
            return personnelData;
        }

        var response = await _http.GetAsync("https://mg360fieldapplicationapi.azurewebsites.net/api/StationData/personnel-lookup");
        if (response.IsSuccessStatusCode)
        {
            personnelData = await response.Content.ReadFromJsonAsync<List<PersonnelLookupData>>();
            await _localStorage.SetItemAsync("Personnel", personnelData);
            return personnelData;
        }

        // Handle potential errors here (e.g., throw an exception)
        throw new Exception("Failed to retrieve personnel data from API");

        // Or return an empty list with a warning message
        // return new List<Personnel>() { new Personnel { Name = "Error retrieving data" } };
    }
}}