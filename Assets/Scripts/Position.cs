using System.Collections.Generic;

public class PlayerPosition
{
    public string name;
    public PlayerPositionAbbreviation abbreviation;
    public List<Stat> importantStats = new List<Stat>();
    public List<Stat> lowerStats = new List<Stat>();

    public PlayerPosition(string name, PlayerPositionAbbreviation abbreviation)
    {
        this.name = name;
        this.abbreviation = abbreviation;
    }

    public PlayerPosition(string name, PlayerPositionAbbreviation abbreviation, List<Stat> importantStats, List<Stat> lowerStats) : this(name, abbreviation)
    {
        this.importantStats = importantStats;
        this.lowerStats = lowerStats;
    }

    static List<Stat> defStats
    {
        get
        {
            return new List<Stat>() {
                Stat.BlockShedding,
                Stat.HitPower,
                Stat.ManCoverage,
                Stat.PlayRecognition,
                Stat.Press,
                Stat.Tackle,
                Stat.ZoneCoverage
            };
        }
    }

    static List<Stat> offStats
    {
        get
        {
            return new List<Stat>() {
                Stat.BreakTackle,
                Stat.Carrying,
                Stat.Catching,
                Stat.CatchInTraffic,
                Stat.DeepRouteRunning,
                Stat.ShortRouteRunning,
                Stat.MediumRouteRunning,
                Stat.DeepThrowAccuracy,
                Stat.ThrowingOnTheRun,
                Stat.ThrowPower,
                Stat.ShortThrowAccuracy,
                Stat.MediumThrowAccuracy,
                Stat.Elusiveness,
                Stat.ImpactBlocking,
                Stat.RunBlock,
                Stat.LeadBlock,
                Stat.PassBlock,
                Stat.Playaction,
                Stat.Release
            };
        }
    }

    static List<Stat> nonKStats
    {
        get
        {
            List<Stat> result = new List<Stat>(offStats);
            result.AddRange(defStats);
            return result;
        }
    }

