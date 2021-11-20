using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolChooser : MonoBehaviour
{
    public GameData gameData;
    public UIEvents uIEvents;
    public int currentSchoolIndex;


    // Start is called before the first frame update
    void Start()
    {
        currentSchoolIndex = 0;
    }

    private void OnEnable() {
        ShowSchool();        
    }

    void ShowSchool() {
        School currentSchool = gameData.allSchools[currentSchoolIndex];

        transform.Find("SchoolName").GetComponent<TMPro.TextMeshProUGUI>().text = currentSchool.name;

        TMPro.TextMeshProUGUI tm = transform.Find("SchoolMascot").GetComponent<TMPro.TextMeshProUGUI>();
        tm.gameObject.SetActive(false);
        tm.text = currentSchool.mascot.name;
        tm.color = currentSchool.primaryColor;
        tm.outlineColor = GetLuminance(currentSchool.primaryColor) > .15f ? Color.black : Color.white;
        tm.gameObject.SetActive(true);
        
        transform.Find("Logo").GetComponent<Image>().sprite = currentSchool.mascot.logo;
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
