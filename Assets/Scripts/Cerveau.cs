using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cerveau : MonoBehaviour
{
    #region Properties

    public IEvent EventCerv
    {
        get { return _eventCerv; }
        set { _eventCerv = value; }
    }
    public float Timer
    {
        get { return _timer; }
        set { _timer = value; }
    }
    #endregion

    private IEvent _eventCerv;
    private float _timer;
    
    public static List<Cerveau> cerveaux = new List<Cerveau>();

    public void Awake()
    {
        cerveaux.Add(this);
    }

    public void InitCerv(float timer)
    {
        _timer = timer;
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
        Debug.Log("Start Between" + this.name);
        yield return new WaitForSeconds(_timer);
        Debug.Log("End Between" + this.name);
        NewBrainCycle(this);
    }

    public void FirstCycle()
    {
        StartCoroutine(_FirstCycle(_timer, this));
    }

    public IEnumerator _FirstCycle(float _startTimer, Cerveau _cervax)
    {
        yield return new WaitForSeconds(_startTimer);
        NewBrainCycle(_cervax);
    }

    public static void NewBrainCycle(Cerveau cerveau)
    {
        if(GameManager.Instance.IsPlaying) 
        {
            IEvent tempEvent = EventManager.Instance.ChooseRandomEvent();
            foreach (Cerveau cerv in cerveaux)
            {
                if (cerv != cerveau)
                {
                    if (tempEvent == cerv.EventCerv)
                    {
                        NewBrainCycle(cerveau);
                    }
                    else
                    {
                        cerveau.EventCerv = tempEvent;
                        cerveau.EventCerv.BeginEvent();
                    }
                }
            }
        }
    }
}
