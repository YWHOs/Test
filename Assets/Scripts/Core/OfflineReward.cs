using System;
using TMPro;
using UnityEngine;

public class OfflineReward : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI rewardText;
    [SerializeField] Treasure treasure;

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

        int rewardAmount = timeDif.Hours * 3600 + timeDif.Minutes * 60 + timeDif.Seconds;
        if (rewardText)
        {
            rewardText.text = timeDif.Hours + "H : " + timeDif.Minutes + "M : " + timeDif.Seconds + "S" + "\n" + "<color=yellow>" + rewardAmount + "</color>";
        }
        treasure?.ChangeGold(rewardAmount);
    }
}
