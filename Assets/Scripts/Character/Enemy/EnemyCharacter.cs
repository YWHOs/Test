using System;
using UnityEngine;

public class EnemyCharacter : BaseCharacter
{
    [SerializeField] Vector2 generatePos;
    [SerializeField] int goldAmount;

    protected EnemyManager enemyManager;

    public static event Action<int> OnGetGold;
    public static event Action OnEnemyDie;

    protected ObjectPool<EnemyCharacter> pool;
    void Awake()
    {
        enemyManager = GetComponentInParent<EnemyManager>();
    }
    void OnEnable()
    {
        transform.position = generatePos;
    }

    protected virtual void ReturnEnemy()
    {
        pool?.ReturnObject(this);
        if(enemyManager)
        {
            enemyManager.CurrentCount++;
        }
    }
    protected virtual void OnDisable()
    {
        EnemyDisableEvent();
        CurrentHp = Hp;
    }
    void EnemyDisableEvent()
    {
        if(GameManager.Instance?.GameState == EGameState.Idle)
        {
            ReturnEnemy();

            OnGetGold?.Invoke(goldAmount);
            OnEnemyDie?.Invoke();
            enemyManager?.EnemyGenerate();
        }
    }
}
