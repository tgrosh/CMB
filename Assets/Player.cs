using System.Collections.Generic;

public class Player
{
    public string name;
    public PlayerPosition position;
    public PlayerStats stats;

    public Player(string name, PlayerPosition position, PlayerStats stats)
    {
        this.name = name;
        this.position = position;
        this.stats = stats;
    }    
}
