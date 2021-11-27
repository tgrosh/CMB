using System.Collections.Generic;
using System.Linq;

public class Rankings
{
    public static List<School> schools;

    public static List<School> Top20(List<School> schools) {
        return schools.OrderByDescending(school => school.overall).Take(20).ToList();
    }

}