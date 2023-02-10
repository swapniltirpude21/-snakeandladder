public class SnakeDataAccess
{
    private IDictionary<int, Snake> snakeList = new Dictionary<int, Snake>();

    public SnakeDataAccess()
    {

    }

    public Snake GetSnake(int startPosition)
    {
        if (snakeList.ContainsKey(startPosition))
        {
            return snakeList[startPosition];
        }
        return null;
    }

    public void SaveSnake(Snake snake)
    {
        if (!snakeList.ContainsKey(snake.StartPosition))
        {
            snakeList.Add(snake.StartPosition, snake);
        }
    }
}