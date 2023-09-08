using UnityEngine;

public class AlarmClock : IEvent
{
    public void BeginEvent()
    {
        Debug.Log("Alarm Clock Began");
        UIManager.Instance.btnAlarmClock.SetColor("_EmissionColor", new Color(0.0f, 1.0f, 0f));
        UIManager.Instance.btnAlarmClock.SetColor("_BaseColor", new Color(0.0f, 1.0f, 0f));
        AudioManager.Instance.PlaySound("AlarmClock");
    }

    public void CompleteEvent()
    {
        Debug.Log("Alarm Clock Complete");
        UIManager.Instance.btnAlarmClock.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1f));
        UIManager.Instance.btnAlarmClock.SetColor("_BaseColor", new Color(1.0f, 1.0f, 1f));
        AudioManager.Instance.StopSound("AlarmClock");
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
