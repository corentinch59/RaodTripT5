using UnityEngine;

public class PhoneCall : IEvent
{
    public void BeginEvent()
    {
        Debug.Log("Phone Call Began");
        UIManager.Instance.PhoneCallPopup.SetActive(true);
    }

    public void CompleteEvent()
    {
        Debug.Log("Phone Call Completed");
        UIManager.Instance.PhoneCallPopup.SetActive(false);
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
