public class UpdateScoreCommand : IUICommand
{
    public int NewScore;

    public UpdateScoreCommand(int newScore)
    {
        NewScore = newScore;
    }
}
