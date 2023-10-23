using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitButtonClick()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
