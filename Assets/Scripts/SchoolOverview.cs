using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SchoolOverview : MonoBehaviour
{
    public Image background;
    public Transform topPlayersContainer;
    public PlayerGrade playerGradePrefab;
    public SchoolGrades schoolGrades;

    private void OnEnable()
    {
        if (GameData.currentSchool == null) return;

        SetSchool();
    }

    public void SetSchool()
    {
        foreach (Player player in getTopPlayers())
        {            
            PlayerGrade playerGrade = Instantiate<PlayerGrade>(playerGradePrefab, topPlayersContainer);
            playerGrade.SetPlayer(player);
        }

        schoolGrades.SetGrades(GameData.currentSchool);
    }

    private List<Player> getTopPlayers()
    {
        return GameData.currentSchool.players.OrderByDescending(player => player.overall).Take<Player>(6).ToList<Player>();
    }
}
