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

    public void SetCurrentSchool(string name) {
        currentSchool = GetSchool(name);
    }

    public void GenerateConferencesAndSchools() {
        conferences.Add(new Conference() { 
            name = "Southern Coast Conference", 
            schools = new List<School>() {
                new School("Carolina Univeristy", new Mascot("Runners"), GenerateRosters(), Color.cyan, Color.black),
                new School("Peach State", new Mascot("Panthers"), GenerateRosters(), Color.magenta, Color.black),
                new School("Gold Coast International", new Mascot("Dolphins"), GenerateRosters(), Color.yellow, Color.black),
                new School("Tide University", new Mascot("Pods"), GenerateRosters(), Color.red, Color.black),
                new School("Alabama Tech", new Mascot("Rockets"), GenerateRosters(), Color.red, Color.black),
                new School("Parrish College", new Mascot("Seawalls"), GenerateRosters(), Color.magenta, Color.black),
                new School("Texas Online", new Mascot("Cowboys"), GenerateRosters(), Color.blue, Color.black),
                new School("Tampa State", new Mascot("Hurricanes"), GenerateRosters(), Color.cyan, Color.black),
            }
        });
        conferences.Add(new Conference() { 
            name = "Eastern Colonies Conference",
            schools = new List<School>() {
                new School("Roanoke University", new Mascot("Minutemen"), GenerateRosters(), Color.red, Color.black),
                new School("Potomac Tech", new Mascot("Blue Crabs"), GenerateRosters(), Color.yellow, Color.black),
                new School("Three Rivers University", new Mascot("Steelmakers"), GenerateRosters(), Color.green, Color.black),
                new School("Upstate College", new Mascot("Mountaineers"), GenerateRosters(), Color.blue, Color.black),
                new School("Atlantic City Community College", new Mascot("Sharks"), GenerateRosters(), Color.magenta, Color.black),
                new School("Salem Methodist College", new Mascot("Colonists"), GenerateRosters(), Color.black, Color.white),
                new School("Hartford University", new Mascot("Whalers"), GenerateRosters(), Color.cyan, Color.black),
                new School("Yonkers University", new Mascot("Bulldogs"), GenerateRosters(), Color.green, Color.black),
            }
        });
        conferences.Add(new Conference() { 
            name = "Big Sun Conference",
            schools = new List<School>() {
                new School("Silicon Valley Tech", new Mascot("Chips"), GenerateRosters(), Color.green, Color.black),
                new School("San Andreas University", new Mascot("Quakes"), GenerateRosters(), Color.red, Color.black),
                new School("Bay Area College", new Mascot("Gold Diggers"), GenerateRosters(), Color.red, Color.black),
                new School("Grand Canyon University", new Mascot("Spelunkers"), GenerateRosters(), Color.grey, Color.black),
                new School("Sin City Community College", new Mascot("Showmen"), GenerateRosters(), Color.magenta, Color.black),
                new School("Lone Star University", new Mascot("Cruisers"), GenerateRosters(), Color.red, Color.black),
                new School("Albequerque A & T", new Mascot("Cactus"), GenerateRosters(), Color.red, Color.black),
                new School("Baja University", new Mascot("Desert Eagles"), GenerateRosters(), Color.green, Color.black),
            }
        });
        conferences.Add(new Conference() { 
            name = "Great Northern Conference",
            schools = new List<School>() {
                new School("Wright Brothers College", new Mascot("Pilots"), GenerateRosters(), Color.blue, Color.black),
                new School("Yooper University", new Mascot("Snow Devils"), GenerateRosters(), Color.green, Color.black),
                new School("Wrigleyville Community College", new Mascot("Grabowskis"), GenerateRosters(), Color.blue, Color.black),
                new School("Kansas City Tech", new Mascot("Chieftains"), GenerateRosters(), Color.cyan, Color.black),
                new School("Omaha College", new Mascot("Reubens"), GenerateRosters(), Color.white, Color.black),
                new School("Olympic University", new Mascot("Sea Bass"), GenerateRosters(), Color.blue, Color.black),
                new School("Oregon Trail University", new Mascot("Explorers"), GenerateRosters(), Color.cyan, Color.black),
                new School("Grand Forks University", new Mascot("Loners"), GenerateRosters(), Color.red, Color.black),
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
