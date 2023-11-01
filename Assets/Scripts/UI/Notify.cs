using UnityEngine;

public class Notify : MonoBehaviour
{
    //NotifyManager notifyManager;

    //void Awake()
    //{
    //    notifyManager = FindObjectOfType<NotifyManager>();
    //}
    //void Start()
    //{
    //    UIWeapon.OnNotifyReturn += HideNotify;
    //}
    //public void HideNotify()                          
    //{
    //    notifyManager.notifyPool.ReturnObject(this);
    //}

    public void ShowNotify()
    {
        gameObject.SetActive(true);
    }
    public void HideNotify()
    {
        gameObject.SetActive(false);
    }
}
