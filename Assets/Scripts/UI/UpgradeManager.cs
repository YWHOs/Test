using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UpgradeData
{
    public string name;
    public string icon;
    public int level;
    public float value;
}
[System.Serializable]
class UpgradeList
{
    public UpgradeData[] upgrade;
}
public class UpgradeManager : MonoBehaviour
{
    [SerializeField] UpgradeButton upgradePanelPrefab;
    [SerializeField] Transform parent;

    ObjectPool<UpgradeButton> upgradeButtonPool;

    UpgradeList upgradeList;
    UpgradeButton[] upgradeButton;

    Dictionary<string, float> dict = new Dictionary<string, float>();
    void Awake()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("JSON/UpgradeData");
        upgradeList = JsonUtility.FromJson<UpgradeList>(textAsset.text);

        upgradeButtonPool = new ObjectPool<UpgradeButton>(upgradePanelPrefab, upgradeList.upgrade.Length, parent);
        SetUpgrade();
    }


    void SetUpgrade()
    {
        upgradeButton = new UpgradeButton[upgradeList.upgrade.Length];
        for (int i = 0; i < upgradeList.upgrade.Length; i++)
        {
            upgradeButton[i] = upgradeButtonPool.GetObject();
            // �̸�
            upgradeButton[i].nameText.text = upgradeList.upgrade[i].name;
            dict.Add(upgradeList.upgrade[i].name, 0f);
            // ������
            Sprite sprite = Resources.Load<Sprite>("Image/Upgrade/" + upgradeList.upgrade[i].icon);
            upgradeButton[i].iconImage.sprite = sprite;
            // ����
            upgradeButton[i].UpgradeLevel = upgradeList.upgrade[i].level;
            upgradeButton[i].levelText.text = "Lv " + upgradeList.upgrade[i].level.ToString();

            upgradeButton[i].UpgradeValue = upgradeList.upgrade[i].value;
            // ����
            Stat stats = (Stat)i;
            if (upgradeButton[i].nameText.text == stats.ToString())
            {
                upgradeButton[i].stat = stats;
            }
        }
    }

    public void SaveUpgrade()
    {
        for (int i = 0; i < upgradeList.upgrade.Length; i++)
        {
            upgradeList.upgrade[i].level = upgradeButton[i].UpgradeLevel;
        }
        string saveData = JsonUtility.ToJson(upgradeList);
        System.IO.File.WriteAllText("Assets/Resources/JSON/UpgradeData.json", saveData);
    }

    public void UpgradeMultiplierClick(int _multi)
    {
        for (int i = 0; i < upgradeButton.Length; i++)
        {
            upgradeButton[i].Multi = _multi;

            int gold = 0;
            upgradeButton[i].MultiGoldToUpgrade = upgradeButton[i].GoldToUpgrade;
            for (int j = 0; j < _multi; j++)
            {
                gold += upgradeButton[i].MultiGoldToUpgrade++;
            }
            
            upgradeButton[i].MultiGoldToUpgrade = gold;
            upgradeButton[i].LackOfGold();
            upgradeButton[i].goldText.text = gold.ToString();
        }
    }
}
