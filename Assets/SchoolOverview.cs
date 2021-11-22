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
    }

    private List<Player> getTopPlayers(School school)
    {
        return school.players.OrderByDescending(player => player.importantStats.overall).Take<Player>(6).ToList<Player>();
    }
}
