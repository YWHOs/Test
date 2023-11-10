using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeonPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI goldText;
    public Button button;
    public EDungeon dungeon;

    int dungeonLevel = 1;

    public int DungeonReward()
    {
        int dungeonReward = dungeonLevel * 100;
        return dungeonReward;
    }
    public void GoldText(int _reward)
    {
        goldText.text = _reward.ToString();
    }
    public void LevelText()
    {
        dungeonLevel++;
        levelText.text = "Lv " + dungeonLevel.ToString();
    }
}
