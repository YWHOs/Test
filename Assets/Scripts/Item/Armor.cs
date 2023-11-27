
[System.Serializable]
public class ArmorData : ItemData
{
    public ArmorAttributes attributes;
}
[System.Serializable]
public class ArmorAttributes
{
    public float defense;
}
[System.Serializable]
public class ArmorList
{
    public ArmorData[] armor;
}
public class Armor : Item
{
    
}
