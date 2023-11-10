using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum EDungeon
{
    Gold,
    Diamond,

    MAX
}
public class DungeonManager : MonoBehaviour
{
    // 골드 던전, 다이아몬드 던전 등등
    // 무슨 던전인지?
    // 던전 적,
    // 맵 이동,
    // 진행되고 있는 프로세스 저장
    // 골드 보상, 던전 단계
    // 페이드 아웃
    [SerializeField] EnemyPool enemyPool;
    [SerializeField] Treasure treasure;
    [SerializeField] PlayerCharacter playerCharacter;
    [SerializeField] Image fadeImage;
    [SerializeField] DungeonPanel[] dungeonPanel;
    int panelIndex;
    bool isFade;

    private void Start()
    {
        for (int i = 0; i < dungeonPanel.Length; i++)
        {
            int index = i;
            dungeonPanel[i]?.button?.onClick.AddListener(() => EnterButtonClick(index));
        }
    }
    IEnumerator DungeonStartCo()
    {
        GameManager.Instance?.ChangeGameState(EGameState.Dungeon);
        playerCharacter.GetComponent<AttackComponent>().NullTarget();
        FadeOut();
        enemyPool.ReturnAllEnemy();

        yield return new WaitUntil(() => !isFade);

        enemyPool.dungeonEnemyPool.GetObject();
    }
    public void DungeonClear()
    {
        GameManager.Instance?.ChangeGameState(EGameState.Idle);
        FadeOut();

        switch(dungeonPanel[panelIndex].dungeon)
        {
            case EDungeon.Gold:
                treasure.ChangeGold(dungeonPanel[panelIndex].DungeonReward());
                break;
            case EDungeon.Diamond:
                treasure.ChangeDiamond(dungeonPanel[panelIndex].DungeonReward());
                break;
        }
        dungeonPanel[panelIndex].LevelText();
        dungeonPanel[panelIndex].GoldText(dungeonPanel[panelIndex].DungeonReward());
    }
    public void DungeonFail()
    {

    }
    public void EnterButtonClick(int _index)
    {
        if (GameManager.Instance?.GameState != EGameState.Idle) return;
        panelIndex = _index;
        StartCoroutine(DungeonStartCo());
    }
    void FadeOut()
    {
        isFade = true;
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(0f, 2f).OnComplete(() => { fadeImage.gameObject.SetActive(false); isFade = false; });
    }
}
