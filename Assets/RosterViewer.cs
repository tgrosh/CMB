using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosterViewer : MonoBehaviour
{
    public Transform content;
    public PlayerRow playerRowPrefab;
    public GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        FillList();
    }

    void FillList() {
        foreach (Player player in gameData.currentSchool.players) {
            PlayerRow playerRow = Instantiate(playerRowPrefab, content);
            playerRow.SetPlayer(player);
        }
    }
}
