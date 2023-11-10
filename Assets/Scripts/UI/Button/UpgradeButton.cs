using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class UpgradeButton : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI valueText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI goldText;
    public Image iconImage;
    public EStat stat;

    int upgradeLevel;
    public int UpgradeLevel { get { return upgradeLevel; } set { upgradeLevel = value; } }

    float upgradeValue;
    public float UpgradeValue { get { return upgradeValue; } set { upgradeValue = value; } }
    
    int goldToUpgrade = 1;
    public int GoldToUpgrade { get { return goldToUpgrade; } }

    int multiGoldToUpgrade;
    public int MultiGoldToUpgrade { get { return multiGoldToUpgrade; } set { multiGoldToUpgrade = value; } }
    int multi = 1;
    public int Multi { get { return multi; } set { multi = value; } }
    Treasure treasure;

    bool isClick;

    public delegate void UpgradeButtonDelegate(UpgradeButton _button, float _value);
    public static event UpgradeButtonDelegate OnUpgradeButton;

    void Awake()
    {
        treasure = FindObjectOfType<Treasure>();
    }
    void OnEnable()
    {
        // 골드 변경시 색상 변경
        treasure.OnGoldChange += LackOfGold;
    }
    void OnDisable()
    {
        treasure.OnGoldChange -= LackOfGold;
    }
    void Update()
    {
        if (isClick)
        {
            Invoke("UpgradeButtonClick", 0.5f);
        }
    }
    public void ButtonDown()
    {
        isClick = true;
    }
    public void ButtonUp()
    {
        isClick = false;
        CancelInvoke("UpgradeButtonClick");
    }
    public void UpgradeButtonClick()
    {
        if (treasure?.Gold < goldToUpgrade || treasure?.Gold < multiGoldToUpgrade) return;
        if (!levelText || !valueText) return;
        
        upgradeLevel += multi;
        levelText.text = "Lv " + upgradeLevel.ToString();

        int sum = 0;
        for (int i = 0; i < multi; i++)
        {
            upgradeValue += 0.1f;
            sum += goldToUpgrade++;
        }
        upgradeValue = Mathf.Round(upgradeValue * 10f) / 10f;
        treasure?.ChangeGold(-sum);
        valueText.text = upgradeValue.ToString();

        // Stat 업그레이드
        OnUpgradeButton?.Invoke(this, upgradeValue);
        // 다음 업그레이드에 필요한 골드
        sum = 0;
        for (int i = 0; i < multi; i++)
        {
            sum += goldToUpgrade + i;
        }
        multiGoldToUpgrade = sum;
        LackOfGold();
        goldText.text = sum.ToString();

    }
    public void LackOfGold()
    {
        if (multiGoldToUpgrade > treasure.Gold)
        {
            goldText.color = Color.red;
        }
        else
        {
            goldText.color = Color.yellow;
        }
    }
}
