using System;
using System.Collections.Generic;

public class Player
{
    public string name;
    public PlayerPosition position;
    public string origin;
    public int year;
    public int age;
    public bool hasScholarship;
    public bool isRedshirt;
    public PlayerStats stats;

    System.Random rand = new System.Random(DateTime.Now.Millisecond + DateTime.Now.Second);

    public Player(PlayerPosition position)
    {
        this.name = RandomName.Generate(Sex.Male);
        this.year = 0;
        this.age = rand.Next(18, 20);
        this.position = position;
        this.origin = RandomCity.Generate();
        this.stats = new PlayerStats();
        GenerateStats();
    }

    private int GenerateStatValue(int minValue = 65, int maxValue = 92)
    {

        return rand.Next(minValue, maxValue);
    }

    private void IncreaseStatValues(List<Stat> stats)
    {
        foreach (Stat stat in stats)
        {
            this.stats.GetStat(stat).value = GenerateStatValue(75, 95);
        }
    }

    private void DecreaseStatValues(List<Stat> stats)
    {
        foreach (Stat stat in stats)
        {
            this.stats.GetStat(stat).value = GenerateStatValue(62, 75);
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
        stats.Add(new PlayerStat(Stat.Speed, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Acceleration, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Agility, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Strength, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Awareness, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Stamina, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Injury, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.ThrowPower, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.ShortThrowAccuracy, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.MediumThrowAccuracy, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.DeepThrowAccuracy, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Playaction, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.ThrowingOnTheRun, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.BreakTackle, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Carrying, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Elusiveness, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Catching, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.CatchInTraffic, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.ShortRouteRunning, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.MediumRouteRunning, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.DeepRouteRunning, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Release, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.PassBlock, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.RunBlock, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.LeadBlock, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.ImpactBlocking, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.PlayRecognition, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Tackle, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.HitPower, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.BlockShedding, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.ManCoverage, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.ZoneCoverage, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.Press, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.KickAccuracy, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.KickPower, GenerateStatValue()));
        stats.Add(new PlayerStat(Stat.KickReturn, GenerateStatValue()));
    }
}
