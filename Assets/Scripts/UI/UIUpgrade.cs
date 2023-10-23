using UnityEngine;

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
public class UIUpgrade : MonoBehaviour
{
    [SerializeField] UpgradeButton upgradePanelPrefab;
    [SerializeField] Transform parent;

    ObjectPool<UpgradeButton> upgradeButtonPool;

    UpgradeList upgradeList;
    UpgradeButton[] upgradeButton;

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
            // 이름
            upgradeButton[i].nameText.text = upgradeList.upgrade[i].name;
            // 아이콘
            Sprite sprite = Resources.Load<Sprite>("Image/Upgrade/" + upgradeList.upgrade[i].icon);
            upgradeButton[i].iconImage.sprite = sprite;
            // 레벨
            upgradeButton[i].Level = upgradeList.upgrade[i].level;
            upgradeButton[i].levelText.text = "Lv " + upgradeList.upgrade[i].level.ToString();
        }
    }

    public void SaveUpgrade()
    {
        for (int i = 0; i < upgradeList.upgrade.Length; i++)
        {
            upgradeList.upgrade[i].level = upgradeButton[i].Level;
        }
        string saveData = JsonUtility.ToJson(upgradeList);
        System.IO.File.WriteAllText("Assets/Resources/JSON/UpgradeData.json", saveData);
    }
}
