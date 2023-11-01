using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    [SerializeField] GameObject go;

    void Awake()
    {
        Instantiate(go);
    }

}
