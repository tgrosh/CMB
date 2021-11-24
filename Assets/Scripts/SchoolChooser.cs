using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolChooser : MonoBehaviour
{
    public TMPro.TextMeshProUGUI schoolName;
    public TMPro.TextMeshProUGUI schoolMascotName;
    public Image schoolLogo;
    public SchoolGrades schoolGrades;

    public GameData gameData;
    public UIEvents uIEvents;
    public int currentSchoolIndex;


    // Start is called before the first frame update
    void Start()
    {
        currentSchoolIndex = 0;
    }

    private void OnEnable() {
        if (gameData.allSchools != null && gameData.allSchools.Count > 0) {
            ShowSchool();
        }
    }

    void ShowSchool() {
        School currentSchool = gameData.allSchools[currentSchoolIndex];

        schoolName.text = currentSchool.name;
        schoolMascotName.gameObject.SetActive(false);
        schoolMascotName.text = currentSchool.mascot.name;
        schoolMascotName.color = currentSchool.primaryColor;
        schoolMascotName.outlineColor = GetLuminance(currentSchool.primaryColor) > .15f ? Color.black : Color.white;
        schoolMascotName.gameObject.SetActive(true);        
        schoolLogo.sprite = currentSchool.mascot.logo;

        schoolGrades.SetGrades(currentSchool);
    }

    float GetLuminance(Color color) {
        return color.r * 0.2126f + color.g * 0.7152f + color.b * 0.0722f;
    }
    public void SelectNextSchool() {
        currentSchoolIndex++;
        if (currentSchoolIndex >= gameData.allSchools.Count) {
            currentSchoolIndex = 0;
        }
        ShowSchool();
    }

    public void SelectPrevSchool() {
        currentSchoolIndex--;
        if (currentSchoolIndex < 0) {
            currentSchoolIndex = gameData.allSchools.Count - 1;
        }
        ShowSchool();
    }

    public void ChooseCurrentSchool() {
        uIEvents.SetSchool(gameData.allSchools[currentSchoolIndex]);
    }
}
