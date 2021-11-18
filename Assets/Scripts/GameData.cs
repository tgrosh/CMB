using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameData : MonoBehaviour
{
    List<Conference> conferences = new List<Conference>();
    public School currentSchool;
    
    System.Random rand;

    public List<School> allSchools {
        get {
            return conferences.SelectMany(conf => conf.schools.Select(y => y)).ToList();
        }
    }

    public School GetSchool(string name) {
        return allSchools.Find(school => school.name == name);
    }

    public void SetCurrentSchool(School currentSchool) {
        this.currentSchool = currentSchool;
    }

    public void GenerateConferencesAndSchools() {
        conferences.Add(new Conference() { 
            name = "Southern Coast Conference", 
            schools = new List<School>() {
                new School("Carolina Univeristy", new Mascot("Runners", "RunnersLogo"), GenerateRosters(), Color.cyan, Color.black),
                new School("Peach State", new Mascot("Panthers", "pantherslogo"), GenerateRosters(), Color.magenta, Color.black),
                new School("Gold Coast International", new Mascot("Dolphins", "dolphinslogo"), GenerateRosters(), Color.yellow, Color.black),
                new School("Tide University", new Mascot("Pods", "podslogo"), GenerateRosters(), Color.red, Color.black),
                new School("Alabama Tech", new Mascot("Rockets", "rocketlogo"), GenerateRosters(), Color.red, Color.black),
                new School("Parrish College", new Mascot("Seawalls", "seawalllogo"), GenerateRosters(), Color.magenta, Color.black),
                new School("Texas Online", new Mascot("Cowboys", "cowboylogo"), GenerateRosters(), Color.blue, Color.black),
                new School("Tampa State", new Mascot("Hurricanes", "hurricanelogo"), GenerateRosters(), Color.cyan, Color.black),
            }
        });
        conferences.Add(new Conference() { 
            name = "Eastern Colonies Conference",
            schools = new List<School>() {
                new School("Roanoke University", new Mascot("Minutemen", "minutemanlogo"), GenerateRosters(), Color.red, Color.black),
                new School("Potomac Tech", new Mascot("Blue Crabs", "bluecrablogo"), GenerateRosters(), Color.yellow, Color.black),
                new School("Three Rivers University", new Mascot("Steelmakers", "steelmakerlogo"), GenerateRosters(), Color.green, Color.black),
                new School("Upstate College", new Mascot("Mountaineers", "mountaineerlogo"), GenerateRosters(), Color.blue, Color.black),
                new School("Atlantic City Community College", new Mascot("Sharks", "sharklogo"), GenerateRosters(), Color.magenta, Color.black),
                new School("Salem Methodist College", new Mascot("Colonists", "colonistlogo"), GenerateRosters(), Color.black, Color.white),
                new School("Hartford University", new Mascot("Whalers", "whalerlogo"), GenerateRosters(), Color.cyan, Color.black),
                new School("Yonkers University", new Mascot("Bulldogs", "bulldoglogo"), GenerateRosters(), Color.green, Color.black),
            }
        });
        conferences.Add(new Conference() { 
            name = "Big Sun Conference",
            schools = new List<School>() {
                new School("Silicon Valley Tech", new Mascot("Chips", "chiplogo"), GenerateRosters(), Color.green, Color.black),
                new School("San Andreas University", new Mascot("Quakes", "earthquakelogo"), GenerateRosters(), Color.red, Color.black),
                new School("Bay Area College", new Mascot("Gold Diggers", "golddiggerlogo"), GenerateRosters(), Color.red, Color.black),
                new School("Grand Canyon University", new Mascot("Burrows", "donkeyslogo"), GenerateRosters(), Color.grey, Color.black),
                new School("Sin City Community College", new Mascot("Showmen", "tophatlogo"), GenerateRosters(), Color.magenta, Color.black),
                new School("Lone Star University", new Mascot("Bulls", "bulllogo"), GenerateRosters(), Color.red, Color.black),
                new School("Albequerque A & T", new Mascot("Cactus", "cactuslogo"), GenerateRosters(), Color.red, Color.black),
                new School("Baja University", new Mascot("Desert Eagles", "eaglelogo"), GenerateRosters(), Color.green, Color.black),
            }
        });
        conferences.Add(new Conference() { 
            name = "Great Northern Conference",
            schools = new List<School>() {
                new School("Wright Brothers College", new Mascot("Pilots", "pilotslogo"), GenerateRosters(), Color.blue, Color.black),
                new School("Yooper University", new Mascot("Frost Giants", "frostgiantslogo"), GenerateRosters(), Color.green, Color.black),
                new School("Wrigleyville Community College", new Mascot("Grabowskis", "grabowskilogo"), GenerateRosters(), Color.blue, Color.black),
                new School("Kansas City Tech", new Mascot("Chieftains", "chieftainlogo"), GenerateRosters(), Color.cyan, Color.black),
                new School("Omaha College", new Mascot("Roughnecks", "roughnecklogo"), GenerateRosters(), Color.white, Color.black),
                new School("Olympic University", new Mascot("Sea Bass", "seabasslogo"), GenerateRosters(), Color.blue, Color.black),
                new School("Oregon Trail University", new Mascot("Explorers", "explorerslogo"), GenerateRosters(), Color.cyan, Color.black),
                new School("Grand Forks University", new Mascot("Trappers", "trapperlogo"), GenerateRosters(), Color.red, Color.black),
            }
        });
    }

    public List<Player> GenerateRosters() {        
        List<Player> players = new List<Player>();
        rand = new System.Random(DateTime.Now.Millisecond + DateTime.Now.Second);

        players.AddRange(GeneratePositionGroup(PlayerPosition.QB, 3));
        players.AddRange(GeneratePositionGroup(PlayerPosition.HB, 4));
        players.AddRange(GeneratePositionGroup(PlayerPosition.FB, 1));
        players.AddRange(GeneratePositionGroup(PlayerPosition.WR, 7));
        players.AddRange(GeneratePositionGroup(PlayerPosition.TE, 4));
        players.AddRange(GeneratePositionGroup(PlayerPosition.T, 4));
        players.AddRange(GeneratePositionGroup(PlayerPosition.G, 4));
        players.AddRange(GeneratePositionGroup(PlayerPosition.C, 4));
        players.AddRange(GeneratePositionGroup(PlayerPosition.DE, 5));
        players.AddRange(GeneratePositionGroup(PlayerPosition.DT, 5));
        players.AddRange(GeneratePositionGroup(PlayerPosition.ILB, 3));
        players.AddRange(GeneratePositionGroup(PlayerPosition.OLB, 3));
        players.AddRange(GeneratePositionGroup(PlayerPosition.CB, 7));
        players.AddRange(GeneratePositionGroup(PlayerPosition.FS, 3));
        players.AddRange(GeneratePositionGroup(PlayerPosition.SS, 3));
        players.AddRange(GeneratePositionGroup(PlayerPosition.K, 1));
        players.AddRange(GeneratePositionGroup(PlayerPosition.P, 1));

        return players;
    }

    public List<Player> GeneratePositionGroup(PlayerPosition position, int count) {
        List<Player> players = new List<Player>();
        
        for (int x=0; x< count; x++) {
            players.Add(GetPlayer(position));
        }
        
        return players;
    }

    public Player GetPlayer(PlayerPosition position) {
        System.Random rand = new System.Random(DateTime.Now.Millisecond + DateTime.Now.Second);
        RandomName nameGen = new RandomName(rand);

        return new Player(nameGen.Generate(Sex.Male), position, GeneratePlayerStats(position));
    }

    public PlayerStats GeneratePlayerStats(PlayerPosition position) {
        PlayerStats playerStats = new PlayerStats();

        //generate standard stats
        playerStats.Add(new PlayerStat(Stat.Agility, GenerateStatValue()));
        playerStats.Add(new PlayerStat(Stat.Injury, GenerateStatValue()));
        playerStats.Add(new PlayerStat(Stat.Intelligence, GenerateStatValue()));
        playerStats.Add(new PlayerStat(Stat.Speed, GenerateStatValue()));
        playerStats.Add(new PlayerStat(Stat.Strength, GenerateStatValue()));
        
        switch (position.abbreviation) {
            case PlayerPositionAbbreviation.QB: {
                //override stats by position here
                playerStats.GetStat(Stat.Strength).value = GenerateStatValue(62, 75);
                playerStats.GetStat(Stat.Intelligence).value = GenerateStatValue(75, 95);
                break;
            }
        }

        return playerStats;
    }

    public int GenerateStatValue(int minValue = 62, int maxValue = 92) {

        return rand.Next(minValue, maxValue);
    }
}
