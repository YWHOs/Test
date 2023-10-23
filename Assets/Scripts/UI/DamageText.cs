using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] DamageTextSpawn damageTextSpawn;
    public RectTransform rectTransform;
    public TextMeshProUGUI text;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        damageTextSpawn = GetComponentInParent<DamageTextSpawn>();
    }
    void OnEnable()
    {
        StartCoroutine(ReturnObjectCo());
    }

    IEnumerator ReturnObjectCo()
    {
        yield return new WaitForSeconds(0.3f);
        damageTextSpawn?.damageTextPool?.ReturnObject(this);
    }
}
