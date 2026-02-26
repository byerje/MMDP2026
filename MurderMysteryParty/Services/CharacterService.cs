using MurderMysteryParty.Models;
using MurderMysteryParty.Data;

namespace MurderMysteryParty.Services
{
    public class CharacterService
    {
        private readonly List<Character> _characters;
        
        public CharacterService()
        {
            _characters = CharacterData.GetCharacters();
        }
        
        public List<Character> GetAllCharacters()
        {
            return _characters;
        }
        
        public Character? GetCharacterById(int id)
        {
            return _characters.FirstOrDefault(c => c.Id == id);
        }
        
        public Character? AssignRandomCharacter()
        {
            var availableCharacters = _characters.Where(c => !c.IsAssigned).ToList();
            if (availableCharacters.Count == 0)
                return null;
                
            var random = new Random();
            var selectedCharacter = availableCharacters[random.Next(availableCharacters.Count)];
            selectedCharacter.IsAssigned = true;
            
            return selectedCharacter;
        }
        
        public void ResetCharacterAssignments()
        {
            foreach (var character in _characters)
            {
                character.IsAssigned = false;
            }
        }

        public void ResetCharacterAssignment(int characterId)
        {
            var character = _characters.FirstOrDefault(c => c.Id == characterId);
            if (character != null)
            {
                character.IsAssigned = false;
            }
        }
    }
}