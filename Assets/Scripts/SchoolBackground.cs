using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolBackground : MonoBehaviour
{
    public GameData gameData;
    public Image schoolMascotLogoBackground;

    private void OnEnable()
    {
        if (this.gameData.currentSchool == null) return;

        SetSchool();
    }

    public void SetSchool()
    {
        this.schoolMascotLogoBackground.sprite = gameData.currentSchool.mascot.logo;
    }
}
