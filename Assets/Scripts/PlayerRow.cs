using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRow : MonoBehaviour
{
    public GameObject dataColumnPrefab;

    public void SetHeader() {
        CreateColumn("Pos");
        CreateColumn("Name", 200, TMPro.TextAlignmentOptions.Left);
        foreach (PlayerStat playerStat in new Player("", PlayerPosition.C).stats) {
            CreateColumn(playerStat.stat.abbreviation.ToUpper());
        }
        GetComponent<Image>().color = new Color(0,0,0,0);
    }

    public void SetPlayer(Player player, int rowIndex) {
        CreateColumn(player.position.abbreviation.ToString());
        CreateColumn(player.name, 200, TMPro.TextAlignmentOptions.Left);

        foreach (PlayerStat playerStat in player.stats) {
            CreateColumn(playerStat.value.ToString());
        }

        if (rowIndex % 2 == 0) {
            GetComponent<Image>().color = new Color(0,0,0,0);
        }
    }

    void CreateColumn(string value, float width = 56, TMPro.TextAlignmentOptions alignment = TMPro.TextAlignmentOptions.Center) {
        GameObject statColumn = Instantiate(dataColumnPrefab, transform);
        TMPro.TextMeshProUGUI colText = statColumn.GetComponent<TMPro.TextMeshProUGUI>();
        colText.text = value;
        colText.alignment = alignment;
        RectTransform rect = statColumn.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(width, rect.sizeDelta.y);
    }
}
