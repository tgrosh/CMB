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
                new School("Carolina Univeristy", new Mascot("Runners", "UI_Icon_Trophy"), GenerateRosters(), Color.cyan, Color.black),
                new School("Peach State", new Mascot("Panthers", "UI_Icon_Paw"), GenerateRosters(), Color.magenta, Color.black),
                new School("Gold Coast International", new Mascot("Dolphins", "UI_Icon_Skull"), GenerateRosters(), Color.yellow, Color.black),
                new School("Tide University", new Mascot("Pods", "UI_Icon_Attack"), GenerateRosters(), Color.red, Color.black),
                new School("Alabama Tech", new Mascot("Rockets", "UI_Icon_Fire"), GenerateRosters(), Color.red, Color.black),
                new School("Parrish College", new Mascot("Seawalls", "UI_Icon_CardClubs"), GenerateRosters(), Color.magenta, Color.black),
                new School("Texas Online", new Mascot("Cowboys", "UI_Icon_InvHelmet"), GenerateRosters(), Color.blue, Color.black),
                new School("Tampa State", new Mascot("Hurricanes", "UI_Icon_Visible"), GenerateRosters(), Color.cyan, Color.black),
            }
        });
        conferences.Add(new Conference() { 
            name = "Eastern Colonies Conference",
            schools = new List<School>() {
                new School("Roanoke University", new Mascot("Minutemen", "UI_Icon_Attack"), GenerateRosters(), Color.red, Color.black),
                new School("Potomac Tech", new Mascot("Blue Crabs", "UI_Icon_Skull"), GenerateRosters(), Color.yellow, Color.black),
                new School("Three Rivers University", new Mascot("Steelmakers", "UI_Icon_Gem"), GenerateRosters(), Color.green, Color.black),
                new School("Upstate College", new Mascot("Mountaineers", "UI_Icon_BoneBroken"), GenerateRosters(), Color.blue, Color.black),
                new School("Atlantic City Community College", new Mascot("Sharks", "UI_Icon_Camera"), GenerateRosters(), Color.magenta, Color.black),
                new School("Salem Methodist College", new Mascot("Colonists", "UI_Icon_FaithChristianity"), GenerateRosters(), Color.black, Color.white),
                new School("Hartford University", new Mascot("Whalers", "UI_Icon_Archer"), GenerateRosters(), Color.cyan, Color.black),
                new School("Yonkers University", new Mascot("Bulldogs", "UI_Icon_Aim"), GenerateRosters(), Color.green, Color.black),
            }
        });
        conferences.Add(new Conference() { 
            name = "Big Sun Conference",
            schools = new List<School>() {
                new School("Silicon Valley Tech", new Mascot("Chips", "UI_Icon_DeviceComputer"), GenerateRosters(), Color.green, Color.black),
                new School("San Andreas University", new Mascot("Quakes", "UI_Icon_Energy"), GenerateRosters(), Color.red, Color.black),
                new School("Bay Area College", new Mascot("Gold Diggers", "UI_Icon_Cash"), GenerateRosters(), Color.red, Color.black),
                new School("Grand Canyon University", new Mascot("Spelunkers", "UI_Icon_Gem"), GenerateRosters(), Color.grey, Color.black),
                new School("Sin City Community College", new Mascot("Showmen", "UI_Icon_Camera"), GenerateRosters(), Color.magenta, Color.black),
                new School("Lone Star University", new Mascot("Cruisers", "UI_Icon_Star"), GenerateRosters(), Color.red, Color.black),
                new School("Albequerque A & T", new Mascot("Cactus", "UI_Icon_Fire"), GenerateRosters(), Color.red, Color.black),
                new School("Baja University", new Mascot("Desert Eagles", "UI_Icon_Bomb"), GenerateRosters(), Color.green, Color.black),
            }
        });
        conferences.Add(new Conference() { 
            name = "Great Northern Conference",
            schools = new List<School>() {
                new School("Wright Brothers College", new Mascot("Pilots", "UI_Icon_Paperplane"), GenerateRosters(), Color.blue, Color.black),
                new School("Yooper University", new Mascot("Snow Devils", "UI_Icon_Frost"), GenerateRosters(), Color.green, Color.black),
                new School("Wrigleyville Community College", new Mascot("Grabowskis", "UI_Icon_Sun"), GenerateRosters(), Color.blue, Color.black),
                new School("Kansas City Tech", new Mascot("Chieftains", "UI_Icon_Crown"), GenerateRosters(), Color.cyan, Color.black),
                new School("Omaha College", new Mascot("Reubens", "UI_Icon_Visible"), GenerateRosters(), Color.white, Color.black),
                new School("Olympic University", new Mascot("Sea Bass", "UI_Icon_Archer"), GenerateRosters(), Color.blue, Color.black),
                new School("Oregon Trail University", new Mascot("Explorers", "UI_Icon_BoneBroken"), GenerateRosters(), Color.cyan, Color.black),
                new School("Grand Forks University", new Mascot("Loners", "UI_Icon_InvHelmet"), GenerateRosters(), Color.red, Color.black),
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
