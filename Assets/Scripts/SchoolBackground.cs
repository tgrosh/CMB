using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolBackground : MonoBehaviour
{
    public Image schoolMascotLogoBackground;

    private void OnEnable()
    {
        if (GameData.currentSchool == null) return;

        SetSchool();
    }

    public void SetSchool()
    {
        this.schoolMascotLogoBackground.sprite = GameData.currentSchool.mascot.logo;
    }
}
