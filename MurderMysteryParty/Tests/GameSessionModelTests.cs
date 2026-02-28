using Xunit;
using MurderMysteryParty.Models;

namespace MurderMysteryParty.Tests;

public class GameSessionModelTests
{
    [Fact]
    public void GameSession_DefaultState_AllRoundsLocked()
    {
        // Arrange & Act
        var session = new GameSession();

        // Assert
        Assert.False(session.IsRound1Unlocked);
        Assert.False(session.IsRound2AUnlocked);
        Assert.False(session.IsRound2BUnlocked);
        Assert.False(session.IsRound3AUnlocked);
        Assert.False(session.IsRound3BUnlocked);
    }

    [Fact]
    public void GameSession_CanSetRoundStates()
    {
        // Arrange
        var session = new GameSession();

        // Act
        session.IsRound1Unlocked = true;
        session.IsRound2AUnlocked = true;

        // Assert
        Assert.True(session.IsRound1Unlocked);
        Assert.True(session.IsRound2AUnlocked);
        Assert.False(session.IsRound2BUnlocked);
    }

    [Fact]
    public void GameSession_AllRoundsCanBeUnlocked()
    {
        // Arrange
        var session = new GameSession
        {
            IsRound1Unlocked = true,
            IsRound2AUnlocked = true,
            IsRound2BUnlocked = true,
            IsRound3AUnlocked = true,
            IsRound3BUnlocked = true
        };

        // Assert
        Assert.True(session.IsRound1Unlocked);
        Assert.True(session.IsRound2AUnlocked);
        Assert.True(session.IsRound2BUnlocked);
        Assert.True(session.IsRound3AUnlocked);
        Assert.True(session.IsRound3BUnlocked);
    }
}
