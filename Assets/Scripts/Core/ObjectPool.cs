using System;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    T[] objectArray;
    int currentIndex = 0;
    T prefab;

    public ObjectPool(T _prefab, int _initSize, Transform _parent)
    {
        prefab = _prefab;
        objectArray = new T[_initSize];
        for (int i = 0; i < _initSize; i++)
        {
            T newObj = UnityEngine.Object.Instantiate(prefab, _parent);
            newObj.gameObject.SetActive(false);
            objectArray[i] = newObj;
        }
    }

    public T GetObject()
    {
        for (int i = 0; i < objectArray.Length; i++)
        {
            int index = (currentIndex + i) % objectArray.Length;
            if (!objectArray[index].gameObject.activeSelf)
            {
                currentIndex = (index + 1) % objectArray.Length;
                objectArray[index].gameObject.SetActive(true);
                return objectArray[index];
            }
        }

        T moreObj = UnityEngine.Object.Instantiate(prefab);
        moreObj.gameObject.SetActive(true);
        Array.Resize(ref objectArray, objectArray.Length + 1);
        objectArray[objectArray.Length - 1] = moreObj;
        return moreObj;
    }

    public void ReturnObject(T _obj)
    {
        _obj.gameObject.SetActive(false);
    }
    public void ReturnAllObjectsToPool()
    {
        foreach (T obj in objectArray)
        {
            obj.gameObject.SetActive(false);
        }
    }

}
