using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] float hp;
    public float Hp { get { return hp; } set {  hp = value; } }
    [SerializeField] float currentHp;
    public float CurrentHp { get { return currentHp; } set { currentHp = value; } }
    [SerializeField] float defense;
    public float Defense { get {  return defense; } set {  defense = value; } }

    [SerializeField] float damage;
    public float Damage { get { return damage; } set { damage = value; } }
    [SerializeField] float attackRange;
    public float AttackRange {  get { return attackRange; } set { attackRange = value; } }
    [SerializeField] float attackSpeed;
    public float AttackSpeed { get { return attackSpeed; } set { attackSpeed = value; } }

    [SerializeField] float criticalRate;
    public float CriticalRate { get { return criticalRate; } set { criticalRate = value; } }
    [SerializeField] float criticalDamage;
    public float CriticalDamage { get { return criticalDamage; } set { criticalDamage = value; } }

    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
}
