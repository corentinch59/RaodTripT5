using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameEvent();

public class GameManager : MonoBehaviour
{
    private float _dynamoCharge;

    public float DynamoCharge
    {
        get { return _dynamoCharge; }
        set {
            _dynamoCharge = value;
            DynamoFill?.Invoke();
        }
    }

    public static GameEvent DynamoFill;

    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Debug.LogWarning("Duplicate GameManager with name : " +  name);
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }
}
