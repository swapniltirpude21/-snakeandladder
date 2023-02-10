public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to snake and ladder");
        args = System.IO.File.ReadAllLines(@"E:\projects\snakeandladder\inputFile.txt");
        SnakeAndLadderService snlService = new SnakeAndLadderService();
        int argsLength = args.Count();
        int noOfSnake = Convert.ToInt32(args[0]);
        for(int i = 0; i<noOfSnake; i++){
            string snakeDetails = args[i+1];
            string[] position = snakeDetails.Split(' ');
            snlService.AddSnake(Convert.ToInt32(position[0]), Convert.ToInt32(position[1]));
        }
        int noOfLadder = Convert.ToInt32(args[noOfSnake+1]);
        for(int i = 0; i<noOfLadder; i++){
            string ladderDetails = args[i+2+noOfSnake];
            string[] position = ladderDetails.Split(' ');
            snlService.AddLadder(Convert.ToInt32(position[0]), Convert.ToInt32(position[1]));
        }
        int noOfPlayer = Convert.ToInt32(args[noOfSnake+noOfLadder+2]);
        for(int i = 0; i<noOfPlayer; i++){
            string playerName = args[i+3+noOfSnake+noOfLadder];
            snlService.AddPlayer(playerName);
        }
        snlService.StartGame();
    }
}