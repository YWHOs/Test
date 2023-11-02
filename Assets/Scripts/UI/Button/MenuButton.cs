using UnityEngine;
using UnityEngine.UI;

public enum MenuType
{
    UpgradeMenu,
    WeaponMenu,
    ShopMenu
}

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuType menuType;
    [SerializeField] Image menuObject;
    Vector2 curPos;
    bool isPress;
    Button button;
    Color normalColor;
    Color selectColor;

    public Notify notify;
    void Awake()
    {
        notify = GetComponentInChildren<Notify>(true);
        button = GetComponent<Button>();
    }
    void Start()
    {
        if (menuObject)
        {
            curPos = menuObject.transform.position;
        }
        normalColor = button.colors.normalColor;
        selectColor = button.colors.selectedColor;
    }
    void Update()
    {
        if (isPress && menuObject)
        {
            SmoothMove();
        }
    }
    public void MenuButtonClick()
    {
        if (!menuObject) return;

        isPress = !isPress;

        ColorBlock color = button.colors;
        if (isPress)
        {
            menuObject.gameObject.SetActive(true);
            color.selectedColor = selectColor;
            color.normalColor = selectColor;
        }
        else
        {
            menuObject.gameObject.SetActive(false);
            menuObject.transform.position = curPos;
            color.normalColor = normalColor;
            color.selectedColor = normalColor;
        }
        button.colors = color;
        notify?.HideNotify();
    }

    void SmoothMove()
    {
        RectTransform rectTransform = menuObject?.rectTransform;
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, Vector2.zero, Time.deltaTime * 10);
    }
}
