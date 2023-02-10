public class LadderDataAccess
{
    private IDictionary<int, Ladder> ladderList = new Dictionary<int, Ladder>();

    public LadderDataAccess()
    {

    }

    public Ladder GetLadder(int startPosition)
    {
        if (ladderList.ContainsKey(startPosition))
        {
            return ladderList[startPosition];
        }
        return null;
    }

    public void SaveLadder(Ladder ladder)
    {
        if (!ladderList.ContainsKey(ladder.StartPosition))
        {
            ladderList.Add(ladder.StartPosition, ladder);
        }
    }
}