using UnityEngine;

public class Weapon : MonoBehaviour
{
    GachaSystem gacha;

    void Start()
    {
        gacha = GetComponentInParent<GachaSystem>();
    }
    void OnDisable()
    {
        gacha?.weaponPool?.ReturnObject(this);
    }
}
