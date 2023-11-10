using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemData
{
    public string name;
    public string icon;
    public int level;
    public float probability;
    public int upgrade;
    public string itemRarity;
}

public class Item : MonoBehaviour
{
    public TextMeshProUGUI weaponNumText;
    public TextMeshProUGUI weaponLevelText;
    public Button button;
    public Slider slider;
    public Notify notify;
}