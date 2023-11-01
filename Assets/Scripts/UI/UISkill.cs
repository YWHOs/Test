using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class SkillData
{
    public string name;
    public string icon;
    public float coolTime;
    public bool isLock;
}
[System.Serializable]
class SkillList
{
    public SkillData[] skills;
}
public class UISkill : MonoBehaviour
{
    [SerializeField] SkillButton skillButtonPrefab;
    [SerializeField] Transform parent;

    ObjectPool<SkillButton> skillButtonPool;

    SkillList skillList;

    void Awake()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("JSON/SkillData");
        skillList = JsonUtility.FromJson<SkillList>(textAsset.text);

        skillButtonPool = new ObjectPool<SkillButton>(skillButtonPrefab, skillList.skills.Length, parent);
        SetSkill();
    }


    void SetSkill()
    {
        foreach (SkillData skill in skillList.skills)
        {
            SkillButton skillObject = skillButtonPool.GetObject();
            // ¿Ã∏ß
            skillObject.GetComponentInChildren<TextMeshProUGUI>().text = skill.name;
            // æ∆¿Ãƒ‹
            Image image = skillObject.GetComponent<Image>();
            Sprite sprite = Resources.Load<Sprite>("Image/Skill/" + skill.icon);
            image.sprite = sprite;
            // ƒ≈∏¿”
            skillObject.SkillCoolTime = skill.coolTime;
            // ¿·±Ë
            skillObject.IsLock = skill.isLock;
        }
    }
}
