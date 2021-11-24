using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SchoolOverview : MonoBehaviour
{
    public GameData gameData;
    public Image background;
    public Transform topPlayersContainer;
    public PlayerGrade playerGradePrefab;
    public SchoolGrades schoolGrades;

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

        schoolGrades.SetGrades(gameData.currentSchool);
    }

    private List<Player> getTopPlayers()
    {
        return gameData.currentSchool.players.OrderByDescending(player => player.overall).Take<Player>(6).ToList<Player>();
    }
}
