using UnityEngine;

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

    void OnEnable()
    {
        AttackComponent.OnDamageText += GetObject;
    }
    void OnDisable()
    {
        AttackComponent.OnDamageText -= GetObject;
    }
    void GetObject(Vector3 _transform, float _damage)
    {
        _transform.y += posY;
        DamageText damageText = damageTextPool.GetObject();
        damageText.SetPool(damageTextPool);
        damageText.rectTransform.anchoredPosition = _transform;
        damageText.text.text = _damage.ToString("F1");
    }
}
