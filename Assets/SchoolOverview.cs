using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SchoolOverview : MonoBehaviour
{
    public GameData gameData;
    public TMPro.TextMeshProUGUI offGrade;
    public TMPro.TextMeshProUGUI defGrade;
    public TMPro.TextMeshProUGUI overallGrade;
    public Image background;
    public Transform topPlayersContainer;
    public PlayerGrade playerGradePrefab;

    private void OnEnable()
    {
        if (this.gameData.currentSchool == null) return;

        SetSchool();
    }

    public void SetSchool()
    {
        foreach (Player player in getTopPlayers())
        {            
            PlayerGrade playerGrade = Instantiate<PlayerGrade>(playerGradePrefab, topPlayersContainer);
            playerGrade.SetPlayer(player);
        }

        this.offGrade.text = convertToLetterGrade(this.getOverallOffense());
        this.defGrade.text = convertToLetterGrade(this.getOverallDefense());
        this.overallGrade.text = convertToLetterGrade(this.getOverall());
    }

    private List<Player> getTopPlayers()
    {
        return gameData.currentSchool.players.OrderByDescending(player => player.overall).Take<Player>(6).ToList<Player>();
    }

    private int getOverallDefense()
    {
        return (int)gameData.currentSchool.players.Where(player => player.position.positionGroup == PositionGroup.Defense).Select(player => player.importantStats.overall).Average();
    }

    private int getOverallOffense()
    {
        return (int)gameData.currentSchool.players.Where(player => player.position.positionGroup == PositionGroup.Offense).Select(player => player.importantStats.overall).Average();
    }

    public int getOverall()
    {
        return (int)gameData.currentSchool.players.Select(player => player.importantStats.overall).Average();
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
