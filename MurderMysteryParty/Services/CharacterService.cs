using MurderMysteryParty.Models;
using MurderMysteryParty.Data;

namespace MurderMysteryParty.Services
{
    public class CharacterService
    {
        private readonly List<Character> _characters;

        public event Action? OnAssignmentsChanged;

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
            NotifyAssignmentsChanged();

            return selectedCharacter;
        }

        public bool TryAssignCharacter(int characterId)
        {
            var character = _characters.FirstOrDefault(c => c.Id == characterId);
            if (character == null || character.IsAssigned)
            {
                return false;
            }

            character.IsAssigned = true;
            NotifyAssignmentsChanged();
            return true;
        }

        public void ResetCharacterAssignments()
        {
            foreach (var character in _characters)
            {
                character.IsAssigned = false;
            }

            NotifyAssignmentsChanged();
        }

        public void ResetCharacterAssignment(int characterId)
        {
            var character = _characters.FirstOrDefault(c => c.Id == characterId);
            if (character != null)
            {
                character.IsAssigned = false;
                NotifyAssignmentsChanged();
            }
        }

        public void ApplyAssignmentChange(int characterId, bool isAssigned)
        {
            var character = _characters.FirstOrDefault(c => c.Id == characterId);
            if (character != null)
            {
                character.IsAssigned = isAssigned;
                NotifyAssignmentsChanged();
            }
        }

        private void NotifyAssignmentsChanged()
        {
            OnAssignmentsChanged?.Invoke();
        }
    }
}