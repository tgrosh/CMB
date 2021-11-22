using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SchoolOverview : MonoBehaviour
{
    public GameData gameData;
    public TMPro.TextMeshProUGUI schoolName;
    public TMPro.TextMeshProUGUI schoolMascotName;
    public TMPro.TextMeshProUGUI schoolLocation;
    public TMPro.TextMeshProUGUI offGrade;
    public TMPro.TextMeshProUGUI defGrade;
    public TMPro.TextMeshProUGUI overallGrade;
    public Image schoolMascotLogo;
    public Image schoolMascotLogoBackground;
    public Image background;
    public Transform topPlayersContainer;
    public PlayerGrade playerGradePrefab;
    
    private void OnEnable() {
        if (this.gameData.currentSchool == null) return;

        SetSchool(this.gameData.currentSchool);        
    }

    public void SetSchool(School school) {
        this.schoolName.text = school.name;
        this.schoolMascotName.text = school.mascot.name;
        this.schoolLocation.text = school.location;
        this.schoolMascotLogo.sprite = this.schoolMascotLogoBackground.sprite = school.mascot.logo;

        this.schoolName.color = school.secondaryColor;
        this.schoolMascotName.color = school.primaryColor;

        foreach (Player player in getTopPlayers(school)) {
            PlayerGrade playerGrade = Instantiate<PlayerGrade>(playerGradePrefab, topPlayersContainer);
            playerGrade.SetPlayer(player);
        }

        this.offGrade.text = convertToLetterGrade(this.getOverallOffense(school));
        this.defGrade.text = convertToLetterGrade(this.getOverallDefense(school));
        this.overallGrade.text = convertToLetterGrade(this.getOverall(school));
    }

    private List<Player> getTopPlayers(School school)
    {
        return school.players.OrderByDescending(player => player.importantStats.overall).Take<Player>(6).ToList<Player>();
    }

    public int getOverallDefense(School school) {
        return (int)school.players.Where(player => player.position.positionGroup == PositionGroup.Defense).Select(player => player.importantStats.overall).Average();
    }

    public int getOverallOffense(School school) {
        return (int)school.players.Where(player => player.position.positionGroup == PositionGroup.Offense).Select(player => player.importantStats.overall).Average();
    }

    public int getOverall(School school) {
        return (int)school.players.Select(player => player.importantStats.overall).Average();
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
