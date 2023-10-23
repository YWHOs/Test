using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] AttackComponent characterHealth;
    [SerializeField] RectTransform foreground;

    void Start()
    {
        AttackComponent.OnHealthBar += CharacterHealthBar;
    }
    void OnDestroy()
    {
        AttackComponent.OnHealthBar -= CharacterHealthBar;
    }
    void CharacterHealthBar()
    {
        if(foreground)
        {
            foreground.localScale = new Vector3(characterHealth.GetFraction(), 1f, 1f);
        }
    }
}
