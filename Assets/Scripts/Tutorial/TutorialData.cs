using UnityEngine;

[CreateAssetMenu(fileName = "Tutorial", menuName = "Tutorial/New Tutorial")]
public class TutorialData : ScriptableObject
{
    public Vector2 holePos;
    public Vector2 holeSize;
    [TextArea(1,3)]
    public string tutorialDescription;
}
