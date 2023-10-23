using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WeaponData
{
    public string name;
    public string icon;
    public int level;
}
[System.Serializable]
class WeaponList
{
    public WeaponData[] weapon;
}
public class GachaSystem : MonoBehaviour
{
    WeaponList weaponList;

    [SerializeField] Weapon weaponPrefab;
    [SerializeField] Transform panelTf;

    public ObjectPool<Weapon> weaponPool;

    void Awake()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("JSON/WeaponData");
        weaponList = JsonUtility.FromJson<WeaponList>(textAsset.text);

        weaponPool = new ObjectPool<Weapon>(weaponPrefab, 100, panelTf);
    }
    //
    IEnumerator GacahButtonCo(int _count)
    {
        while(_count != 0)
        {
            float random = Random.Range(0, 100);
            int i = 0;
            if (random <= 60)
            {
                i = 0;
            }
            else if (60 < random && random <= 90)
            {
                i = 1;
            }
            else
            {
                i = 2;
            }
            Weapon weaponObject = weaponPool?.GetObject();
            Image image = weaponObject.GetComponent<Image>();
            Sprite sprite = Resources.Load<Sprite>("Image/Upgrade/" + weaponList?.weapon[i].icon);
            image.sprite = sprite;
            _count--;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void GachaButtonClick(int _count)
    {
        panelTf?.gameObject.SetActive(true);
        StartCoroutine(GacahButtonCo(_count));
    }
}
