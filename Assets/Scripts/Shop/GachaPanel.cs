using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GachaPanel : MonoBehaviour
{
    int gachaLevel;
    public int GachaLevel {  get { return gachaLevel; } }
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Slider slider;
    public void SetLevelText()
    {
        levelText.text = "Lv " + (gachaLevel + 1);
    }
    public void SetSliderMaxValue(int _maxValue)
    {
        slider.maxValue = _maxValue;
    }
    public void CountSliderValue()
    {
        slider.value++;
    }
    public int SliderValue()
    {
        return (int)slider.value;
    }
    public bool IsLevelUp()
    {
        return slider.value == slider.maxValue;
    }
    public void GachaLevelUp()
    {
        slider.value = 0;
        ++gachaLevel;
    }
}
