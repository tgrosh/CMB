using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosterViewer : MonoBehaviour
{
    public Transform content;
    public PlayerRow playerRowPrefab;
    public GameData gameData;

    private void OnEnable() {
        FillList();        
    }

    void FillList() {
        foreach (Player player in gameData.currentSchool.players) {
            PlayerRow playerRow = Instantiate(playerRowPrefab, content);
            playerRow.SetPlayer(player);
        }
    }
}
