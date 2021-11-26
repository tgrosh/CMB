using System;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name;
    public PlayerPosition position;
    public string origin;
    public int year = 0;
    public string classYear {
        get {
            switch (year) {
                case 0: {
                    return "Fr";
                }
                case 1: {
                    return "So";
                }
                case 2: {
                    return "Jr";
                }
            }            
            return "Sr";
        }
    }
    public int age;
    public bool hasScholarship;
    public bool isRedshirt;
    public int overall {
        get {
            return importantStats.overall;
        }
    }
    public string positionAbbreviation {
        get {
            return position.abbreviation.ToString();
        }
    }
    public PlayerStats stats;
    public PlayerStats importantStats {
        get {
            return new PlayerStats(stats.FindAll(stat => position.importantStats.Contains(stat.stat)));
        }
    }
    public float scale;

    static System.Random rand = new System.Random(((int)DateTime.Now.Ticks));

    public Player(PlayerPosition position, float scale)
    {
        this.name = RandomName.Generate(Sex.Male);
        this.age = Player.rand.Next(18, 20);
        this.position = position;
        this.origin = RandomCity.Generate();
        this.stats = new PlayerStats();
        this.scale = scale;
        GenerateStats();
    }

    public Player(PlayerPosition position, float scale, int year) : this(position, scale) {
        for (int yr = 0; yr < year; yr++) {
            Progress();
        }
    }

    private int GenerateStatValue(int minValue = 60, int maxValue = 77, float scale = 1f)
    {
        int result = (int)(Player.rand.Next(minValue, maxValue) * scale);
        return result > 99 ? 99 : result;
    }

    private void IncreaseStatValues(List<Stat> stats)
    {
        foreach (Stat stat in stats)
        {
            this.stats.GetStat(stat).value = GenerateStatValue(72, 84, scale);
        }
    }

    private void DecreaseStatValues(List<Stat> stats)
    {
        foreach (Stat stat in stats)
        {
            this.stats.GetStat(stat).value = GenerateStatValue(40, 64, scale);
        }
    }

    public void Progress() {
        year++;
        foreach (PlayerStat stat in stats) {
            stat.value = GenerateStatValue(stat.value, stat.value + 4); //increase by up to 3
        }
        foreach (PlayerStat stat in importantStats) {
            stat.value = GenerateStatValue(stat.value, stat.value + 5); //increase by up to 4 more
        }
    }

    public void GenerateStats()
    {
        GenerateBaseStats();
        IncreaseStatValues(position.importantStats);
        DecreaseStatValues(position.lowerStats);
    }

    private void GenerateBaseStats()
    {
        stats.Add(new PlayerStat(Stat.Speed, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Acceleration, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Agility, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Strength, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Awareness, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Stamina, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Injury, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.ThrowPower, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.ShortThrowAccuracy, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.MediumThrowAccuracy, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.DeepThrowAccuracy, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Playaction, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.ThrowingOnTheRun, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.BreakTackle, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Carrying, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Elusiveness, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Catching, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.CatchInTraffic, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.ShortRouteRunning, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.MediumRouteRunning, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.DeepRouteRunning, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Release, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.PassBlock, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.RunBlock, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.LeadBlock, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.ImpactBlocking, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.PlayRecognition, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Tackle, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.HitPower, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.BlockShedding, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.ManCoverage, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.ZoneCoverage, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.Press, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.KickAccuracy, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.KickPower, GenerateStatValue(scale: scale)));
        stats.Add(new PlayerStat(Stat.KickReturn, GenerateStatValue(scale: scale)));
    }
}
