using System;
using UnityEngine;

public class EnemyCharacter : BaseCharacter
{
    [SerializeField] Vector2 generatePos;
    [SerializeField] int goldAmount;

    EnemyManager enemyManager;
    public static event Action<int> OnGetGold;
    public static event Action OnEnemyDie;

    void Start()
    {
        enemyManager = GetComponentInParent<EnemyManager>();
    }
    void OnEnable()
    {
        transform.position = generatePos;
    }
    void OnDisable()
    {
        OnGetGold?.Invoke(goldAmount);
        OnEnemyDie?.Invoke();
        enemyManager?.EnemyGenerate(this);
    }

}
