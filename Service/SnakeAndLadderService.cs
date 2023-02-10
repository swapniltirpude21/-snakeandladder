public class SnakeAndLadderService
{
    private Random rnd = new Random();
    private bool isPlayerWon = false;
    private PlayerDataAccess playerDataAccess;
    private SnakeDataAccess snakeDataAccess;
    private LadderDataAccess ladderDataAccess;

    public SnakeAndLadderService()
    {
        playerDataAccess = new PlayerDataAccess();
        snakeDataAccess = new SnakeDataAccess();
        ladderDataAccess = new LadderDataAccess();
    }

    public void StartGame()
    {
        List<Player> players = playerDataAccess.GetAllPlayers();
        while (!isPlayerWon)
        {
            foreach (Player player in players)
            {
                Player currentPlayer = playerDataAccess.GetPlayer(player.Name);
                int currentPlayerPosition = currentPlayer.CurrentPostiton;
                int diceNumber = rollADice();
                int nextExpectedPosition = currentPlayerPosition + diceNumber;
                if (nextExpectedPosition <= 100)
                {
                    if (nextExpectedPosition != 100)
                    {
                        if (IsSnakeOrLadderPresent(nextExpectedPosition))
                        {
                            while (IsSnakeOrLadderPresent(nextExpectedPosition))
                            {
                                Snake snake = snakeDataAccess.GetSnake(nextExpectedPosition);
                                if (snake == null)
                                {
                                    Ladder ladder = ladderDataAccess.GetLadder(nextExpectedPosition);
                                    nextExpectedPosition = ladder.EndPosition;
                                }
                                else
                                {
                                    nextExpectedPosition = snake.EndPosition;
                                }
                            }
                        }
                    }
                    currentPlayer.CurrentPostiton = nextExpectedPosition;
                    playerDataAccess.UpdatePlayer(currentPlayer);
                    Console.WriteLine($"Player {currentPlayer.Name} moved from {currentPlayerPosition} to {nextExpectedPosition}");
                    if (nextExpectedPosition == 100)
                    {
                        isPlayerWon = true;
                        Console.WriteLine($"Player Won: {currentPlayer.Name}");
                        break;
                    }
                }
            }
        }
    }

    public void AddPlayer(string name)
    {
        playerDataAccess.SavePlayer(new Player() { Name = name });
    }
    public void AddSnake(int startPosition, int endPosition)
    {
        snakeDataAccess.SaveSnake(new Snake() { StartPosition = startPosition, EndPosition = endPosition });
    }
    public void AddLadder(int startPosition, int endPosition)
    {
        ladderDataAccess.SaveLadder(new Ladder() { StartPosition = startPosition, EndPosition = endPosition });
    }

    private int rollADice()
    {
        return rnd.Next(1, 7);
    }

    private bool IsSnakeOrLadderPresent(int startPosition)
    {
        Snake snake = snakeDataAccess.GetSnake(startPosition);
        Ladder ladder = ladderDataAccess.GetLadder(startPosition);
        if (snake != null || ladder != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}