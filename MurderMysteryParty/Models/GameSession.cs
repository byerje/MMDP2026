namespace MurderMysteryParty.Models
{
    public class GameSession
    {
        public int CurrentRound { get; set; } = 0; // 0 = not started, 1 = Round 1, 2 = Round 2A, 3 = Round 2B, 4 = Round 3A, 5 = Round 3B
        public bool IsRound1Unlocked { get; set; } = false;
        public bool IsRound2AUnlocked { get; set; } = false;
        public bool IsRound2BUnlocked { get; set; } = false;
        public bool IsRound3AUnlocked { get; set; } = false;
        public bool IsRound3BUnlocked { get; set; } = false;
        public bool IsDirectAssignmentAllowed { get; set; } = false;
    }
}