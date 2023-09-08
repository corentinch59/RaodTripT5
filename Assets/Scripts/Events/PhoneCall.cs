using UnityEngine;

public class PhoneCall : IEvent
{
    public void BeginEvent()
    {
        Debug.Log("Phone Call Began");
        UIManager.Instance.PhoneCallPopup.SetActive(true);
        UIManager.Instance.btnPhoneCall.SetColor("_EmissionColor", new Color(0.0f, 1.0f, 0f));
        UIManager.Instance.btnPhoneCall.SetColor("_BaseColor", new Color(0.0f, 1.0f, 0f));
        AudioManager.Instance.PlaySound("Ringtone");
        
    }

    public void CompleteEvent()
    {
        Debug.Log("Phone Call Completed");
        UIManager.Instance.PhoneCallPopup.SetActive(false);
        UIManager.Instance.btnPhoneCall.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1f));
        UIManager.Instance.btnPhoneCall.SetColor("_BaseColor", new Color(1.0f, 1.0f, 1f));
        AudioManager.Instance.StopSound("Ringtone");
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
