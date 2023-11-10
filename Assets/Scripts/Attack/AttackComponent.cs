using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] LayerMask layer;

    bool isAttacking;

    Transform target;
    BaseCharacter character;
    BaseCharacter targetCharacter;


    public static event Action OnHealthBar;

    public delegate void DamageTextDelegate(Vector3 _pos, float _damage);
    public static event DamageTextDelegate OnDamageText;

    void Awake()
    {
        character = GetComponent<BaseCharacter>();
    }
    void OnEnable()
    {
        isAttacking = false;
    }
    void Update()
    {
        MoveTo();
    }
    void MoveTo()
    {
        // 타겟 검색
        if (!target)
        {
            Collider2D near = Physics2D.OverlapCircle(transform.position, 15f, layer);
            if (near)
            {
                target = near.transform;
                targetCharacter = target.GetComponent<BaseCharacter>();
            }
        }
        else
        {
            // 타겟 방향으로 이동
            float distanceTo = Vector2.Distance(transform.position, target.position);
            if (distanceTo >= character.AttackRange)
            {
                isAttacking = false;
                Vector2 direction = target.position - transform.position;
                transform.Translate(direction.normalized * character.MoveSpeed * Time.deltaTime);
            }
            else
            {
                if (!isAttacking && target)
                {
                    StartCoroutine(AttackCo());
                }
            }
        }
    }
    IEnumerator AttackCo()
    {
        isAttacking = true;
        float damage = character.Damage;
        if(UnityEngine.Random.value < character.CriticalRate)
        {
            damage += damage * character.CriticalDamage;
        }
        if(damage >= 0)
        {
            targetCharacter.CurrentHp -= damage;
            OnDamageText?.Invoke(target.position, damage);
        }
        TargetDie();
        OnHealthBar?.Invoke();

        yield return new WaitForSeconds(character.AttackSpeed);
        isAttacking = false;
    }
    void TargetDie()
    {
        if (targetCharacter.CurrentHp <= 0)
        {
            NullTarget();
            targetCharacter.gameObject.SetActive(false);
        }
    }
    public float GetFraction()
    {
        return character.CurrentHp / character.Hp;
    }
    public Transform NullTarget()
    {
        return target = null;
    }
}
   