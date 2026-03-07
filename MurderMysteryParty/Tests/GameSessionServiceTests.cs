using Xunit;
using MurderMysteryParty.Services;
using MurderMysteryParty.Models;

namespace MurderMysteryParty.Tests;

public class GameSessionServiceTests
{
    [Fact]
    public void GetGameSession_InitialState_AllRoundsLocked()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        var session = service.GetGameSession();

        // Assert
        Assert.False(session.IsRound1Unlocked);
        Assert.False(session.IsRound2AUnlocked);
        Assert.False(session.IsRound2BUnlocked);
        Assert.False(session.IsRound3AUnlocked);
        Assert.False(session.IsRound3BUnlocked);
    }

    [Fact]
    public void UnlockRound1_UnlocksRound1()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        service.UnlockRound1();
        var session = service.GetGameSession();

        // Assert
        Assert.True(session.IsRound1Unlocked);
    }

    [Fact]
    public void UnlockRound2A_UnlocksRound2A()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        service.UnlockRound2A();
        var session = service.GetGameSession();

        // Assert
        Assert.True(session.IsRound2AUnlocked);
    }

    [Fact]
    public void UnlockRound2B_UnlocksRound2B()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        service.UnlockRound2B();
        var session = service.GetGameSession();

        // Assert
        Assert.True(session.IsRound2BUnlocked);
    }

    [Fact]
    public void UnlockRound3_UnlocksRound3()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        service.UnlockRound3();
        var session = service.GetGameSession();

        // Assert
        Assert.True(session.IsRound3AUnlocked);
        Assert.True(session.IsRound3BUnlocked);
    }

    [Fact]
    public void ResetGame_ResetsAllRounds()
    {
        // Arrange
        var service = new GameSessionService();
        service.UnlockRound1();
        service.UnlockRound2A();
        service.UnlockRound2B();
        service.UnlockRound3();

        // Act
        service.ResetGame();
        var session = service.GetGameSession();

        // Assert
        Assert.False(session.IsRound1Unlocked);
        Assert.False(session.IsRound2AUnlocked);
        Assert.False(session.IsRound2BUnlocked);
        Assert.False(session.IsRound3AUnlocked);
        Assert.False(session.IsRound3BUnlocked);
    }

    [Fact]
    public void GetCurrentRoundName_NoRoundsUnlocked_ReturnsPreGame()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        var roundName = service.GetCurrentRoundName();

        // Assert
        Assert.Equal("Game Not Started", roundName);
    }

    [Fact]
    public void GetCurrentRoundName_Round1Unlocked_ReturnsRound1()
    {
        // Arrange
        var service = new GameSessionService();
        service.UnlockRound1();

        // Act
        var roundName = service.GetCurrentRoundName();

        // Assert
        Assert.Equal("Round 1", roundName);
    }

    [Fact]
    public void GetCurrentRoundName_Round2AUnlocked_ReturnsRound2A()
    {
        // Arrange
        var service = new GameSessionService();
        service.UnlockRound1();
        service.UnlockRound2A();

        // Act
        var roundName = service.GetCurrentRoundName();

        // Assert
        Assert.Equal("Round 2 - Part A (Pre-Murder)", roundName);
    }

    [Fact]
    public void GetCurrentRoundName_Round2BUnlocked_ReturnsRound2B()
    {
        // Arrange
        var service = new GameSessionService();
        service.UnlockRound2B();

        // Act
        var roundName = service.GetCurrentRoundName();

        // Assert
        Assert.Equal("Round 2 - Part B (Post-Murder)", roundName);
    }

    [Fact]
    public void GetCurrentRoundName_Round3AOnlyUnlocked_ReturnsRound3A()
    {
        // Arrange
        var service = new GameSessionService();
        service.UnlockRound3A();

        // Act
        var roundName = service.GetCurrentRoundName();

        // Assert
        Assert.Equal("Round 3 - Part A (Motive Reveal)", roundName);
    }

    [Fact]
    public void GetCurrentRoundName_Round3Unlocked_ReturnsRound3()
    {
        // Arrange
        var service = new GameSessionService();
        service.UnlockRound1();
        service.UnlockRound2A();
        service.UnlockRound2B();
        service.UnlockRound3();

        // Act
        var roundName = service.GetCurrentRoundName();

        // Assert
        Assert.Equal("Round 3 (Reveals & Chaos)", roundName);
    }

    [Fact]
    public void ApplyRoundUnlock_Round1_UnlocksRound1()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        service.ApplyRoundUnlock(1);
        var session = service.GetGameSession();

        // Assert
        Assert.True(session.IsRound1Unlocked);
    }

    [Fact]
    public void ApplyRoundUnlock_Round2_UnlocksRound2A()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        service.ApplyRoundUnlock(2);
        var session = service.GetGameSession();

        // Assert
        Assert.True(session.IsRound2AUnlocked);
    }

    [Fact]
    public void ApplyRoundUnlock_Round3_UnlocksRound2B()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        service.ApplyRoundUnlock(3);
        var session = service.GetGameSession();

        // Assert
        Assert.True(session.IsRound2BUnlocked);
    }

    [Fact]
    public void OnGameStateChanged_FiresWhenRoundUnlocked()
    {
        // Arrange
        var service = new GameSessionService();
        bool eventFired = false;
        service.OnGameStateChanged += () => eventFired = true;

        // Act
        service.UnlockRound1();

        // Assert
        Assert.True(eventFired);
    }

    [Fact]
    public void SetDirectAssignmentAllowed_True_SetsFlag()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        service.SetDirectAssignmentAllowed(true);
        var session = service.GetGameSession();

        // Assert
        Assert.True(session.IsDirectAssignmentAllowed);
    }

    [Fact]
    public void SetDirectAssignmentAllowed_False_ClearsFlag()
    {
        // Arrange
        var service = new GameSessionService();
        service.SetDirectAssignmentAllowed(true);

        // Act
        service.SetDirectAssignmentAllowed(false);
        var session = service.GetGameSession();

        // Assert
        Assert.False(session.IsDirectAssignmentAllowed);
    }

    [Fact]
    public void SetDirectAssignmentAllowed_FiresOnGameStateChanged()
    {
        // Arrange
        var service = new GameSessionService();
        bool eventFired = false;
        service.OnGameStateChanged += () => eventFired = true;

        // Act
        service.SetDirectAssignmentAllowed(true);

        // Assert
        Assert.True(eventFired);
    }

    [Fact]
    public void ResetGame_ClearsDirectAssignmentAllowed()
    {
        // Arrange
        var service = new GameSessionService();
        service.SetDirectAssignmentAllowed(true);

        // Act
        service.ResetGame();
        var session = service.GetGameSession();

        // Assert
        Assert.False(session.IsDirectAssignmentAllowed);
    }

    [Fact]
    public void UnlockRound3A_UnlocksRound3A()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        service.UnlockRound3A();
        var session = service.GetGameSession();

        // Assert
        Assert.True(session.IsRound3AUnlocked);
        Assert.False(session.IsRound3BUnlocked);
    }

    [Fact]
    public void UnlockRound3B_UnlocksRound3B()
    {
        // Arrange
        var service = new GameSessionService();

        // Act
        service.UnlockRound3B();
        var session = service.GetGameSession();

        // Assert
        Assert.True(session.IsRound3BUnlocked);
        Assert.False(session.IsRound3AUnlocked);
    }

    [Fact]
    public void ResetGame_SetsCurrentRoundToZero()
    {
        // Arrange
        var service = new GameSessionService();
        service.UnlockRound1();

        // Act
        service.ResetGame();
        var session = service.GetGameSession();

        // Assert
        Assert.Equal(0, session.CurrentRound);
    }
}
