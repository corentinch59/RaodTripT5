using UnityEngine;

public class AlarmClock : IEvent
{
    public void BeginEvent()
    {
        Debug.Log("Alarm Clock Began");
        AudioManager.Instance.PlaySound("AlarmClock");
    }

    public void CompleteEvent()
    {
        Debug.Log("Alarm Clock Complete");
        AudioManager.Instance.StopSound("AlarmClock");
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
