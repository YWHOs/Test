using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image coinImage;

    void Start()
    {
        EnemyCharacter.OnEnemyDie += CoinSpawn;
        gameObject.SetActive(false);
    }
    void OnEnable()
    {
        MoveCoin();
    }
    void OnDestroy()
    {
        EnemyCharacter.OnEnemyDie -= CoinSpawn;
    }
    void MoveCoin()
    {
        RectTransform rect = coinImage.rectTransform;
        transform.DOLocalMove(rect.anchoredPosition, 1f).OnComplete(() => gameObject.SetActive(false));
    }
    void CoinSpawn()
    {
        gameObject.SetActive(true);
    }
    public void SetCoinPos(Transform _tf)
    {
        transform.position = Camera.main.WorldToScreenPoint(_tf.position);
    }
}
