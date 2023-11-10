public class EnemyCharacter_Boss : EnemyCharacter
{
    protected override void ReturnEnemy()
    {
        pool?.ReturnObject(this);
    }
    protected override void OnDisable()
    {
        if(enemyManager)
        {
            enemyManager.CurrentCount = 0;
        }
        base.OnDisable();
    }
}