    public static PlayerPosition QB = new PlayerPosition("Quarterback", PlayerPositionAbbreviation.QB, new List<Stat>() {
                Stat.Playaction,
                Stat.ThrowingOnTheRun,
                Stat.ThrowPower,
                Stat.DeepThrowAccuracy,
                Stat.ShortThrowAccuracy,
                Stat.MediumThrowAccuracy,
                Stat.Awareness
            }, defStats);
    public static PlayerPosition HB = new PlayerPosition("Halfback", PlayerPositionAbbreviation.HB, new List<Stat>() {
                Stat.Carrying,
                Stat.Acceleration,
                Stat.Agility,
                Stat.Speed,
                Stat.BreakTackle,
                Stat.Elusiveness,
                Stat.KickReturn
            }, defStats);
    public static PlayerPosition FB = new PlayerPosition("Fullback", PlayerPositionAbbreviation.FB, new List<Stat>() {
                Stat.Carrying,
                Stat.LeadBlock,
                Stat.ShortRouteRunning,
                Stat.BreakTackle
            }, defStats);
    public static PlayerPosition WR = new PlayerPosition("Wide Receiver", PlayerPositionAbbreviation.WR, new List<Stat>() {
                Stat.Catching,
                Stat.CatchInTraffic,
                Stat.DeepRouteRunning,
                Stat.ShortRouteRunning,
                Stat.MediumRouteRunning,
                Stat.Release,
                Stat.Acceleration,
                Stat.Agility,
                Stat.Speed,
                Stat.KickReturn
            }, defStats);
    public static PlayerPosition TE = new PlayerPosition("Tight End", PlayerPositionAbbreviation.TE, new List<Stat>() {
                Stat.Catching,
                Stat.CatchInTraffic,
                Stat.ShortRouteRunning,
                Stat.MediumRouteRunning,
                Stat.Release,
                Stat.Acceleration,
                Stat.Agility,
                Stat.RunBlock,
                Stat.PassBlock
            }, defStats);
    public static PlayerPosition T = new PlayerPosition("Tackle", PlayerPositionAbbreviation.T, new List<Stat>() {
                Stat.Strength,
                Stat.ImpactBlocking,
                Stat.RunBlock,
                Stat.PassBlock
            }, defStats);
    public static PlayerPosition G = new PlayerPosition("Guard", PlayerPositionAbbreviation.G, new List<Stat>() {
                Stat.Strength,
                Stat.ImpactBlocking,
                Stat.RunBlock,
                Stat.PassBlock
            }, defStats);
    public static PlayerPosition C = new PlayerPosition("Center", PlayerPositionAbbreviation.C, new List<Stat>() {
                Stat.Strength,
                Stat.ImpactBlocking,
                Stat.RunBlock,
                Stat.PassBlock
            }, defStats);
    public static PlayerPosition DE = new PlayerPosition("Defensive End", PlayerPositionAbbreviation.DE, new List<Stat>() {
                Stat.Strength,
                Stat.BlockShedding,
                Stat.Tackle,
                Stat.HitPower,
                Stat.Acceleration
            }, offStats);
    public static PlayerPosition DT = new PlayerPosition("Defensive Tackle", PlayerPositionAbbreviation.DT, new List<Stat>() {
                Stat.Strength,
                Stat.BlockShedding,
                Stat.Tackle,
                Stat.HitPower
            }, offStats);
    public static PlayerPosition ILB = new PlayerPosition("Inside Linebacker", PlayerPositionAbbreviation.ILB, new List<Stat>() {
                Stat.Strength,
                Stat.BlockShedding,
                Stat.Tackle,
                Stat.HitPower,
                Stat.Acceleration,
                Stat.PlayRecognition
            }, offStats);
    public static PlayerPosition OLB = new PlayerPosition("Outside Linebacker", PlayerPositionAbbreviation.OLB, new List<Stat>() {
                Stat.Strength,
                Stat.BlockShedding,
                Stat.Tackle,
                Stat.HitPower,
                Stat.Acceleration,
                Stat.PlayRecognition
            }, offStats);
    public static PlayerPosition CB = new PlayerPosition("Cornerback", PlayerPositionAbbreviation.CB, new List<Stat>() {
                Stat.Speed,
                Stat.Agility,
                Stat.ManCoverage,
                Stat.ZoneCoverage,
                Stat.Acceleration
            }, offStats);
    public static PlayerPosition FS = new PlayerPosition("Free Safety", PlayerPositionAbbreviation.FS, new List<Stat>() {
                Stat.Agility,
                Stat.ZoneCoverage,
                Stat.Acceleration,
                Stat.Tackle,
                Stat.PlayRecognition
            }, offStats);
    public static PlayerPosition SS = new PlayerPosition("Strong Safety", PlayerPositionAbbreviation.SS, new List<Stat>() {
                Stat.Agility,
                Stat.ZoneCoverage,
                Stat.Acceleration,
                Stat.Tackle,
                Stat.HitPower,
                Stat.PlayRecognition
            }, offStats);
    public static PlayerPosition K = new PlayerPosition("Kicker", PlayerPositionAbbreviation.K, new List<Stat>() {
                Stat.KickAccuracy,
                Stat.KickPower
            }, nonKStats);
    public static PlayerPosition P = new PlayerPosition("Punter", PlayerPositionAbbreviation.P, new List<Stat>() {
                Stat.KickAccuracy,
                Stat.KickPower
            }, nonKStats);
}

public enum PlayerPositionAbbreviation
{
    QB, //3
    HB, //4
    FB, //1
    WR, //7
    TE, //4
    T, //4
    G, //4
    C, //3
    DE, //5
    DT, //5
    ILB, //3
    OLB, //4
    CB, //7
    FS, //3
    SS, //3
    K, //1
    P //1
}