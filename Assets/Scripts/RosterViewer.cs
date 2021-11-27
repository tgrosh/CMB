using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RosterViewer : MonoBehaviour
{
    public Transform content;
    public PlayerRow playerRowPrefab;
    public SchoolGrades schoolGrades;
    public TMPro.TextMeshProUGUI positionFilterLabel;

    List<Player> sortedPlayers;
    PlayerPositionAbbreviation[] positions = (PlayerPositionAbbreviation[])Enum.GetValues(typeof(PlayerPositionAbbreviation));
    int currentPosition = -1;

    bool currentSortDescending = false;
    object currentSortColumn;

    private void OnEnable()
    {
        if (GameData.currentSchool != null)
        {
            sortedPlayers = GameData.currentSchool.players;
            schoolGrades.SetGrades(GameData.currentSchool);
            
            SortListByProp("overall");
            ClearList();            
            FillList(sortedPlayers);
        }
    }

    void FillList(List<Player> players)
    {
        PlayerRow headerRow = Instantiate(playerRowPrefab, content);
        headerRow.SetHeader();
        headerRow.sortEvent.AddListener(OnSortEvent);

        int rowIndex = 0;
        foreach (Player player in players)
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
            if ((Stat)currentSortColumn != stat) currentSortDescending = false;
            currentSortColumn = stat;
            SortListByStat(stat);
        }
        else if (!string.IsNullOrEmpty(fieldName))
        {
            if ((string)currentSortColumn != fieldName) currentSortDescending = false;
            currentSortColumn = fieldName;
            SortListByField(fieldName);
        }
        else if (!string.IsNullOrEmpty(propName))
        {
            if ((string)currentSortColumn != propName) currentSortDescending = false;
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
        FillList(sortedPlayers);
    }

    void ClearList()
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }

    void FilterList() {
        ClearList();
        if (currentPosition == -1) {
            FillList(sortedPlayers);
            positionFilterLabel.text = "All Positions";
        } else {
            FillList(sortedPlayers.Where(player => player.position.abbreviation == positions[currentPosition]).ToList());
            positionFilterLabel.text = positions[currentPosition].ToString();
        }
    }

    public void SelectNextPosition() {
        currentPosition++;
        if (currentPosition > positions.Length - 1) {
            currentPosition = -1;
        }
        FilterList();        
    }

    public void SelectPrevPosition() {
        currentPosition--;
        if (currentPosition < -1) {
            currentPosition = positions.Length - 1;
        }
        FilterList();
    }
}
