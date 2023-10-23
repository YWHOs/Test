using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] int initEnemyPool;
    [SerializeField] EnemyCharacter enemyCharacterPrefab;
    public ObjectPool<EnemyCharacter> enemyPool;
    void Awake()
    {
        enemyPool = new ObjectPool<EnemyCharacter>(enemyCharacterPrefab, initEnemyPool, transform);
        enemyPool?.GetObject();
    }
}
