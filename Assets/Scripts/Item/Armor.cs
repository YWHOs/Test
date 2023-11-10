using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public ArmorData[] weapon;
}
public class Armor : Item
{

}
