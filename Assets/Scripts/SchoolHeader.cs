using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolHeader : MonoBehaviour
{
    public TMPro.TextMeshProUGUI schoolName;
    public TMPro.TextMeshProUGUI schoolMascotName;
    public TMPro.TextMeshProUGUI schoolLocation;
    public Image schoolMascotLogo;

    // Start is called before the first frame update
    private void OnEnable()
    {
        if (GameData.currentSchool == null) return;

        SetSchool();
    }

    public void SetSchool()
    {
        this.schoolName.text = GameData.currentSchool.name;
        this.schoolMascotName.text = GameData.currentSchool.mascot.name;
        this.schoolLocation.text = GameData.currentSchool.location;
        this.schoolMascotLogo.sprite = GameData.currentSchool.mascot.logo;
        this.schoolName.color = GameData.currentSchool.secondaryColor;
        this.schoolMascotName.color = GameData.currentSchool.primaryColor;
    }
}
