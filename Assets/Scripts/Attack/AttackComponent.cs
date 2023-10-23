using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] LayerMask layer;

    float distanceTo;
    bool isAttacking;

    Transform target;
    BaseCharacter character;
    BaseCharacter targetCharacter;

    public delegate void HealthBarDelegate();
    public static event HealthBarDelegate OnHealthBar;

    public delegate void DamageTextDelegate(Vector3 _pos, float _damage);
    public static event DamageTextDelegate OnDamageText;

    void Awake()
    {
        character = GetComponent<BaseCharacter>();
    }
    void Start()
    {
        if(character)
        {
            character.CurrentHp = character.Hp;
        }
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
            distanceTo = Vector2.Distance(transform.position, target.transform.position);
            if (distanceTo >= character.AttackRange)
            {
                isAttacking = false;
                Vector2 direction = target.position - transform.position;
                transform.Translate(direction.normalized * character.MoveSpeed * Time.deltaTime);
            }
            else
            {
                if (!isAttacking)
                {
                    StartCoroutine(AttackCo());
                }
            }
        }
    }
    IEnumerator AttackCo()
    {
        if(!isAttacking)
        {
            isAttacking = true;
            targetCharacter.CurrentHp -= character.Damage;
            OnDamageText?.Invoke(target.position, character.Damage);
            OnHealthBar?.Invoke();
            if (targetCharacter.CurrentHp <= 0)
            {
                target = null;
                targetCharacter.CurrentHp = targetCharacter.Hp;
                targetCharacter.gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(character.AttackSpeed);
            isAttacking = false;
        }

    }

    public float GetFraction()
    {
        return character.CurrentHp / character.Hp;
    }
}
   