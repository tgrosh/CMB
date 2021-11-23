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
    object currentSortColumn;

    private void OnEnable()
    {
        if (gameData.currentSchool != null)
        {
            sortedPlayers = gameData.currentSchool.players;
            SortListByProp("overall");
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

    void OnSortEvent(Stat stat, string propName, string fieldName)
    {
        if (stat != null)
        {
            if (currentSortColumn == null || ((Stat)currentSortColumn).abbreviation != stat.abbreviation) currentSortDescending = false;
            currentSortColumn = stat;
            SortListByStat(stat);
        }
        else if (!string.IsNullOrEmpty(fieldName))
        {
            if (currentSortColumn == null || currentSortColumn.GetType() == typeof(string) && (string)currentSortColumn != fieldName) currentSortDescending = false;
            currentSortColumn = fieldName;
            SortListByField(fieldName);
        }
        else if (!string.IsNullOrEmpty(propName))
        {
            if (currentSortColumn == null || currentSortColumn.GetType() == typeof(string) && (string)currentSortColumn != propName) currentSortDescending = false;
            currentSortColumn = propName;
            SortListByProp(propName);
        }
    }

    void SortListByField(string fieldName)
    {
        if (fieldName == "name") {
            Sort<string>(player => (string)player.GetType().GetField(fieldName).GetValue(player));
        } else {
            Sort<int>(player => (int)player.GetType().GetField(fieldName).GetValue(player));
        }
    }

    void SortListByProp(string propName)
    {
        if (propName == "positionAbbreviation") {
            Sort<string>(player => (string)player.GetType().GetProperty(propName).GetValue(player));
        } else {
            Sort<int>(player => (int)player.GetType().GetProperty(propName).GetValue(player));
        }
    }

    void SortListByStat(Stat stat)
    {
        Sort<int>(player => player.stats.GetStat(stat).value);
    }

    void Sort<T>(System.Func<Player, T> func)
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
