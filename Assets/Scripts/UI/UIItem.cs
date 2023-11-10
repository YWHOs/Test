using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TEST
public class UIItem<TItem, TList> : MonoBehaviour where TItem : MonoBehaviour
{
    [SerializeField] TItem prefab;
    ObjectPool<TItem> pool;
    TList list;
    protected void GetJSONData(string _path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(_path);
        list = JsonUtility.FromJson<TList>(textAsset.text);
        pool = new ObjectPool<TItem>(prefab, 10, transform);
    }
}
