using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRow : MonoBehaviour
{
    Player player;

    public void SetPlayer(Player player) {
        this.player = player;

        transform.Find("PlayerName").GetComponent<TMPro.TextMeshProUGUI>().text = player.name;
        transform.Find("Pos").GetComponent<TMPro.TextMeshProUGUI>().text = player.position.abbreviation.ToString();

        foreach (PlayerStat playerStat in player.stats) {
            transform.Find(playerStat.stat.abbreviation).GetComponent<TMPro.TextMeshProUGUI>().text = playerStat.value.ToString();
        }
    }
}
