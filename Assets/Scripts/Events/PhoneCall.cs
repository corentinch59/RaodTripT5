using UnityEngine;

public class PhoneCall : IEvent
{
    public void BeginEvent()
    {
        Debug.Log("Phone Call Began");
        UIManager.Instance.PhoneCallPopup.SetActive(true);
        AudioManager.Instance.PlayPhoneCall();
        
    }

    public void CompleteEvent()
    {
        Debug.Log("Phone Call Completed");
        UIManager.Instance.PhoneCallPopup.SetActive(false);
        AudioManager.Instance.StopPhoneCall();
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
