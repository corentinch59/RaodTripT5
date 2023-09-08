using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : IEvent
{
    public void BeginEvent()
    {
        Debug.Log("Oxygen Began");
        GameManager.Instance.StartLosingOxygen();
    }

    public void CompleteEvent()
    {
        Debug.Log("Oxygen Completed");
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
