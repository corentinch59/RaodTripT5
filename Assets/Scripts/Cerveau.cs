using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerveau : MonoBehaviour
{
    
    
    private IEvent _eventCerv;
    public IEvent EventCerv
    {
        get { return _eventCerv; }
        set { _eventCerv = value; }
    }

    private float _timer;
    public float Timer
    {
        get { return _timer; }
        set { _timer = value; }
    }


    public void NewEvent()
    {
        _eventCerv = EventManager.Instance.ChooseRandomEvent();
        _eventCerv.BeginEvent();
    }

    public void CompleteEvent()
    {
        _eventCerv.CompleteEvent();
        StartCoroutine(BetweenEvents());
    }

    public IEnumerator BetweenEvents()
    {
        Debug.Log("Start Between Event Brain 1");
        yield return new WaitForSeconds(_timer);
        Debug.Log("End Between Event Brain 1");
        GameManager.Instance.NewBrainCycle(this);
    }
}
