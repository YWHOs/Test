using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArmor : UIItem<ArmorList>
{

    void Awake()
    {
        GetJSONData("JSON/ArmorData");
        itemLength = itemList.armor.Length;
        itemDatas = itemList.armor;
        GetPool(itemLength);
        SetItem();
    }


}
