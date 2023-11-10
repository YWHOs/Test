public class EnemyCharacter_Dungeon : EnemyCharacter
{
    DungeonManager dungeonManager;
    void Start()
    {
        dungeonManager = FindObjectOfType<DungeonManager>();
    }
    protected override void ReturnEnemy()
    {
        pool?.ReturnObject(this);
    }
    protected override void OnDisable()
    {
        dungeonManager?.DungeonClear();
        base.OnDisable();
    }
}
