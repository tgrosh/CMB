using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class School
{
    public string name;
    public string location;
    public Mascot mascot;
    public Color primaryColor;
    public Color secondaryColor;
    public int overall {
        get {
            return (int)players.Select(player => player.overall).Average();
        }
    }
    public int ranking {
        get {
            return Rankings.GetSchoolRanking(this);
        }
    }

    public List<Player> players;

    public School(string name, string location, Mascot mascot, List<Player> players, Color primaryColor, Color secondaryColor)
    {
        this.name = name;
        this.location = location;
        this.mascot = mascot;
        this.players = players;
        this.primaryColor = primaryColor;
        this.secondaryColor = secondaryColor;
    }

}