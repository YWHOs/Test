using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    ObjectPool<DamageText> damageTextSpawn;
    public RectTransform rectTransform;
    public TextMeshProUGUI text;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        StartCoroutine(ReturnObjectCo());
    }
    public void SetPool(ObjectPool<DamageText> _pool)
    {
        damageTextSpawn = _pool;
    }
    IEnumerator ReturnObjectCo()
    {
        yield return new WaitForSeconds(0.3f);
        damageTextSpawn?.ReturnObject(this);
    }
}
