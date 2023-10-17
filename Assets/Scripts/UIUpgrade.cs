using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UpgradeData
{
    public string name;
    public string icon;
    public int level;
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

    void Awake()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("JSON/UpgradeData");
        upgradeList = JsonUtility.FromJson<UpgradeList>(textAsset.text);

        upgradeButtonPool = new ObjectPool<UpgradeButton>(upgradePanelPrefab, upgradeList.upgrade.Length, parent);
        SetUpgrade();
    }


    void SetUpgrade()
    {
        foreach (UpgradeData upgrade in upgradeList.upgrade)
        {
            UpgradeButton upgradeButton = upgradeButtonPool.GetObject();
            // 이름
            upgradeButton.nameText.text = upgrade.name;
            // 아이콘
            Sprite sprite = Resources.Load<Sprite>("Image/Upgrade/" + upgrade.icon);
            upgradeButton.iconImage.sprite = sprite;
            // 레벨
            upgradeButton.Level = upgrade.level;
        }
    }
}
