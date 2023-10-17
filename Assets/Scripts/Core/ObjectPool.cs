using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    Queue<T> objectQueue = new Queue<T>();
    T prefab;

    public ObjectPool(T _prefab, int _initSize, Transform _parent)
    {
        prefab = _prefab;
        for (int i = 0; i < _initSize; i++)
        {
            T newObj = Object.Instantiate(prefab);
            newObj.gameObject.SetActive(false);
            newObj.transform.SetParent(_parent);
            objectQueue.Enqueue(newObj);
        }
    }

    public T GetObject()
    {
        if (objectQueue.Count > 0)
        {
            T obj = objectQueue.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            T moreObj = Object.Instantiate(prefab);
            moreObj.gameObject.SetActive(true);
            return moreObj;
        }
    }

    public void ReturnObject(T _obj)
    {
        _obj.gameObject.SetActive(false);
        objectQueue.Enqueue(_obj);
    }
}
