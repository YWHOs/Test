using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoldAmount
{
    Attack,
    AttackSpeed,
    Health,

    MAX
}
[System.Serializable]
class ProgressionCharacterClass
{
    public GoldAmount goldAmount;
    public int[] levels;
}

[CreateAssetMenu(fileName = "Progression", menuName = "Stat/New Progression", order = 0)]
public class Progression : ScriptableObject
{
    [SerializeField] ProgressionCharacterClass[] characterClasses;

    Dictionary<GoldAmount, int[]> lookupTable;

    void BuildLookup()
    {
        if(lookupTable != null) return;

        lookupTable = new Dictionary<GoldAmount, int[]>();
        
        foreach(ProgressionCharacterClass progression in characterClasses)
        {
            lookupTable[progression.goldAmount] = progression.levels;
        }
    }
    public int GetGoldAmount(GoldAmount _gold, int _level)
    {
        BuildLookup();
        int[] levels = lookupTable[_gold];
        if (levels.Length < _level) return 0;
        return levels[_level - 1];
    }
}
