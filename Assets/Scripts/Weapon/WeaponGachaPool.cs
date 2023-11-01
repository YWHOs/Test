using UnityEngine;
using UnityEngine.UI;

public class WeaponGachaPool : MonoBehaviour
{
    [HideInInspector]
    public WeaponList weaponList;
    [HideInInspector]
    public UIWeapon uIWeapon;

    [SerializeField] Weapon weaponPrefab;

    public MenuButton weaponMenu;
    public ObjectPool<Weapon> weaponPool;

    void Awake()
    {
        uIWeapon = FindObjectOfType<UIWeapon>();
        TextAsset textAsset = Resources.Load<TextAsset>("JSON/WeaponData");
        weaponList = JsonUtility.FromJson<WeaponList>(textAsset.text);

        weaponPool = new ObjectPool<Weapon>(weaponPrefab, 100, transform.GetChild(0));
    }
}
