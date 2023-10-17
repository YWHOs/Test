using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI valueText;
    public TextMeshProUGUI nameText;
    public Image iconImage;
    int level;
    public int Level { set { level = value; } }


    public void UpgradeButtonClick()
    {
        level++;
        levelText.text = "Lv " + level.ToString();
        valueText.text = level.ToString();
    }
}
