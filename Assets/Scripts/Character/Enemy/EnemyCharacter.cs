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

    SpawnCoin spawnCoin;
    void Awake()
    {
        enemyManager = GetComponentInParent<EnemyManager>();
        spawnCoin = FindObjectOfType<SpawnCoin>();
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
        SetCoinPosition();
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
    void SetCoinPosition()
    {
        if (spawnCoin && !gameObject.activeSelf)
        {
            spawnCoin.SetCoinPos(transform);
        }
    }
}
