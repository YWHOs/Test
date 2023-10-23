using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI valueText;
    public TextMeshProUGUI nameText;
    public Image iconImage;
    int level;
    public int Level { get { return level; } set { level = value; } }

    float value;
    public float Value { get { return value; } set { this.value = value; } }
    Treasure treasure;
    int goldToUpgrade = 1;

    void Start()
    {
        treasure = FindObjectOfType<Treasure>();
    }
    public void UpgradeButtonClick()
    {
        if(treasure?.Gold < goldToUpgrade) return;
        if (!levelText || !valueText) return;
        
        level++;
        levelText.text = "Lv " + level.ToString();
        valueText.text = level.ToString();
        
        treasure?.ChangeGold(-goldToUpgrade);
        goldToUpgrade++;
    }
}
