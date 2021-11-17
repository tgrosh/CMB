using System.Collections.Generic;

public class PlayerStats: List<PlayerStat>
{
    public PlayerStat GetStat(Stat stat) {
        return this.Find(playerStat => playerStat.stat == stat);
    }
}