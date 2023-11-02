using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] int initEnemyPool;
    [SerializeField] EnemyCharacter enemyCharacterPrefab;
    [SerializeField] EnemyCharacter bossEnemyCharacterPrefab;
    public ObjectPool<EnemyCharacter> enemyPool;
    public ObjectPool<EnemyCharacter> bossEnemyPool;
    void Awake()
    {
        enemyPool = new ObjectPool<EnemyCharacter>(enemyCharacterPrefab, initEnemyPool, transform);
        bossEnemyPool = new ObjectPool<EnemyCharacter>(bossEnemyCharacterPrefab, 1, transform);
        enemyPool?.GetObject();
    }
}
