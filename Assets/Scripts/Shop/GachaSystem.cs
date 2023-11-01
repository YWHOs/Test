using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class ItemData
{
    public string name;
    public string icon;
    public float probability;
}

public class GachaSystem : MonoBehaviour
{
    //WeaponList weaponList;
    //UIWeapon uIWeapon;

    //[SerializeField] Weapon weaponPrefab;
    [SerializeField] Transform panelTf;
    [SerializeField] Button exitButton;

    //[SerializeField] MenuButton weaponMenu;
    //public ObjectPool<Weapon> weaponPool;

    //Test
    ItemData item;
    WeaponData weaponData;
    //
    [SerializeField] WeaponGachaPool weaponGacha;

    //void Awake()
    //{
    //    uIWeapon = FindObjectOfType<UIWeapon>();
    //    exitButton = panelTf.GetComponentInChildren<Button>();
    //    TextAsset textAsset = Resources.Load<TextAsset>("JSON/WeaponData");
    //    weaponList = JsonUtility.FromJson<WeaponList>(textAsset.text);

    //    weaponPool = new ObjectPool<Weapon>(weaponPrefab, 100, panelTf);
    //}

    //IEnumerator GacahButtonCo(int _count)
    //{
    //    exitButton.gameObject.SetActive(false);
    //    while (_count > 0)
    //    {
    //        float random = Random.Range(0f, 100f);
    //        float probability = 0;
    //        int index = -1;
    //        for (int i = 0; i < weaponList.weapon.Length; i++)
    //        {
    //            probability += weaponList.weapon[i].probability;
    //            if (random <= probability)
    //            {
    //                index = i;
    //                uIWeapon.dictWeapon[weaponList.weapon[i].name]++;
    //                uIWeapon.InteractableButton(index);
    //                break;
    //            }
    //        }
    //        if (index != -1)
    //        {
    //            Weapon weaponObject = weaponPool?.GetObject();
    //            Image image = weaponObject.GetComponent<Image>();
    //            Sprite sprite = Resources.Load<Sprite>("Image/Upgrade/" + weaponList?.weapon[index].icon);
    //            image.sprite = sprite;
    //            _count--;
    //            yield return new WaitForSeconds(0.1f);
    //        }
    //    }
    //    if(uIWeapon.IsUpgradeValid())
    //    {
    //        weaponMenu?.notify?.ShowNotify();
    //    }
    //    exitButton.gameObject.SetActive(true);
    //    uIWeapon.UpdateWeaponUI();
    //}
    public void GachaButtonClick(int _count)
    {
        panelTf?.gameObject.SetActive(true);
        //StartCoroutine(GacahButtonCo(_count));

        StartCoroutine(GacahButtonCoT(weaponGacha.weaponList.weapon, weaponGacha.weaponList, _count, weaponGacha.weaponPool));
    }

    // 무기, 펫, 유물 등등?
    IEnumerator GacahButtonCoT<TList, TPool>(TList[] list, WeaponList _item, int _count, ObjectPool<TPool> _objectPool) where TPool : MonoBehaviour
    {
        exitButton.gameObject.SetActive(false);
        while (_count > 0)
        {
            float random = Random.Range(0f, 100f);
            float probability = 0;
            int index = -1;
            for (int i = 0; i < list.Length; i++)
            {
                probability += weaponGacha.weaponList.weapon[i].probability;
                if (random <= probability)
                {
                    index = i;
                    // Dictionary와 Button 통일하게 만들 최상위 클래스 UI 만들기
                    weaponGacha.uIWeapon.dictWeapon[weaponGacha.weaponList.weapon[i].name]++;
                    weaponGacha.uIWeapon.InteractableButton(index);
                    break;
                }
            }
            if (index != -1)
            {
                var obj = _objectPool?.GetObject();
                Image image = obj.GetComponent<Image>();
                Sprite sprite = Resources.Load<Sprite>("Image/Upgrade/" + weaponGacha.weaponList?.weapon[index].icon);
                image.sprite = sprite;
                _count--;
                yield return new WaitForSeconds(0.1f);
            }
        }
        if (weaponGacha.uIWeapon.IsUpgradeValid())
        {
            weaponGacha.weaponMenu?.notify?.ShowNotify();
        }
        exitButton.gameObject.SetActive(true);
        weaponGacha.uIWeapon.UpdateWeaponUI();
    }

}
