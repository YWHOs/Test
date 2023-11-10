
using System.Collections;
using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    WeaponData equippedWeapon;
    [SerializeField] QuestManager questManager;

    void Start()
    {
        UpgradeButton.OnUpgradeButton += Upgrade;
        UIWeapon.OnEquipWeapon += EquipWeapon;
    }
    void OnDestroy()
    {
        UpgradeButton.OnUpgradeButton -= Upgrade;
        UIWeapon.OnEquipWeapon -= EquipWeapon;
    }
    void OnEnable()
    {
        CurrentHp = Hp;
    }
    void OnDisable()
    {
        Invoke("ReGeneratePlayerCo", 1);
    }
    void ReGeneratePlayerCo()
    {
        gameObject.SetActive(true);
    }
    public void Upgrade(UpgradeButton _button, float _value)
    {
        switch (_button.stat)
        {
            case EStat.Damage:
                Damage += _value;
                break;
            case EStat.AttackSpeed:
                AttackSpeed -= _value * _value;
                break;
            case EStat.AttackRange:
                AttackRange += _value;
                break;
            case EStat.Hp:
                Hp += _value;
                break;
            case EStat.Defense:
                Defense += _value;
                break;
            case EStat.CriticalRate:
                CriticalRate += _value;
                break;
            case EStat.CriticalDamage:
                CriticalDamage += _value;
                break;
            default:
                break;
        }
        questManager.QuestCount(QuestType.UpgradeItem, _button.Multi);
    }
    public void EquipWeapon(WeaponData _weapon)
    {
        if(IsEquippedWeapon())
        {
            Damage -= equippedWeapon.attributes.damage;
        }
        equippedWeapon = _weapon;

        Damage += _weapon.attributes.damage;

    }
    
    public void UpgradeWeapon(WeaponData _weapon, float _damage)
    {
        if(IsEquippedWeapon() && equippedWeapon == _weapon)
        {
            Damage += _damage;
        }
    }
    public bool IsEquippedWeapon()
    {
        return equippedWeapon != null;
    }
}
