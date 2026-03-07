using Xunit;
using MurderMysteryParty.Models;

namespace MurderMysteryParty.Tests;

public class CharacterModelTests
{
    [Fact]
    public void Character_DefaultState_IsNotAssigned()
    {
        // Arrange & Act
        var character = new Character
        {
            Id = 1,
            Name = "Test Character",
            Occupation = "Test Occupation",
            Background = "Test background",
            PersonalityTraits = "Test traits",
            Goals = "Test goals",
            Secrets = "Test secrets",
            Costume = "Test costume",
            Description = "Test description"
        };

        // Assert
        Assert.False(character.IsAssigned);
    }

    [Fact]
    public void Character_AllPropertiesSet_StoresValues()
    {
        // Arrange
        var character = new Character
        {
            Id = 1,
            Name = "Jazz Singer",
            Occupation = "Performer",
            Background = "From New York",
            PersonalityTraits = "Charismatic",
            Goals = "Become famous",
            Secrets = "Secret past",
            Costume = "Flapper dress",
            Description = "Friend of victim"
        };

        // Act & Assert
        Assert.Equal(1, character.Id);
        Assert.Equal("Jazz Singer", character.Name);
        Assert.Equal("Performer", character.Occupation);
        Assert.Equal("From New York", character.Background);
        Assert.Equal("Charismatic", character.PersonalityTraits);
        Assert.Equal("Become famous", character.Goals);
        Assert.Equal("Secret past", character.Secrets);
        Assert.Equal("Flapper dress", character.Costume);
        Assert.Equal("Friend of victim", character.Description);
    }

    [Fact]
    public void Character_IsAssigned_CanBeSetToTrue()
    {
        // Arrange
        var character = new Character { Id = 1, Name = "Test" };

        // Act
        character.IsAssigned = true;

        // Assert
        Assert.True(character.IsAssigned);
    }

    [Fact]
    public void Character_RoundContentProperties_DefaultToEmpty()
    {
        // Arrange & Act
        var character = new Character { Id = 1, Name = "Test" };

        // Assert
        Assert.Equal(string.Empty, character.Round1Content);
        Assert.Equal(string.Empty, character.Round2AContent);
        Assert.Equal(string.Empty, character.Round2BContent);
        Assert.Equal(string.Empty, character.Round3AMotiveReveal);
        Assert.Equal(string.Empty, character.Round3BChaoticEnding);
    }

    [Fact]
    public void Character_RoundContentProperties_CanBeSet()
    {
        // Arrange
        var character = new Character { Id = 1, Name = "Test" };

        // Act
        character.Round1Content = "Round 1 instructions";
        character.Round2AContent = "Round 2A instructions";
        character.Round2BContent = "Round 2B instructions";
        character.Round3AMotiveReveal = "Motive reveal";
        character.Round3BChaoticEnding = "Chaotic ending";

        // Assert
        Assert.Equal("Round 1 instructions", character.Round1Content);
        Assert.Equal("Round 2A instructions", character.Round2AContent);
        Assert.Equal("Round 2B instructions", character.Round2BContent);
        Assert.Equal("Motive reveal", character.Round3AMotiveReveal);
        Assert.Equal("Chaotic ending", character.Round3BChaoticEnding);
    }
}
