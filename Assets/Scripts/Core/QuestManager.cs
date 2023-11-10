using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum QuestType
{
    KillEnemies,
    CollectItems,
    ExploreArea,
    UpgradeItem,

    MAX
}

class QuestData
{
    public QuestType questType;
    public int questNum;
    public string questTitle;
    public string questDescription;
    public int num;
    public int gold;

    public QuestData(QuestType _questType, int _questNum, string _questTitle, string _questDescription, int _num, int _gold)
    {
        questType = _questType;
        questNum = _questNum;
        questTitle = _questTitle;
        questDescription = _questDescription;
        num = _num;
        gold = _gold;
    }
}

public class QuestManager : MonoBehaviour
{
    Dictionary<int, QuestData> questDict = new Dictionary<int, QuestData>();
    QuestData currentQuestData;
    int currentQuestNum = 1;
    int questCount;

    [SerializeField] TextMeshProUGUI questNameText;
    [SerializeField] Treasure treasure;

    void Start()
    {
        AddQuest(QuestType.KillEnemies, 1, "Quest1", "Kill Enemy", 5, 100);
        AddQuest(QuestType.UpgradeItem, 2, "Quest2", "Upgrade Item", 20, 150);
        AddQuest(QuestType.KillEnemies, 3, "Quest3", "Kill Enemy", 15, 200);
        AddQuest(QuestType.KillEnemies, 4, "Quest4", "Kill Enemy", 20, 250);
        AddQuest(QuestType.KillEnemies, 5, "Quest5", "Kill Enemy", 25, 300);


        currentQuestData = GetQuest(currentQuestNum);
        QuestNameText();

    }
    void OnEnable()
    {
        EnemyCharacter.OnEnemyDie += KillEnemy;
    }
    void OnDisable()
    {
        EnemyCharacter.OnEnemyDie -= KillEnemy;
    }

    void AddQuest(QuestType _questType, int _questNum, string _questTitle, string _questDescription, int _num, int _gold)
    {
        QuestData data = new QuestData(_questType, _questNum, _questTitle, _questDescription, _num, _gold);
        questDict.Add(_questNum, data);
    }

    QuestData GetQuest(int _questNum)
    {
        if(questDict.TryGetValue(_questNum, out QuestData questData))
        {
            return questData;
        }
        return null;
    }
    
    string QuestNameText()
    {
        return questNameText.text = currentQuestData.questTitle + "\n" + currentQuestData.questDescription + "\n GOLD:" + currentQuestData.gold + "\n" + questCount + "/" + currentQuestData.num;
    }
    void FinishQuest()
    {
        if (questCount >= currentQuestData.num)
        {
            questNameText.text = "";
            treasure.ChangeGold(currentQuestData.gold);
            questCount = 0;
            currentQuestData = GetQuest(++currentQuestNum);
            if(currentQuestData != null)
            {
                QuestNameText();
            }
        }
    }
    public void QuestCount(QuestType _questType, int _count = 1)
    {
        if (currentQuestData == null || GetQuest(currentQuestNum).questType != _questType) return;

        questCount += _count;
        QuestNameText();
        FinishQuest();
    }
    void KillEnemy()
    {
        QuestCount(QuestType.KillEnemies);
    }
}
