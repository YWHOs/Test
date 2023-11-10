using System;
using TMPro;
using UnityEngine;
public class Treasure : MonoBehaviour
{
    int gold;
    public int Gold { get { return gold; } set {  gold = value; } }
    int diamond;
    public int Diamond { get {  return diamond; } set {  diamond = value; } }
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI diamondText;

    public event Action OnGoldChange;
    void OnEnable()
    {
        EnemyCharacter.OnGetGold += ChangeGold;
    }
    void OnDisable()
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
    public void ChangeDiamond(int _value)
    {
        diamond += _value;
        if (diamondText)
        {
            diamondText.text = diamond.ToString();
        }
    }
}
