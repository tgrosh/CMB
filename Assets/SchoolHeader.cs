using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolHeader : MonoBehaviour
{
    public GameData gameData;
    public TMPro.TextMeshProUGUI schoolName;
    public TMPro.TextMeshProUGUI schoolMascotName;
    public TMPro.TextMeshProUGUI schoolLocation;
    public Image schoolMascotLogo;

    // Start is called before the first frame update
    private void OnEnable()
    {
        if (this.gameData.currentSchool == null) return;

        SetSchool();
    }

    public void SetSchool()
    {
        this.schoolName.text = gameData.currentSchool.name;
        this.schoolMascotName.text = gameData.currentSchool.mascot.name;
        this.schoolLocation.text = gameData.currentSchool.location;
        this.schoolMascotLogo.sprite = gameData.currentSchool.mascot.logo;
        this.schoolName.color = gameData.currentSchool.secondaryColor;
        this.schoolMascotName.color = gameData.currentSchool.primaryColor;
    }
}
