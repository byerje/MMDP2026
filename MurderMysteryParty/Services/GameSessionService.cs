using MurderMysteryParty.Models;

namespace MurderMysteryParty.Services
{
    public class GameSessionService
    {
        private GameSession _gameSession;
        public event Action? OnGameStateChanged;

        public GameSessionService()
        {
            _gameSession = new GameSession();
        }

        public GameSession GetGameSession()
        {
            return _gameSession;
        }

        public void UnlockRound1()
        {
            _gameSession.IsRound1Unlocked = true;
            _gameSession.CurrentRound = 1;
            NotifyStateChanged();
        }

        public void UnlockRound2A()
        {
            _gameSession.IsRound2AUnlocked = true;
            _gameSession.CurrentRound = 2;
            NotifyStateChanged();
        }

        public void UnlockRound2B()
        {
            _gameSession.IsRound2BUnlocked = true;
            _gameSession.CurrentRound = 3;
            NotifyStateChanged();
        }

        public void UnlockRound3A()
        {
            _gameSession.IsRound3AUnlocked = true;
            _gameSession.CurrentRound = 4;
            NotifyStateChanged();
        }

        public void UnlockRound3B()
        {
            _gameSession.IsRound3BUnlocked = true;
            _gameSession.CurrentRound = 5;
            NotifyStateChanged();
        }

        // New method to unlock both Round 3A and 3B simultaneously
        public void UnlockRound3()
        {
            _gameSession.IsRound3AUnlocked = true;
            _gameSession.IsRound3BUnlocked = true;
            _gameSession.CurrentRound = 4; // Start with Round 3A display
            NotifyStateChanged();
        }

        public void ResetGame()
        {
            _gameSession = new GameSession();
            NotifyStateChanged();
        }

        public void SetDirectAssignmentAllowed(bool allowed)
        {
            _gameSession.IsDirectAssignmentAllowed = allowed;
            NotifyStateChanged();
        }

        public void ApplyRoundUnlock(int round)
        {
            switch (round)
            {
                case 1:
                    _gameSession.IsRound1Unlocked = true;
                    _gameSession.CurrentRound = 1;
                    break;
                case 2:
                    _gameSession.IsRound2AUnlocked = true;
                    _gameSession.CurrentRound = 2;
                    break;
                case 3:
                    _gameSession.IsRound2BUnlocked = true;
                    _gameSession.CurrentRound = 3;
                    break;
                case 4:
                    _gameSession.IsRound3AUnlocked = true;
                    _gameSession.IsRound3BUnlocked = true;
                    _gameSession.CurrentRound = 4;
                    break;
            }

            NotifyStateChanged();
        }

        public bool IsRoundUnlocked(int round)
        {
            return round switch
            {
                1 => _gameSession.IsRound1Unlocked,
                2 => _gameSession.IsRound2AUnlocked,
                3 => _gameSession.IsRound2BUnlocked,
                4 => _gameSession.IsRound3AUnlocked,
                5 => _gameSession.IsRound3BUnlocked,
                _ => false
            };
        }

        public string GetCurrentRoundName()
        {
            return _gameSession.CurrentRound switch
            {
                1 => "Round 1",
                2 => "Round 2 - Part A (Pre-Murder)",
                3 => "Round 2 - Part B (Post-Murder)",
                4 when _gameSession.IsRound3AUnlocked && _gameSession.IsRound3BUnlocked => "Round 3 (Reveals & Chaos)",
                4 => "Round 3 - Part A (Motive Reveal)",
                5 => "Round 3 - Part B (Chaotic Ending)",
                _ => "Game Not Started"
            };
        }

        private void NotifyStateChanged()
        {
            OnGameStateChanged?.Invoke();
        }
    }
}