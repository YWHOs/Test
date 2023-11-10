using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    int currentCount;
    public int CurrentCount { get { return currentCount; }  set { if(GameManager.Instance?.GameState == EGameState.Idle) currentCount = value; } }
    int bossGenCount = 3;

    EnemyPool enemyPool;
    [SerializeField] Slider stageSlider;
    void Awake()
    {
        enemyPool = GetComponent<EnemyPool>();
    }
    public void EnemyGenerate()
    {
        if (GameManager.Instance?.GameState != EGameState.Idle) return;

        if(currentCount < bossGenCount)
        {
            SpawnEnemy(enemyPool?.enemyPool);
        }
        else
        {
            SpawnEnemy(enemyPool?.bossEnemyPool);
        }
        StageSliderValue();
    }

    public void SpawnEnemy<T>(ObjectPool<T> _pool) where T : MonoBehaviour
    {
        _pool?.GetObject();
    }

    void StageSliderValue()
    {
        stageSlider.value = (float)currentCount / bossGenCount;
    }
}
