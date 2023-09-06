using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameEvent();

public class GameManager : MonoBehaviour
{
    private bool isPlaying = true;


    [SerializeField]private float _goalDistance;
    public float GoalDistance
    {
        get { return _goalDistance; }
        set
        {
            _goalDistance = value;
            if(_goalDistance <= 0)
            {
                isPlaying = false;
                GameFinished?.Invoke();
            }
        }
    }
    [SerializeField] private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    
    
    [SerializeField]private float _maxDynamoCharge;
    public float MaxDynamoCharge
    {
        get { return _maxDynamoCharge; }
        set { _maxDynamoCharge = value; }
    }

    private float _dynamoCharge = 0;
    public float DynamoCharge
    {
        get { return _dynamoCharge; }
        set {
            _dynamoCharge = value;
            DynamoFill?.Invoke();
        }
    }
    
    [SerializeField]private float _chargingValue;
    public float ChargingValue
    {
        get { return _chargingValue; }
        set { _chargingValue = value; }
    }

    [SerializeField] private float _dischargingValue;
    public float DischargingValue
    {
        get { return _dischargingValue; }
        set { _dischargingValue = value; }
    }



    public static GameEvent GameFinished;
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

    private void Start()
    {
        GameFinished += () => { Debug.Log("GameFinished"); };
        _dynamoCharge = _maxDynamoCharge;

        DynamoFill += UpdateGoalDistance;



    }

    private void Update()
    {

        if (isPlaying)
        {
            DynamoCharge = Mathf.Clamp(DynamoCharge -= DischargingValue, 0, float.MaxValue);
            Debug.Log(DynamoCharge);
        }

    }

    private void UpdateGoalDistance()
    {
        
        if(_dynamoCharge > 0)
        {
            GoalDistance = Mathf.Clamp(GoalDistance -= Speed, 0, float.MaxValue);
        }
        
    }

}
