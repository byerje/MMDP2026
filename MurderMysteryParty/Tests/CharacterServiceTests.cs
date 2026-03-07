using Xunit;
using MurderMysteryParty.Services;
using MurderMysteryParty.Models;

namespace MurderMysteryParty.Tests;

public class CharacterServiceTests
{
    [Fact]
    public void GetAllCharacters_ReturnsAllCharacters()
    {
        // Arrange
        var service = new CharacterService();

        // Act
        var characters = service.GetAllCharacters();

        // Assert
        Assert.NotNull(characters);
        Assert.Equal(21, characters.Count); // Updated to match actual character count
    }

    [Fact]
    public void GetCharacterById_ValidId_ReturnsCharacter()
    {
        // Arrange
        var service = new CharacterService();

        // Act
        var character = service.GetCharacterById(1);

        // Assert
        Assert.NotNull(character);
        Assert.Equal(1, character.Id);
    }

    [Fact]
    public void GetCharacterById_InvalidId_ReturnsNull()
    {
        // Arrange
        var service = new CharacterService();

        // Act
        var character = service.GetCharacterById(999);

        // Assert
        Assert.Null(character);
    }

    [Fact]
    public void AssignRandomCharacter_AssignsAvailableCharacter()
    {
        // Arrange
        var service = new CharacterService();

        // Act
        var character = service.AssignRandomCharacter();

        // Assert
        Assert.NotNull(character);
        Assert.True(character.IsAssigned);
    }

