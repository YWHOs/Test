using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIWeapon : MonoBehaviour, IGacha
{
    // Weapon Manager
    [SerializeField] Weapon weaponPrefab;
    [SerializeField] Transform parent;
    [SerializeField] MenuButton weaponMenu;

    ObjectPool<Weapon> weaponPool;
    [HideInInspector]
    public WeaponList weaponList;

    public Dictionary<string ,int> dictWeapon = new Dictionary<string ,int>();


    Weapon[] weaponObject;
    [SerializeField] PlayerCharacter playerCharacter;

    public delegate void EquipWeaponDelegate(WeaponData _weapon);
    public static event EquipWeaponDelegate OnEquipWeapon;
    void Awake()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("JSON/WeaponData");
        weaponList = JsonUtility.FromJson<WeaponList>(textAsset.text);
        weaponPool = new ObjectPool<Weapon>(weaponPrefab, weaponList.weapon.Length, parent);
        SetWeapon();
    }
    void Start()
    {
        for (int i = 0; i < weaponList.weapon.Length; i++)
        {
            int index = i;
            weaponObject[i]?.button?.onClick.AddListener(() => EquipWeaponClick(index));
        }
    }
    void SetWeapon()
    {
        weaponObject = new Weapon[weaponList.weapon.Length];
        for (int i = 0; i < weaponList.weapon.Length; i++)
        {
            weaponObject[i] = weaponPool?.GetObject();
            Image image = weaponObject[i].GetComponent<Image>();
            Sprite sprite = Resources.Load<Sprite>("Image/Upgrade/" + weaponList.weapon[i].icon);
            image.sprite = sprite;

            // 가챠 Weapon도 같이 묶여 있어서 여기서 Get
            weaponObject[i].weaponNumText = weaponObject[i].GetComponentInChildren<TextMeshProUGUI>();
            weaponObject[i].button = weaponObject[i].GetComponent<Button>();
            weaponObject[i].button.interactable = false;
            weaponObject[i].slider = weaponObject[i].GetComponentInChildren<Slider>();
            dictWeapon.Add(weaponList.weapon[i].name, 0);
        }
    }

    public void InteractableButton(int _index)
    {
        if (WeaponCount(_index) <= 0 || weaponObject[_index].button.interactable == true) return;
        weaponObject[_index].button.interactable = true;
    }
    public void UpdateUI()
    {
        for (int i = 0; i < weaponList.weapon.Length; i++)
        {
            weaponObject[i].weaponNumText.text = WeaponCount(i).ToString() + " / " + weaponList.weapon[i].upgrade;
            weaponObject[i].slider.value = (float)WeaponCount(i) / weaponList.weapon[i].upgrade;
            if (WeaponCount(i) >= weaponList.weapon[i].upgrade)
            {
                weaponObject[i].notify.ShowNotify();
            }
            else
            {
                weaponObject[i].notify.HideNotify();
            }
        }
    }
    public void EquipWeaponClick(int _index)
    {
        OnEquipWeapon?.Invoke(weaponList.weapon[_index]);
    }
    public bool IsUpgradeValid()
    {
        for (int i = 0; i < weaponList.weapon.Length; i++)
        {
            if (WeaponCount(i) >= weaponList.weapon[i].upgrade)
            {
                return true;
            }
        }
        return false;
    }
    int WeaponCount(int _index)
    {
        return dictWeapon[weaponList.weapon[_index].name];
    }
    public void UpgradeWeaponAllClick()
    {
        for (int i = 0; i < weaponList.weapon.Length; i++)
        {
            if (WeaponCount(i) >= weaponList.weapon[i].upgrade)
            {
                dictWeapon[weaponList.weapon[i].name] -= weaponList.weapon[i].upgrade;
                // 캐릭터 무기 장착하고 있을 때, 그 전 레벨의 무기 데미지 절감
                playerCharacter.UpgradeWeapon(weaponList.weapon[i], -weaponList.weapon[i].attributes.damage);
                weaponList.weapon[i].level++;
                weaponList.weapon[i].attributes.damage *= weaponList.weapon[i].level;
                // 캐릭터 무기 장착하고 있을 때, 그 후 레벨의 무기 데미지 +
                playerCharacter.UpgradeWeapon(weaponList.weapon[i], weaponList.weapon[i].attributes.damage);

                weaponObject[i].weaponLevelText.text = "Lv." + weaponList.weapon[i].level.ToString();
            }
        }
        UpdateUI();
    }
    
    public bool IsRarityItem(int _index)
    {
        return weaponList.weapon[_index].itemRarity == "Legendary";
    }
    public int GetProbability(int _index)
    {
        return weaponList.weapon[_index].probability;
    }
    public int GetAllProbability()
    {
        int probability = 0;
        for(int i = 0;i < weaponList.weapon.Length; i++)
        {
            probability += weaponList.weapon[i].probability;
        }
        return probability;
    }
    public void SetProbability(int _index, int _probability)
    {
        weaponList.weapon[_index].probability = _probability;
    }
    public string GetIcon(int _index)
    {
        return weaponList.weapon[_index].icon;
    }
    public int ItemDictCountUp(int _index)
    {
        string name = weaponList.weapon[_index].name;
        return dictWeapon[name]++;
    }
    public int GetListLength()
    {
        return weaponList.weapon.Length;
    }
    public void ShowMenuNotify()
    {
        weaponMenu.notify.ShowNotify();
    }
}
