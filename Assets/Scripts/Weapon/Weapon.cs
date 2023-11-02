using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WeaponData : ItemData
{
    //public string name;
    //public string icon;
    //public int level;
    //public int upgrade;
    //public string itemRarity;
    //public float probability;
    public Attributes attributes;
}
[System.Serializable]
public class Attributes
{
    public float damage;
    public float attackSpeed;
    public float attackRange;
}
[System.Serializable]
public class WeaponList
{
    public WeaponData[] weapon;
}

public class Weapon : MonoBehaviour
{
    WeaponGachaPool weaponGacha;
    public TextMeshProUGUI weaponNumText;
    public TextMeshProUGUI weaponLevelText;
    public Button button;
    public Slider slider;
    public Notify notify;

    void Start()
    {
        weaponGacha = GetComponentInParent<WeaponGachaPool>();
    }
    void OnDisable()
    {
        weaponGacha?.weaponPool?.ReturnObject(this);
    }
}
