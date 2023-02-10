public class PlayerDataAccess
{
    private IDictionary<string, Player> playerList = new Dictionary<string, Player>();

    public PlayerDataAccess()
    {

    }

    public Player GetPlayer(string name)
    {
        if (playerList.ContainsKey(name))
        {
            return playerList[name];
        }
        return null;
    }

    public void UpdatePlayer(Player player)
    {
        if (playerList.ContainsKey(player.Name))
        {
            playerList[player.Name] = player;
        }
    }

    public void SavePlayer(Player player)
    {
        if (!playerList.ContainsKey(player.Name))
        {
            playerList.Add(player.Name, player);
        }
    }

    public List<Player> GetAllPlayers(){
        List<Player> returnValue= new List<Player>();
        foreach(var player in playerList){
            returnValue.Add(player.Value);
        }

        return returnValue;
    }
}