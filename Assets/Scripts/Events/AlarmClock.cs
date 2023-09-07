using System.Collections;
using System.Collections.Generic;
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
        GameManager.Instance.BetweenEvents();
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
