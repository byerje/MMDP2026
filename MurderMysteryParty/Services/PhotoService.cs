using System.Net.Http.Json;
using MurderMysteryParty.Models;

namespace MurderMysteryParty.Services;

/// <summary>
/// Loads photo album data from a static JSON manifest at images/photos/albums.json.
/// Photos are served as static files from wwwroot/images/photos/{folder}/.
/// To add a new event's photos:
///   1. Create a subfolder under wwwroot/images/photos/ (e.g. "2026-03-14")
///   2. Drop the image files into that folder
///   3. Add an entry to wwwroot/images/photos/albums.json listing the folder, date, title, and filenames
///   4. Deploy
/// </summary>
public class PhotoService
{
    private readonly HttpClient _httpClient;
    private List<PhotoAlbum>? _albums;

    public PhotoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<PhotoAlbum>> GetAlbumsAsync()
    {
        if (_albums != null)
            return _albums;

        try
        {
            _albums = await _httpClient.GetFromJsonAsync<List<PhotoAlbum>>("images/photos/albums.json");
        }
        catch
        {
            // manifest missing or malformed — return empty
        }

        _albums ??= new();
        return _albums;
    }

    public async Task<PhotoAlbum?> GetAlbumByFolderAsync(string folder)
    {
        var albums = await GetAlbumsAsync();
        return albums.FirstOrDefault(a =>
            string.Equals(a.Folder, folder, StringComparison.OrdinalIgnoreCase));
    }

    public string GetPhotoUrl(string folder, string fileName)
    {
        return $"images/photos/{folder}/{fileName}";
    }
}
