using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelGachaProbability
{
    public int level;
    public int[] gachaProbability; 
}
[CreateAssetMenu(fileName = "Gacha", menuName = "SetGachaLevel")]
public class GachaLevel : ScriptableObject
{
    public int[] gachaToLevelUp;
    public List<LevelGachaProbability> levelGachaProbabilities;
}
