using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] Image menuObject;
    Vector2 curPos;
    bool isPress;
    void Start()
    {
        if (menuObject)
        {
            curPos = menuObject.transform.position;
        }

    }
    public void MenuButtonClick()
    {
        if (!menuObject) return;

        isPress = !isPress;
        if(isPress)
        {
            menuObject.gameObject.SetActive(true);
        }
        else
        {
            menuObject.gameObject.SetActive(false);
            menuObject.transform.position = curPos;
        }
    }
    void Update()
    {
        if(isPress && menuObject)
        {
            SmoothMove();
        }
    }
    void SmoothMove()
    {
        menuObject.rectTransform.anchoredPosition = Vector2.Lerp(menuObject.rectTransform.anchoredPosition, Vector2.zero, Time.deltaTime * 10);
    }
}
