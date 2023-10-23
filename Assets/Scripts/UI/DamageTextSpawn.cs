using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextSpawn : MonoBehaviour
{
    [SerializeField] DamageText damageTextPrefab;
    [SerializeField] int initDamageTextPoolSize;
    public ObjectPool<DamageText> damageTextPool;

    float posY = 1f;

    void Awake()
    {
        damageTextPool = new ObjectPool<DamageText>(damageTextPrefab, initDamageTextPoolSize, transform);
    }

    void Start()
    {
        AttackComponent.OnDamageText += GetObject;
    }
    void GetObject(Vector3 _transform, float _damage)
    {
        Vector3 pos = _transform;
        pos.y += posY;
        DamageText damageText = damageTextPool.GetObject();
        damageText.rectTransform.anchoredPosition = pos;
        damageText.text.text = _damage.ToString();
    }
}
