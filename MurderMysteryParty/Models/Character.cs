namespace MurderMysteryParty.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Background { get; set; } = string.Empty;
        public string PersonalityTraits { get; set; } = string.Empty;
        public string Goals { get; set; } = string.Empty;
        public string Secrets { get; set; } = string.Empty;
        public string Costume { get; set; } = string.Empty;
        public bool IsAssigned { get; set; } = false;

        // Round Content
        public string Round1Content { get; set; } = string.Empty;
        public string Round2AContent { get; set; } = string.Empty;
        public string Round2BContent { get; set; } = string.Empty;
        public string Round3AMotiveReveal { get; set; } = string.Empty;
        public string Round3BChaoticEnding { get; set; } = string.Empty;
    }
}