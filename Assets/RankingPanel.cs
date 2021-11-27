using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingPanel : MonoBehaviour
{    
    public TMPro.TextMeshProUGUI rankingText;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetRanking(int ranking) {
        gameObject.SetActive(ranking > 0);
        rankingText.text = "#" + ranking.ToString();
    }
}
