using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    int bossGenCount = 3;

    EnemyPool enemyPool;
    EnemyCharacter bossCharacter;
    void Awake()
    {
        enemyPool = GetComponent<EnemyPool>();
    }
    public void EnemyGenerate(EnemyCharacter _character)
    {
        if (bossCharacter)
        {
            KillEnemy(enemyPool?.bossEnemyPool, bossCharacter);
            bossGenCount = 3;
        }
        if (bossGenCount > 0)
        {
            SpawnEnemy(enemyPool.enemyPool);
            bossGenCount--;
        }
        else
        {
            bossCharacter = SpawnEnemy(enemyPool.bossEnemyPool);
        }
        KillEnemy(enemyPool?.enemyPool, _character);
    }

    EnemyCharacter SpawnEnemy(ObjectPool<EnemyCharacter> _pool)
    {
        return _pool?.GetObject();
    }
    void KillEnemy(ObjectPool<EnemyCharacter> _pool, EnemyCharacter _character)
    {
        _pool.ReturnObject(_character);
    }
}
