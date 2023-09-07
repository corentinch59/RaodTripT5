using System.Collections;
using UnityEngine;

public delegate void GameEvent();

public class GameManager : MonoBehaviour
{
    #region Properties
    public float GoalDistance
    {
        get { return _goalDistance; }
        set
        {
            _goalDistance = value;
            if (_goalDistance <= 0 && isPlaying)
            {
                isPlaying = false;
                GameFinished?.Invoke();
            }
        }
    }
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public float MaxDynamoCharge
    {
        get { return _maxDynamoCharge; }
        set { _maxDynamoCharge = value; }
    }
    public float DynamoCharge
    {
        get { return _dynamoCharge; }
        set
        {
            _dynamoCharge = value;
            DynamoFill?.Invoke();
        }
    }
    public float ChargingValue
    {
        get { return _chargingValue; }
        set { _chargingValue = value; }
    }
    public float DischargingValue
    {
        get { return _dischargingValue; }
        set { _dischargingValue = value; }
    }
    public bool WiperActivated
    {
        get { return _wiperActivated; }
        set { _wiperActivated = value; }
    }
    public Cerveau Cerveau1 => _cerveau1;
    public Cerveau Cerveau2 => _cerveau2;
    #endregion

    private bool isPlaying = true;
    private float _dynamoCharge = 0;

    [SerializeField] private float _goalDistance;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDynamoCharge;
    [SerializeField] private float _chargingValue;
    [SerializeField] private float _dischargingValue;

    private float _oxygenCharge;
    public float OxygenCharge
    {
        get => _oxygenCharge; 
        set
        {
            _oxygenCharge = value;
            _oxygenRatio = _oxygenCharge / _maxOxygenCharge;
            OxygenFill?.Invoke();
        }
    }
    [SerializeField] private float _maxOxygenCharge;
    public float MaxOxygenCharge => _maxOxygenCharge;
    private float _oxygenRatio;
    public float OxygenRatio => _oxygenRatio;
    [SerializeField]private float _oxygenFillingAmount;
    [SerializeField]private float _oxygenFillingSpeed;
    private bool _isFillingOxygen = false;
    [SerializeField]private float _oxygeneCoyoteTime = 0.5f;
    [SerializeField] private float _oxygenLoosingAmount;
    [SerializeField] private float _oxygenLoosingSpeed;
    [SerializeField] private float _oxygenEventDuration;
    private bool _oxygenButton1Pressed = false;
    public bool OxygenButton1Pressed
    {
        get => _oxygenButton1Pressed;
        set => _oxygenButton1Pressed = value;
    }
    private bool _oxygenButton2Pressed = false;
    public bool OxygenButton2Pressed
    {
        get => _oxygenButton2Pressed;
        set => _oxygenButton2Pressed = value;
    }
    private bool _oxygenEventOn = false;
    
    private bool _wiperActivated = false;

    private Cerveau _cerveau1;
    private Cerveau _cerveau2;
    public Cerveau[] cerveaux = new Cerveau[2];

    [SerializeField] private float _timeBetweenEvents;
    [SerializeField] private float _timeBetweenEvents2;
    
    public static GameEvent GameFinished;
    public static GameEvent DynamoFill;
    public static GameEvent OxygenFill;

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
        _cerveau1 = gameObject.AddComponent<Cerveau>();
        _cerveau1.Timer = _timeBetweenEvents;
        _cerveau2 = gameObject.AddComponent<Cerveau>();
        _cerveau2.Timer = _timeBetweenEvents2;

        cerveaux[0] = _cerveau1;
        cerveaux[1] = _cerveau2;
        
        GameFinished += () => { Debug.Log("GameFinished"); };

        DynamoFill += UpdateGoalDistance;
        _dynamoCharge = _maxDynamoCharge;

        OxygenCharge = _maxOxygenCharge;

        NewBrainCycle(Cerveau1);
        //NewBrainCycle(Cerveau2);
    }

    private void Update()
    {
        if (isPlaying)
        {
            DynamoCharge = Mathf.Clamp(DynamoCharge -= DischargingValue, 0, float.MaxValue);
            //Debug.Log(DynamoCharge);
        }
    }

    private void UpdateGoalDistance()
    {
        if(_dynamoCharge > 0)
        {
            GoalDistance = Mathf.Clamp(GoalDistance -= Speed, 0, float.MaxValue);
        }
    }

    public void NewBrainCycle(Cerveau cerveau)
    {
        IEvent tempEvent = EventManager.Instance.ChooseRandomEvent();
        foreach(Cerveau cerv in cerveaux)
        {
            if(cerv != cerveau)
            {
                if(tempEvent == cerv.EventCerv)
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

    public void StartFillOxygen()
    {
        if (!_isFillingOxygen)
        {
            _isFillingOxygen = true;
            StartCoroutine(FillOxygen());
        }

    }
    private IEnumerator FillOxygen()
    {
        while (_isFillingOxygen)
        {
            if(_oxygenButton1Pressed && ((_oxygenRatio>= 0.25f && _oxygenRatio <=0.5f) || (_oxygenRatio >= 0.75f && _oxygenRatio <= 1.0f))){
                OxygenCharge += _oxygenFillingAmount;
                yield return new WaitForSeconds(_oxygenFillingSpeed);
            }
            else if(_oxygenButton2Pressed && ((_oxygenRatio >= 0.0f && _oxygenRatio <= 0.25f) || (_oxygenRatio >= 0.50f && _oxygenRatio <= 0.75f)))
            {
                OxygenCharge += _oxygenFillingAmount;
                yield return new WaitForSeconds(_oxygenFillingSpeed);
            }
            else
            {
                yield return new WaitForSeconds(_oxygeneCoyoteTime);
                _isFillingOxygen = false;
            }
        }
        
    }

    public void StartLosingOxygen()
    {
        _oxygenEventOn = true;
        StartCoroutine(LosingOxygen());
    }

    private IEnumerator LosingOxygen()
    {
        while(_oxygenCharge > 0 && _oxygenEventOn)
        {
            if (!_isFillingOxygen)
            {
                OxygenCharge -= _oxygenLoosingAmount;
                yield return new WaitForSeconds(_oxygenLoosingSpeed);
            }
            else
            {
                yield return null;
            }

        }
    }
}