using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TEST
public class UIItem<TList> : MonoBehaviour, IGacha
{
    [SerializeField] Transform parent;
    [SerializeField] Item prefabItem;
    ObjectPool<Item> pool;
    Item[] itemObjects;
    protected TList itemList;

    protected int itemLength;
    protected ItemData[] itemDatas;
    Dictionary<string, int> dictItem = new Dictionary<string, int>();
    protected void GetJSONData(string _path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(_path);
        itemList = JsonUtility.FromJson<TList>(textAsset.text);
    }
    protected void GetPool(int _length)
    {
        pool = new ObjectPool<Item>(prefabItem, _length, parent);
    }
    protected void SetItem()
    {
        itemObjects = new Item[itemLength];
        for (int i = 0; i < itemLength; i++)
        {
            itemObjects[i] = pool?.GetObject();
            Image image = itemObjects[i].GetComponent<Image>();
            Sprite sprite = Resources.Load<Sprite>("Image/Upgrade/" + itemDatas[i].icon);
            image.sprite = sprite;

            // 처음 시작만 Add하기
            dictItem.Add(itemDatas[i].name, 0);
        }
    }
    public void InteractableButton(int _index)
    {
        if (ItemCount(_index) <= 0 || itemObjects[_index].button.interactable == true) return;
        itemObjects[_index].button.interactable = true;
    }
    int ItemCount(int _index)
    {
        return dictItem[itemDatas[_index].name];
    }
    public bool IsUpgradeValid()
    {
        for (int i = 0; i < itemLength; i++)
        {
            if (ItemCount(i) >= itemDatas[i].upgrade)
            {
                return true;
            }
        }
        return false;
    }

    public void UpdateUI()
    {
        for (int i = 0; i < itemLength; i++)
        {
            itemObjects[i].weaponNumText.text = ItemCount(i).ToString() + " / " + itemDatas[i].upgrade;
            itemObjects[i].slider.value = (float)ItemCount(i) / itemDatas[i].upgrade;
            if (ItemCount(i) >= itemDatas[i].upgrade)
            {
                itemObjects[i].notify.ShowNotify();
            }
            else
            {
                itemObjects[i].notify.HideNotify();
            }
        }
    }

    public bool IsRarityItem(int _index)
    {
        return itemDatas[_index].itemRarity == "Legendary";
    }

    public int GetProbability(int _index)
    {
        return itemDatas[_index].probability;
    }

    public int GetAllProbability()
    {
        int probability = 0;
        for (int i = 0; i < itemLength; i++)
        {
            probability += itemDatas[i].probability;
        }
        return probability;
    }

    public void SetProbability(int _index, int _probability)
    {
        throw new System.NotImplementedException();
    }

    public string GetIcon(int _index)
    {
        throw new System.NotImplementedException();
    }

    public int ItemDictCountUp(int _index)
    {
        throw new System.NotImplementedException();
    }

    public int GetListLength()
    {
        throw new System.NotImplementedException();
    }

    public void ShowMenuNotify()
    {
        throw new System.NotImplementedException();
    }
}
