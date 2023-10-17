using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SkillButton : MonoBehaviour
{
    Image skillImage;
    Button button;

    float skillCoolTime;
    public float SkillCoolTime { set { skillCoolTime = value; } }

    bool isLock;
    public bool IsLock { set { isLock = value; } }

    void Awake()
    {
        skillImage = GetComponent<Image>();
        button = GetComponent<Button>();
    }
    void Start()
    {
        if(isLock)
        {
            button.interactable = false;
            Sprite sprite = Resources.Load<Sprite>("Image/lock");
            skillImage.sprite = sprite;
        }
    }

    public void SkillButtonClick()
    {
        if(button.interactable)
        {
            StartCoroutine(SkillCoolTimeCo());
        }
    }

    IEnumerator SkillCoolTimeCo()
    {
        button.interactable = false;
        if (skillImage)
        {
            while (skillImage.fillAmount > 0)
            {
                skillImage.fillAmount -= 1 * Time.deltaTime / skillCoolTime;
                yield return null;
            }

            button.interactable = true;
            skillImage.fillAmount = 1;
        }
    }
}
