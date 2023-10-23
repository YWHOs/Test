using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OfflineReward : MonoBehaviour
{
    TextMeshProUGUI rewardText;
    Treasure treasure;
    void Awake()
    {
        rewardText = GetComponentInChildren<TextMeshProUGUI>();
        treasure = FindObjectOfType<Treasure>();
    }
    void Start()
    {
        PlayerStartTime();
    }

    void OnApplicationQuit()
    {
        PlayerQuitTime();
    }

    void PlayerQuitTime()
    {
        DateTime now = DateTime.Now;
        PlayerPrefs.SetString("Offline", now.ToString());
    }
    void PlayerStartTime()
    {
        string time = PlayerPrefs.GetString("Offline");
        DateTime now = Convert.ToDateTime(time);
        DateTime currentTime = DateTime.Now;
        TimeSpan timeDif = currentTime - now;

        if(rewardText)
        {
            rewardText.text = timeDif.Hours + "H : " + timeDif.Minutes + "M : " + timeDif.Seconds + "S";
        }
        int rewardAmount = timeDif.Hours * 3600 + timeDif.Minutes * 60 + timeDif.Seconds;
        treasure?.ChangeGold(rewardAmount);
    }
}
