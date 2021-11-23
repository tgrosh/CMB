using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RosterViewer : MonoBehaviour
{
    public Transform content;
    public PlayerRow playerRowPrefab;
    public GameData gameData;

    List<Player> sortedPlayers;

    bool currentSortDescending = false;

    private void OnEnable()
    {
        if (gameData.currentSchool != null)
        {
            sortedPlayers = gameData.currentSchool.players;
            SortList("overall");
            ClearList();
            FillList();
        }
    }

    void FillList()
    {
        PlayerRow headerRow = Instantiate(playerRowPrefab, content);
        headerRow.SetHeader();
        headerRow.sortEvent.AddListener(OnSortEvent);

        int rowIndex = 0;
        foreach (Player player in sortedPlayers)
        {
            PlayerRow playerRow = Instantiate(playerRowPrefab, content);
            playerRow.SetPlayer(player, rowIndex);
            rowIndex++;
        }
    }

    void OnSortEvent(Stat stat, string propName)
    {
        if (string.IsNullOrEmpty(propName) && stat != null)
        {
            SortListByStat(stat);
        }
    }

    void SortList(string fieldName)
    {
        Sort(player => (int)player.stats.GetType().GetProperty(fieldName).GetValue(player.stats));
    }

    void SortListByStat(Stat stat)
    {
        Sort(player => player.stats.GetStat(stat).value);
    }

    void Sort(System.Func<Player, int> func)
    {
        currentSortDescending = !currentSortDescending;

        if (currentSortDescending)
        {
            sortedPlayers = sortedPlayers.OrderByDescending(func).ToList();
        }
        else
        {
            sortedPlayers = sortedPlayers.OrderBy(func).ToList();
        }
        ClearList();
        FillList();
    }

    void ClearList()
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
