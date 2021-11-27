using System.Collections.Generic;
using System.Linq;

public class Rankings
{
    public static List<School> Top20() {
        return GameData.allSchools.OrderByDescending(school => school.overall).Take(20).ToList();
    }

    public static int GetSchoolRanking(School school) {
        return GameData.allSchools.OrderByDescending(school => school.overall).Take(20).ToList().IndexOf(school) + 1;
    }

}