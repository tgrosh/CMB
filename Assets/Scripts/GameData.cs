using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameData : MonoBehaviour
{
    List<Conference> conferences = new List<Conference>();
    public School currentSchool;

    System.Random rand = new System.Random(DateTime.Now.Millisecond + DateTime.Now.Second);

    public List<School> allSchools
    {
        get
        {
            return conferences.SelectMany(conf => conf.schools.Select(y => y)).ToList();
        }
    }

    public School GetSchool(string name)
    {
        return allSchools.Find(school => school.name == name);
    }

    public void SetCurrentSchool(School currentSchool)
    {
        this.currentSchool = currentSchool;
    }

    public void GenerateConferencesAndSchools()
    {
        conferences.Add(new Conference()
        {
            name = "Southern Coast Conference",
            schools = new List<School>() {
                new School("Carolina Univeristy", "Gaffney, SC", new Mascot("Runners", "RunnersLogo"), GenerateRosters(), new Color(192/255f,30/255f,46/255f), new Color(40/255f,34/255f,98/255f)),
                new School("Peach State", "Vidalia, GA", new Mascot("Panthers", "pantherslogo"), GenerateRosters(), new Color(0,113/255f,196/255f), Color.black),
                new School("Gold Coast International", "Lake City, FL", new Mascot("Dolphins", "dolphinslogo"), GenerateRosters(), new Color(0,174/255f,171/255f), Color.grey),
                new School("Tide University", "Dothan, AL", new Mascot("Pods", "podslogo"), GenerateRosters(), Color.black, Color.red),
                new School("Alabama Tech", "Huntsville, AL", new Mascot("Rockets", "rocketlogo"), GenerateRosters(), new Color(150/255f,26/255f,0), new Color(253/255f,190/255f,0)),
                new School("Parrish College", "Lake Charles, LA", new Mascot("Seawalls", "seawalllogo"), GenerateRosters(), new Color(0,101/255f,183/255f), new Color(33/255f,175/255f,225/255f)),
                new School("Texas Online", "College Station, TX", new Mascot("Cowboys", "cowboylogo"), GenerateRosters(), new Color(64/255f,64/255f,64/255f), new Color(220/255f,29/255f,33/255f)),
                new School("Tampa State", "Clearwater, FL", new Mascot("Hurricanes", "hurricanelogo"), GenerateRosters(), new Color(191/255f,37/255f,49/255f), Color.white),
            }
        });
        conferences.Add(new Conference()
        {
            name = "Eastern Colonies Conference",
            schools = new List<School>() {
                new School("Roanoke University", "Roanoke, VA", new Mascot("Minutemen", "minutemanlogo"), GenerateRosters(), new Color(221/255f,0,22/255f), new Color(0,24/255f,84/255f)),
                new School("Potomac Tech", "Owings Mills, MD", new Mascot("Blue Crabs", "bluecrablogo"), GenerateRosters(), new Color(255/255f,212/255f,1/255f), new Color(189/255f,32/255f,59/255f)),
                new School("Three Rivers University", "Pittsburg, PA", new Mascot("Steelmakers", "steelmakerlogo"), GenerateRosters(), new Color(218/255f,0,0), Color.grey),
                new School("Upstate College", "Albany, NY", new Mascot("Mountaineers", "mountaineerlogo"), GenerateRosters(), new Color(254/255f,209/255f,2/255f), Color.grey),
                new School("Atlantic City Community College", "Atlantic City, NJ", new Mascot("Sharks", "sharklogo"), GenerateRosters(), new Color(3/255f,87/255f,98/255f), new Color(10/255f,12/255f,9/255f)),
                new School("Salem Methodist College", "Salem, MA", new Mascot("Colonists", "colonistlogo"), GenerateRosters(), Color.black, Color.white),
                new School("Hartford University", "Hartford, CT", new Mascot("Whalers", "whalerlogo"), GenerateRosters(), new Color(0,123/255f,76/255f), Color.grey),
                new School("Yonkers University", "Yonkers, NY", new Mascot("Bulldogs", "bulldoglogo"), GenerateRosters(), new Color(0,0,53/255f), Color.grey),
            }
        });
        conferences.Add(new Conference()
        {
            name = "Big Sun Conference",
            schools = new List<School>() {
                new School("Silicon Valley Tech", "Silicon Valley, CA", new Mascot("Chips", "chiplogo"), GenerateRosters(), new Color(46/255f,50/255f,140/255f), new Color(96/255f,120/255f,180/255f)),
                new School("San Andreas University", "", new Mascot("Quakes", "earthquakelogo"), GenerateRosters(), new Color(48/255f,65/255f,182/255f), new Color(48/255f,123/255f,187/255f)),
                new School("Bay Area College", "Palm Springs, CA", new Mascot("Gold Diggers", "golddiggerlogo"), GenerateRosters(), new Color(243/255f,196/255f,22/255f), new Color(66/255f,66/255f,66/255f)),
                new School("Grand Canyon University", "Mesa, AZ", new Mascot("Burrows", "donkeyslogo"), GenerateRosters(), new Color(105/255f,95/255f,93/255f), new Color(140/255f,18/255f,25/255f)),
                new School("Sin City Community College", "Las Vegas, NV", new Mascot("Showmen", "tophatlogo"), GenerateRosters(), Color.magenta, Color.black),
                new School("Lone Star University", "Amarillo, TX", new Mascot("Bulls", "bulllogo"), GenerateRosters(), new Color(15/255f,15/255f,65/255f), Color.grey),
                new School("Albequerque A & T", "Albequerque, NM", new Mascot("Cactus", "cactuslogo"), GenerateRosters(), new Color(58/255f,181/255f,74/255f), new Color(214/255f,223/255f,34/255f)),
                new School("Baja University", "San Diego, CA", new Mascot("Desert Eagles", "eaglelogo"), GenerateRosters(), new Color(29/255f,0,2/255f), new Color(243/255f,196/255f,22/255f)),
            }
        });
        conferences.Add(new Conference()
        {
            name = "Great Northern Conference",
            schools = new List<School>() {
                new School("Wright Brothers College", "Gallion, OH", new Mascot("Pilots", "pilotslogo"), GenerateRosters(), new Color(13/255f,16/255f,51/255f), new Color(169/255f,63/255f,32/255f)),
                new School("Yooper University", "Marquette, MI", new Mascot("Frost Giants", "frostgiantslogo"), GenerateRosters(), new Color(25/255f,142/255f,142/255f), new Color(0,0,20/255f)),
                new School("Wrigleyville Community College", "Chicago, IL", new Mascot("Grabowskis", "grabowskilogo"), GenerateRosters(), Color.black, Color.red),
                new School("Kansas City Tech", "Kansas City, KS", new Mascot("Chieftains", "chieftainlogo"), GenerateRosters(), new Color(202/255f,202/255f,202/255f), new Color(210/255f,35/255f,75/255f)),
                new School("Omaha College", "Omaha, NE", new Mascot("Roughnecks", "roughnecklogo"), GenerateRosters(), new Color(18/255f,32/255f,71/255f), new Color(180/255f,20/255f,40/255f)),
                new School("Olympic University", "Olympia, WA", new Mascot("Sea Bass", "seabasslogo"), GenerateRosters(), new Color(47/255f,82/255f,87/255f), new Color(26/255f,41/255f,48/255f)),
                new School("Oregon Trail University", "Salem, OR", new Mascot("Explorers", "explorerslogo"), GenerateRosters(), new Color(0,69/255f,119/255f), new Color(255/255f,207/255f,6/255f)),
                new School("Grand Forks University", "Grand Forks, ND", new Mascot("Trappers", "trapperlogo"), GenerateRosters(), new Color(183/255f,160/255f,107/255f), new Color(13/255f,31/255f,70/255f)),
            }
        });
    }

    public List<Player> GenerateRosters()
    {
        List<Player> players = new List<Player>();
        float scale = ((float)rand.NextDouble() * .4f) + .8f; //between .8f and 1.2f

        players.AddRange(GeneratePositionGroup(PlayerPosition.QB, 3, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.HB, 4, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.FB, 1, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.WR, 7, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.TE, 4, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.T, 4, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.G, 4, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.C, 4, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.DE, 5, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.DT, 5, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.ILB, 3, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.OLB, 5, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.CB, 7, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.FS, 3, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.SS, 3, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.K, 1, scale));
        players.AddRange(GeneratePositionGroup(PlayerPosition.P, 1, scale));

        return players;
    }

    public List<Player> GeneratePositionGroup(PlayerPosition position, int count, float scale)
    {
        List<Player> players = new List<Player>();

        for (int x = 0; x < count; x++)
        {
            players.Add(new Player(position, scale, rand.Next(0, 4)));
        }

        return players;
    }

}
