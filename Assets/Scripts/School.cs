using System.Collections.Generic;
using UnityEngine;

public class School
{
    public string name;
    public Mascot mascot;
    public Color primaryColor;
    public Color secondaryColor;
    public List<Player> players;

    public School(string name, Mascot mascot, List<Player> players, Color primaryColor, Color secondaryColor)
    {
        this.name = name;
        this.mascot = mascot;
        this.players = players;
        this.primaryColor = primaryColor;
        this.secondaryColor = secondaryColor;
    }
}