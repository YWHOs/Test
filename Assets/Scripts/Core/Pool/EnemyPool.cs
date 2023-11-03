using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] EnemyCharacter enemyCharacterPrefab;
    [SerializeField] EnemyCharacter bossEnemyCharacterPrefab;
    public ObjectPool<EnemyCharacter> enemyPool;
    public ObjectPool<EnemyCharacter> bossEnemyPool;
    void Awake()
    {
        int initEnemyPool = 3;
        enemyPool = new ObjectPool<EnemyCharacter>(enemyCharacterPrefab, initEnemyPool, transform);
        bossEnemyPool = new ObjectPool<EnemyCharacter>(bossEnemyCharacterPrefab, 1, transform);
        enemyPool?.GetObject();
    }
}
