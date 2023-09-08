using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : IEvent
{
    public void BeginEvent()
    {
        Debug.Log("Oxygen Began");
        GameManager.Instance.StartLosingOxygen();
        AudioManager.Instance.PlaySound("AirLost");
    }

    public void CompleteEvent()
    {
        Debug.Log("Oxygen Completed");
        AudioManager.Instance.StopSound("AirLost");
        AudioManager.Instance.PlaySound("AirEnd");
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
