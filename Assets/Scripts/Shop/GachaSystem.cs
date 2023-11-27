using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class GachaSystem : MonoBehaviour
{
    [SerializeField] Transform panelTf;
    [SerializeField] Button exitButton;

    GachaLevel gachaLevel;
    
    [SerializeField] WeaponGachaPool weaponGacha;
    [SerializeField] GachaPanel weaponPanel;

    [SerializeField] GameObject itemParticleParent;
    ItemParticle[] itemParticles;

    int allProbability;
    void Awake()
    {
        gachaLevel = Resources.Load<GachaLevel>("Scriptable/Gacha");

        itemParticles = itemParticleParent?.GetComponentsInChildren<ItemParticle>(true);
    }
    void Start()
    {
        if(gachaLevel && weaponPanel)
        {
            weaponPanel.SetSliderMaxValue(gachaLevel.gachaToLevelUp[weaponPanel.GachaLevel]);
        }
    }
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
        StartCoroutine(GacahButtonCoT(_count, weaponGacha.uIWeapon, weaponGacha.weaponPool, weaponPanel));
    }
    void SetSliderValue(GachaPanel _panel, IGacha _gacha)
    {
        if (gachaLevel && _panel)
        {
            _panel.CountSliderValue();

            if (_panel.IsLevelUp() && _panel.GachaLevel != gachaLevel.gachaToLevelUp.Length - 1)
            {
                _panel.GachaLevelUp();
                _panel.SetSliderMaxValue(gachaLevel.gachaToLevelUp[_panel.GachaLevel]);
                _panel.SetLevelText();
                LevelGachaProbability levelGacha = gachaLevel.levelGachaProbabilities[_panel.GachaLevel];
                for (int i = 0; i < levelGacha.gachaProbability.Length; i++)
                {
                    _gacha.SetProbability(i, levelGacha.gachaProbability[i]);
                }
                allProbability = _gacha.GetAllProbability();
            }
        }
    }
    // 무기, 펫, 유물 등등
    IEnumerator GacahButtonCoT<TPool>(int _count, IGacha _gacha, ObjectPool<TPool> _objectPool, GachaPanel _panel) where TPool : MonoBehaviour
    {
        exitButton.gameObject.SetActive(false);
        allProbability = _gacha.GetAllProbability();
        while (_count > 0)
        {
            int random = Random.Range(1, allProbability);
            int probability = 0;
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
                TPool obj = _objectPool?.GetObject();
                if(obj.TryGetComponent(out Image _img))
                {
                    Sprite sprite = Resources.Load<Sprite>("Image/Upgrade/" + _gacha.GetIcon(index));
                    _img.sprite = sprite;
                }
                if(_gacha.IsRarityItem(index))
                {
                    for (int i = 0; i < itemParticles.Length; i++)
                    {
                        if (!itemParticles[i].gameObject.activeSelf)
                        {
                            yield return new WaitForEndOfFrame();
                            itemParticles[i].gameObject.SetActive(true);
                            RectTransform rect = itemParticles[i].GetComponent<RectTransform>();
                            RectTransform rect2 = obj.GetComponent<RectTransform>();
                            rect.anchoredPosition = rect2.anchoredPosition;
                            break;
                        }
                    }
                }
                _count--;
                SetSliderValue(_panel, _gacha);
                yield return new WaitForSeconds(0.05f);
            }
        }
        if (_gacha.IsUpgradeValid())
        {
            _gacha.ShowMenuNotify();
        }
        exitButton.gameObject.SetActive(true);
        _gacha.UpdateUI();
    }

    public void ItemParticleDisableClick()
    {
        foreach(ItemParticle particle in itemParticles)
        {
            particle.gameObject.SetActive(false);
        }
    }
}
