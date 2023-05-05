public interface ILeaderboards
{
    bool SubmitScore(int score);
    string GetLeaderboard();
}