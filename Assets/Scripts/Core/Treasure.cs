using System;
using TMPro;
using UnityEngine;
public class Treasure : MonoBehaviour
{
    int gold;
    public int Gold { get { return gold; } set {  gold = value; } }
    [SerializeField] TextMeshProUGUI goldText;

    public static event Action OnGoldChange;
    void Start()
    {
        gold = 10000;
        EnemyCharacter.OnGetGold += ChangeGold;
    }
    void OnDestroy()
    {
        EnemyCharacter.OnGetGold -= ChangeGold;
    }
    public void ChangeGold(int _value)
    {
        gold += _value;
        if (goldText)
        {
            goldText.text = gold.ToString();
        }
        OnGoldChange?.Invoke();
    }
}
