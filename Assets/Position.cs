public class PlayerPosition
{
    public string name;
    public PlayerPositionAbbreviation abbreviation;

    public PlayerPosition(string name, PlayerPositionAbbreviation abbreviation)
    {
        this.name = name;
        this.abbreviation = abbreviation;
    }

    public static PlayerPosition QB = new PlayerPosition("Quarterback", PlayerPositionAbbreviation.QB);
    public static PlayerPosition HB = new PlayerPosition("Halfback", PlayerPositionAbbreviation.HB);
    public static PlayerPosition FB = new PlayerPosition("Fullback", PlayerPositionAbbreviation.FB);
    public static PlayerPosition WR = new PlayerPosition("Wide Receiver", PlayerPositionAbbreviation.WR);
    public static PlayerPosition TE = new PlayerPosition("Tight End", PlayerPositionAbbreviation.TE);
    public static PlayerPosition T = new PlayerPosition("Tackle", PlayerPositionAbbreviation.T);
    public static PlayerPosition G = new PlayerPosition("Guard", PlayerPositionAbbreviation.G);
    public static PlayerPosition C = new PlayerPosition("Center", PlayerPositionAbbreviation.C);
    public static PlayerPosition DE = new PlayerPosition("Defensive End", PlayerPositionAbbreviation.DE);
    public static PlayerPosition DT = new PlayerPosition("Defensive Tackle", PlayerPositionAbbreviation.DT);
    public static PlayerPosition ILB = new PlayerPosition("Inside Linebacker", PlayerPositionAbbreviation.ILB);
    public static PlayerPosition OLB = new PlayerPosition("Outside Linebacker", PlayerPositionAbbreviation.OLB);
    public static PlayerPosition CB = new PlayerPosition("Cornerback", PlayerPositionAbbreviation.CB);
    public static PlayerPosition FS = new PlayerPosition("Free Safety", PlayerPositionAbbreviation.FS);
    public static PlayerPosition SS = new PlayerPosition("Strong Safety", PlayerPositionAbbreviation.SS);
    public static PlayerPosition K = new PlayerPosition("Kicker", PlayerPositionAbbreviation.K);
    public static PlayerPosition P = new PlayerPosition("Punter", PlayerPositionAbbreviation.P);
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