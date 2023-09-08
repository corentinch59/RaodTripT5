using UnityEngine;

public class AlarmClock : IEvent
{
    public void BeginEvent()
    {
        Debug.Log("Alarm Clock Began");
    }

    public void CompleteEvent()
    {
        Debug.Log("Alarm Clock Complete");
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
