using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrade : MonoBehaviour
{
    public TMPro.TextMeshProUGUI position;
    public TMPro.TextMeshProUGUI playerName;
    public TMPro.TextMeshProUGUI grade;

    public void SetPlayer(Player player) {
        position.text = player.position.abbreviation.ToString();
        playerName.text = player.name;
        grade.text = player.overall.ToString();
    }
}
