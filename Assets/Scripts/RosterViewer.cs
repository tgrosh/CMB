using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosterViewer : MonoBehaviour
{
    public Transform content;
    public PlayerRow playerRowPrefab;
    public GameData gameData;

    private void OnEnable() {
        ClearList();
        FillList();
    }

    void FillList() {        
        PlayerRow playerRow = Instantiate(playerRowPrefab, content);
        playerRow.SetHeader();
        int rowIndex = 0;

        foreach (Player player in gameData.currentSchool.players) {
            playerRow = Instantiate(playerRowPrefab, content);
            playerRow.SetPlayer(player, rowIndex);
            rowIndex++;
        }
    }

    void ClearList() {
        foreach (Transform child in content.transform) {
            Destroy(child.gameObject);
        }
    }
}
