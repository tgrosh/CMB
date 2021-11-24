using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerRow : MonoBehaviour
{
    public GameObject dataColumnPrefab;

    public UnityEvent<Stat, string, string> sortEvent; // stat, prop, field

    public void SetHeader()
    {
        sortEvent = new UnityEvent<Stat, string, string>();

        CreateColumn("Pos", action: () => sortEvent.Invoke(null, "positionAbbreviation", ""));
        CreateColumn("Name", 160, TMPro.TextAlignmentOptions.Left, action: () => sortEvent.Invoke(null, "", "name"));
        CreateColumn("OVR", action: () => sortEvent.Invoke(null, "overall", ""));
        foreach (PlayerStat playerStat in new Player(PlayerPosition.C, 0f).stats)
        {
            CreateColumn(playerStat.stat.abbreviation.ToUpper(), action: () => sortEvent.Invoke(playerStat.stat, "", ""));
        }
        GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    public void SetPlayer(Player player, int rowIndex)
    {
        CreateColumn(player.position.abbreviation.ToString());
        CreateColumn(player.name, 160, TMPro.TextAlignmentOptions.Left);
        CreateColumn(player.stats.overall.ToString());

        foreach (PlayerStat playerStat in player.stats)
        {
            CreateColumn(playerStat.value.ToString());
        }

        if (rowIndex % 2 == 0)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
    }

    void CreateColumn(string value, float width = 44, TMPro.TextAlignmentOptions alignment = TMPro.TextAlignmentOptions.Center, UnityAction action = null)
    {
        GameObject statColumn = Instantiate(dataColumnPrefab, transform);
        TMPro.TextMeshProUGUI colText = statColumn.GetComponent<TMPro.TextMeshProUGUI>();
        colText.text = value;
        colText.alignment = alignment;
        RectTransform rect = statColumn.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(width, rect.sizeDelta.y);
        if (action != null)
        {
            Button button = statColumn.GetComponent<Button>();
            button.enabled = true;
            button.onClick.AddListener(() => action());
        }

    }

}
