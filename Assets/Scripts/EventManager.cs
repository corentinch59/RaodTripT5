using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private IEvent[] events = { new DustCloud(), new PhoneCall(), new TrashOverload(), new AlarmClock() };

    private static EventManager _instance;
    public static EventManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("Duplicate EventManager with name : " + name);
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    public IEvent ChooseRandomEvent()
    {
        int temp = Random.Range(0, events.Length);
        //int temp = 2;

        IEvent chosenEvent = events[temp];

        return chosenEvent;
    }




}
