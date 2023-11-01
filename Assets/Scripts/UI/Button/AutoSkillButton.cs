using System.Collections;
using UnityEngine;

public class AutoSkillButton : MonoBehaviour
{
    SkillButton[] skillButton;

    bool isPressed;
    void Start()
    {
        skillButton = transform.parent.GetComponentsInChildren<SkillButton>();
    }

    public void AutoSkillButtonClick()
    {
        isPressed = !isPressed;

        StartCoroutine(AutoSkillCo());
    }
    IEnumerator AutoSkillCo()
    {
        while(isPressed)
        {
            yield return null;
            foreach (SkillButton button in skillButton)
            {
                button.SkillButtonClick();
            }
        }

    }
}
