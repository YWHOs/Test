using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] EnemyCharacter enemyCharacterPrefab;
    [SerializeField] EnemyCharacter_Boss bossEnemyCharacterPrefab;
    [SerializeField] EnemyCharacter_Dungeon dungeonEnemyCharacterPrefab;
    public ObjectPool<EnemyCharacter> enemyPool;
    public ObjectPool<EnemyCharacter_Boss> bossEnemyPool;
    public ObjectPool<EnemyCharacter_Dungeon> dungeonEnemyPool;
    void Awake()
    {
        int initEnemyPool = 3;
        enemyPool = new ObjectPool<EnemyCharacter>(enemyCharacterPrefab, initEnemyPool, transform);
        bossEnemyPool = new ObjectPool<EnemyCharacter_Boss>(bossEnemyCharacterPrefab, 1, transform);
        dungeonEnemyPool = new ObjectPool<EnemyCharacter_Dungeon>(dungeonEnemyCharacterPrefab, 1, transform);
        enemyPool?.GetObject();
    }

    public void ReturnAllEnemy()
    {
        enemyPool.ReturnAllObjectsToPool();
        bossEnemyPool.ReturnAllObjectsToPool();
    }
}
