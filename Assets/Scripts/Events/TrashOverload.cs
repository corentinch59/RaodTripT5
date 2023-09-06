using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashOverload : IEvent
{
    public void BeginEvent()
    {
        Debug.Log("Trash Overload Began");
        UIManager.Instance.TrashOverloadPopup.SetActive(true);
    }

    public void CompleteEvent()
    {
        Debug.Log("Trash Overload Completed");
        UIManager.Instance.TrashOverloadPopup.SetActive(false);
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
