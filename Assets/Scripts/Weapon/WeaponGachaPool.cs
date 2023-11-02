using UnityEngine;
using UnityEngine.UI;

public class WeaponGachaPool : MonoBehaviour
{
    public UIWeapon uIWeapon;

    [SerializeField] Weapon weaponPrefab;

    public MenuButton weaponMenu;
    public ObjectPool<Weapon> weaponPool;

    void Awake()
    {
        weaponPool = new ObjectPool<Weapon>(weaponPrefab, 100, transform.GetChild(0));
    }
}
