using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEvent
{

    public abstract void BeginEvent();

    public abstract void CompleteEvent();

    public abstract void FailedEvent();

}
