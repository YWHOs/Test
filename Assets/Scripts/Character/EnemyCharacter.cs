using UnityEngine;

public class EnemyCharacter : BaseCharacter
{
    [SerializeField] Vector2 generatePos;
    [SerializeField] int goldAmount;

    EnemyPool enemyPool;

    public delegate void GetGoldDelegate(int _goldAmount);
    public static event GetGoldDelegate OnGetGold;
    void Start()
    {
        enemyPool = GetComponentInParent<EnemyPool>();
    }
    void OnEnable()
    {
        transform.position = generatePos;
    }
    void OnDisable()
    {
        OnGetGold?.Invoke(goldAmount);
        enemyPool?.enemyPool.GetObject();
        enemyPool?.enemyPool.ReturnObject(this);
    }
}
