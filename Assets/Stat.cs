public class Stat {
    public string name;
    public string abbreviation;

    public Stat(string name, string abbreviation)
    {
        this.name = name;
        this.abbreviation = abbreviation;
    }

    public static Stat Strength = new Stat("Strength", "Str");
    public static Stat Agility = new Stat("Agility", "Agi");
    public static Stat Speed = new Stat("Speed", "Spd");
    public static Stat Intelligence = new Stat("Intelligence", "Int");
    public static Stat Injury = new Stat("Injury", "Inj");
}

