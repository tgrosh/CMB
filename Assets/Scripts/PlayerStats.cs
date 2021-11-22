using System.Collections.Generic;
using System.Linq;

public class PlayerStats: List<PlayerStat>
{
    public PlayerStats(IEnumerable<PlayerStat> collection) : base(collection)
    {
    }

    public PlayerStats()
    {
    }

    public PlayerStat GetStat(Stat stat) {
        return this.Find(playerStat => playerStat.stat == stat);
    }

    public int overall {
        get {
            return (int)this.Select(stat => stat.value).Average();
        }
    }

    public string grade {
        get {
            return convertToLetterGrade(this.overall);
        }
    }

    private string convertToLetterGrade(int numberGrade)
    {
        string letter = "F";

        if (numberGrade >= 96)
        {
            letter = "A+";
        }
        else if (numberGrade >= 93)
        {
            letter = "A";
        }
        else if (numberGrade >= 90)
        {
            letter = "A-";
        }
        else if (numberGrade >= 86)
        {
            letter = "B+";
        }
        else if (numberGrade >= 83)
        {
            letter = "B";
        }
        else if (numberGrade >= 80)
        {
            letter = "B-";
        }
        else if (numberGrade >= 76)
        {
            letter = "C+";
        }
        else if (numberGrade >= 73)
        {
            letter = "C";
        }
        else if (numberGrade >= 70)
        {
            letter = "C-";
        }
        else if (numberGrade >= 66)
        {
            letter = "D+";
        }
        else if (numberGrade >= 63)
        {
            letter = "D";
        }
        else if (numberGrade >= 60)
        {
            letter = "D-";
        }

        return letter;
    }

}