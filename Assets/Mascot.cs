using UnityEngine;

public class Mascot
{
    public string name;
    public Sprite logo;

    public Mascot(string name, string logo = "UI_Icon_Skull")
    {
        this.name = name;
        this.logo = Resources.Load<Sprite>("logos/" + logo);
    }
}
