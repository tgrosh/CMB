using System.Collections.Generic;
using UnityEngine;

public class School
{
    public string name;
    public string location;
    public Mascot mascot;
    public Color primaryColor;
    public Color secondaryColor;

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