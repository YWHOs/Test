using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] RectTransform hole;
    [SerializeField] GameObject tutorialPanel;
    TextMeshProUGUI tutorialText;
    TutorialData[] tutorialData;
    bool isTutorial;

    int tutorialIndex;
    void Awake()
    {
        tutorialData = Resources.LoadAll<TutorialData>("Scriptable/Tutorial");
        tutorialText = tutorialPanel.GetComponentInChildren<TextMeshProUGUI>();
    }
    void Start()
    {
        TutorialStart();
        
    }
    void Update()
    {
        if (!isTutorial) return;

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            if(hole.rect.Contains(mousePos - (Vector2)hole.position))
            {
                TutorialEnd();
                if(tutorialData.Length - 1 >= tutorialIndex)
                {
                    TutorialStart();
                }
            }
        }
    }
    void TutorialSet(bool _bool)
    {
        isTutorial = _bool;
        tutorialPanel.gameObject.SetActive(_bool);
    }
    void TutorialEnd()
    {
        TutorialSet(false);
        tutorialIndex++;
    }
    void TutorialStart()
    {
        TutorialSet(true);

        TutorialData data = tutorialData[tutorialIndex];
        hole.anchoredPosition = data.holePos;
        hole.sizeDelta = data.holeSize;

        tutorialText.text = data.tutorialDescription;
    }
}
