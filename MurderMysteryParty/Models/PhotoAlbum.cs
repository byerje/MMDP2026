namespace MurderMysteryParty.Models;

public class PhotoAlbum
{
    private string _date = string.Empty;

    public string Folder { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Date
    {
        get => _date;
        set => _date = value?.Replace('/', '-') ?? string.Empty;
    }
    public List<string> Photos { get; set; } = new();
}