    [Fact]
    public void AssignRandomCharacter_AllAssigned_ReturnsNull()
    {
        // Arrange
        var service = new CharacterService();
        var characters = service.GetAllCharacters();
        
        // Assign all characters
        foreach (var character in characters)
        {
            service.TryAssignCharacter(character.Id);
        }

        // Act
        var result = service.AssignRandomCharacter();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TryAssignCharacter_AvailableCharacter_ReturnsTrue()
    {
        // Arrange
        var service = new CharacterService();

        // Act
        var result = service.TryAssignCharacter(1);

        // Assert
        Assert.True(result);
        var character = service.GetCharacterById(1);
        Assert.True(character?.IsAssigned);
    }

    [Fact]
    public void TryAssignCharacter_AlreadyAssigned_ReturnsFalse()
    {
        // Arrange
        var service = new CharacterService();
        service.TryAssignCharacter(1);

        // Act
        var result = service.TryAssignCharacter(1);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryAssignCharacter_InvalidId_ReturnsFalse()
    {
        // Arrange
        var service = new CharacterService();

        // Act
        var result = service.TryAssignCharacter(999);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ResetCharacterAssignment_ResetsSpecificCharacter()
    {
        // Arrange
        var service = new CharacterService();
        service.TryAssignCharacter(1);

        // Act
        service.ResetCharacterAssignment(1);

        // Assert
        var character = service.GetCharacterById(1);
        Assert.False(character?.IsAssigned);
    }

    [Fact]
    public void ResetCharacterAssignments_ResetsAllCharacters()
    {
        // Arrange
        var service = new CharacterService();
        service.TryAssignCharacter(1);
        service.TryAssignCharacter(2);
        service.TryAssignCharacter(3);

        // Act
        service.ResetCharacterAssignments();

        // Assert
        var characters = service.GetAllCharacters();
        Assert.All(characters, c => Assert.False(c.IsAssigned));
    }

    [Fact]
    public void OnAssignmentsChanged_FiresWhenCharacterAssigned()
    {
        // Arrange
        var service = new CharacterService();
        bool eventFired = false;
        service.OnAssignmentsChanged += () => eventFired = true;

        // Act
        service.TryAssignCharacter(1);

        // Assert
        Assert.True(eventFired);
    }

    [Fact]
    public void TryAssignCharacter_SimultaneousAttempts_OnlyOneSucceeds()
    {
        // Arrange
        var service = new CharacterService();

        // Act
        var result1 = service.TryAssignCharacter(1);
        var result2 = service.TryAssignCharacter(1);

        // Assert
        Assert.True(result1);
        Assert.False(result2);
        var character = service.GetCharacterById(1);
        Assert.True(character?.IsAssigned);
    }

    [Fact]
    public void GetCharacterById_AssignedCharacter_ReturnsAssignedState()
    {
        // Arrange
        var service = new CharacterService();
        service.TryAssignCharacter(1);

        // Act
        var character = service.GetCharacterById(1);

        // Assert
        Assert.NotNull(character);
        Assert.True(character.IsAssigned);
    }

    [Fact]
    public void ResetCharacterAssignment_ClearsAssignmentAndNotifies()
    {
        // Arrange
        var service = new CharacterService();
        service.TryAssignCharacter(1);
        bool eventFired = false;
        service.OnAssignmentsChanged += () => eventFired = true;

        // Act
        service.ResetCharacterAssignment(1);

        // Assert
        var character = service.GetCharacterById(1);
        Assert.NotNull(character);
        Assert.False(character.IsAssigned);
        Assert.True(eventFired);
    }

    [Fact]
    public void ResetCharacterAssignment_NonExistentCharacter_DoesNotThrow()
    {
        // Arrange
        var service = new CharacterService();

        // Act & Assert (should not throw)
        service.ResetCharacterAssignment(999);
    }

    [Fact]
    public void GetAssignedCharacterIds_NoneAssigned_ReturnsEmpty()
    {
        // Arrange
        var service = new CharacterService();

        // Act
        var ids = service.GetAssignedCharacterIds();

        // Assert
        Assert.Empty(ids);
    }

    [Fact]
    public void GetAssignedCharacterIds_SomeAssigned_ReturnsOnlyAssignedIds()
    {
        // Arrange
        var service = new CharacterService();
        service.TryAssignCharacter(1);
        service.TryAssignCharacter(3);

        // Act
        var ids = service.GetAssignedCharacterIds();

        // Assert
        Assert.Equal(2, ids.Count);
        Assert.Contains(1, ids);
        Assert.Contains(3, ids);
    }

    [Fact]
    public void RestoreAssignments_MarksCharactersAsAssigned()
    {
        // Arrange
        var service = new CharacterService();

        // Act
        service.RestoreAssignments(new List<int> { 1, 2 });

        // Assert
        Assert.True(service.GetCharacterById(1)?.IsAssigned);
        Assert.True(service.GetCharacterById(2)?.IsAssigned);
        Assert.False(service.GetCharacterById(3)?.IsAssigned);
    }

    [Fact]
    public void RestoreAssignments_FiresOnAssignmentsChanged()
    {
        // Arrange
        var service = new CharacterService();
        bool eventFired = false;
        service.OnAssignmentsChanged += () => eventFired = true;

        // Act
        service.RestoreAssignments(new List<int> { 1 });

        // Assert
        Assert.True(eventFired);
    }

    [Fact]
    public void RestoreAssignments_EmptyList_DoesNotFireEvent()
    {
        // Arrange
        var service = new CharacterService();
        bool eventFired = false;
        service.OnAssignmentsChanged += () => eventFired = true;

        // Act
        service.RestoreAssignments(new List<int>());

        // Assert
        Assert.False(eventFired);
    }

    [Fact]
    public void ApplyAssignmentChange_Assign_SetsIsAssignedTrue()
    {
        // Arrange
        var service = new CharacterService();

        // Act
        service.ApplyAssignmentChange(1, true);

        // Assert
        Assert.True(service.GetCharacterById(1)?.IsAssigned);
    }

    [Fact]
    public void ApplyAssignmentChange_Unassign_SetsIsAssignedFalse()
    {
        // Arrange
        var service = new CharacterService();
        service.TryAssignCharacter(1);

        // Act
        service.ApplyAssignmentChange(1, false);

        // Assert
        Assert.False(service.GetCharacterById(1)?.IsAssigned);
    }

    [Fact]
    public void ApplyAssignmentChange_FiresOnAssignmentsChanged()
    {
        // Arrange
        var service = new CharacterService();
        bool eventFired = false;
        service.OnAssignmentsChanged += () => eventFired = true;

        // Act
        service.ApplyAssignmentChange(1, true);

        // Assert
        Assert.True(eventFired);
    }

    [Fact]
    public void ApplyAssignmentChange_InvalidId_DoesNotThrow()
    {
        // Arrange
        var service = new CharacterService();

        // Act & Assert (should not throw)
        service.ApplyAssignmentChange(999, true);
    }

    [Fact]
    public void ResetCharacterAssignments_FiresOnAssignmentsChanged()
    {
        // Arrange
        var service = new CharacterService();
        service.TryAssignCharacter(1);
        bool eventFired = false;
        service.OnAssignmentsChanged += () => eventFired = true;

        // Act
        service.ResetCharacterAssignments();

        // Assert
        Assert.True(eventFired);
    }
}
