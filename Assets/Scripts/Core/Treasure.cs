using System;
using TMPro;
using UnityEngine;
public class Treasure : MonoBehaviour
{
    // long 900해 까지 알파벳 9F까지가 최대
    long gold;
    public long Gold { get { return gold; } set {  gold = value; } }
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
            goldText.text = ChangeToAlphabet();
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
    string ChangeToAlphabet()
    {
        if (gold < 1000)
        {
            return gold.ToString();
        }
        else
        {
            float amount = gold;
            char alpha = '\0';
            for (int i = 'A'; i <= 'G'; i++)
            {
                if (amount >= 1000)
                {
                    amount = amount * 0.001f;
                    alpha = (char)i;
                }
                else { break; }
            }
            return amount.ToString("F2") + alpha;
        }
    }
}
