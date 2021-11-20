public class Stat {
    public string name;
    public string abbreviation;

    public Stat(string name, string abbreviation)
    {
        this.name = name;
        this.abbreviation = abbreviation;
    }

    public static Stat Acceleration = new Stat("Acceleration", "Acc");
    public static Stat Agility = new Stat("Agility", "Agi");
    public static Stat Awareness = new Stat("Awareness", "Awr");
    public static Stat Injury = new Stat("Injury", "Inj");
    public static Stat Speed = new Stat("Speed", "Spd");
    public static Stat Stamina = new Stat("Stamina", "Sta");
    public static Stat Strength = new Stat("Strength", "Str");
    public static Stat DeepThrowAccuracy = new Stat("DeepThrowAccuracy", "Dac");
    public static Stat MediumThrowAccuracy = new Stat("MediumThrowAccuracy", "Mac");
    public static Stat Playaction = new Stat("Playaction", "Pac");
    public static Stat ThrowingOnTheRun = new Stat("ThrowingOnTheRun", "Run");
    public static Stat ShortThrowAccuracy = new Stat("ShortThrowAccuracy", "Sac");
    public static Stat ThrowPower = new Stat("ThrowPower", "Thp");
    public static Stat BreakTackle = new Stat("BreakTackle", "Btk");
    public static Stat Carrying = new Stat("Carrying", "Car");
    public static Stat Elusiveness = new Stat("Elusiveness", "Elu");
    public static Stat CatchInTraffic = new Stat("CatchInTraffic", "Cit");
    public static Stat Catching = new Stat("Catching", "Cth");
    public static Stat DeepRouteRunning = new Stat("DeepRouteRunning", "Drr");
    public static Stat MediumRouteRunning = new Stat("MediumRouteRunning", "Mrr");
    public static Stat Release = new Stat("Release", "Rls");
    public static Stat ShortRouteRunning = new Stat("ShortRouteRunning", "Srr");
    public static Stat ImpactBlocking = new Stat("ImpactBlocking", "Ibl");
    public static Stat LeadBlock = new Stat("LeadBlock", "Lbk");
    public static Stat PassBlock = new Stat("PassBlock", "Pbk");
    public static Stat RunBlock = new Stat("RunBlock", "Rbk");
    public static Stat BlockShedding = new Stat("BlockShedding", "Bsh");
    public static Stat ManCoverage = new Stat("ManCoverage", "Mcv");
    public static Stat HitPower = new Stat("HitPower", "Pow");
    public static Stat PlayRecognition = new Stat("PlayRecognition", "Prc");
    public static Stat Press = new Stat("Press", "Prs");
    public static Stat Tackle = new Stat("Tackle", "Tak");
    public static Stat ZoneCoverage = new Stat("ZoneCoverage", "Zcv");
    public static Stat KickAccuracy = new Stat("KickAccuracy", "Kac");
    public static Stat KickPower = new Stat("KickPower", "Kpw");
    public static Stat KickReturn = new Stat("KickReturn", "Ret");
}
