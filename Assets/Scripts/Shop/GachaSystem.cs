using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class GachaSystem : MonoBehaviour
{
    [SerializeField] Transform panelTf;
    [SerializeField] Button exitButton;


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
        StartCoroutine(GacahButtonCoT(_count, weaponGacha.uIWeapon, weaponGacha.weaponPool));
    }

    // 무기, 펫, 유물 등등
    IEnumerator GacahButtonCoT<TPool>(int _count, Gacha _gacha, ObjectPool<TPool> _objectPool) where TPool : MonoBehaviour
    {
        exitButton.gameObject.SetActive(false);
        while (_count > 0)
        {
            float random = Random.Range(0f, 100f);
            float probability = 0;
            int index = -1;
            for (int i = 0; i < _gacha.GetListLength(); i++)
            {
                probability += _gacha.GetProbability(i);
                if (random <= probability)
                {
                    index = i;
                    _gacha.ItemDictCountUp(i);
                    _gacha.InteractableButton(index);
                    break;
                }
            }
            if (index != -1)
            {
                var obj = _objectPool?.GetObject();
                Image image = obj.GetComponent<Image>();
                Sprite sprite = Resources.Load<Sprite>("Image/Upgrade/" + _gacha.GetIcon(index));
                image.sprite = sprite;
                _count--;
                yield return new WaitForSeconds(0.1f);
            }
        }
        if (_gacha.IsUpgradeValid())
        {
            _gacha.ShowMenuNotify();
        }
        exitButton.gameObject.SetActive(true);
        _gacha.UpdateUI();
    }

}
