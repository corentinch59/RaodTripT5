using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
                GameOver?.Invoke();
            }
        }
    }
    public float Speed => _speed;
    public float MaxDynamoCharge => _maxDynamoCharge;
    public float DynamoCharge
    {
        get { return _dynamoCharge; }
        set
        {
            _dynamoCharge = value;
            if(_dynamoCharge > 0)
            {
                _speed = _maxSpeed;
            }
            else
            {
                _speed = _maxSpeed * 0.5f;
            }
            DynamoFill?.Invoke();
        }
    }
    public float ChargingValue => _chargingValue;
    public float DischargingValue => _dischargingValue;
    public float OxygenCharge
    {
        get => _oxygenCharge;
        set
        {
            _oxygenCharge = value;
            _oxygenRatio = _oxygenCharge / _maxOxygenCharge;
            OxygenFill?.Invoke();
            if( _oxygenCharge <= 0 ) 
            {
                GameOver?.Invoke();
            }
        }
    }
    public float OxygenRatio => _oxygenRatio;
    public bool OxygenButton1Pressed
    {
        get => _oxygenButton1Pressed;
        set => _oxygenButton1Pressed = value;
    }
    public bool OxygenButton2Pressed
    {
        get => _oxygenButton2Pressed;
        set => _oxygenButton2Pressed = value;
    }
    public bool WiperActivated
    {
        get { return _wiperActivated; }
        set { _wiperActivated = value; }
    }

    public float Health
    {
        get => _health;
        set
        {
            _health = value;
            HealthFill?.Invoke();
        }
    }

    public float MaxHealth => _maxHealth;
    #endregion

    private bool isPlaying = true;
    public bool IsPlaying => isPlaying;
    private float _dynamoCharge = 0;

    [SerializeField] private float _goalDistance;
    [SerializeField] private float _maxSpeed;
    private float _speed;
    [SerializeField] private float _maxDynamoCharge;
    [SerializeField] private float _chargingValue;
    [SerializeField] private float _dischargingValue;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

    private float _oxygenCharge;
    [SerializeField] private float _maxOxygenCharge;
    private float _oxygenRatio;
    [SerializeField] private float _oxygenFillingAmount;
    [SerializeField] private float _oxygenFillingSpeed;
    private bool _isFillingOxygen = false;
    [SerializeField] private float _oxygeneCoyoteTime = 0.5f;
    [SerializeField] private float _oxygenLoosingAmount;
    [SerializeField] private float _oxygenLoosingSpeed;
    [SerializeField] private float _oxygenEventDuration;
    private bool _oxygenButton1Pressed = false;
    private bool _oxygenButton2Pressed = false;
    private bool _oxygenEventOn = false;

    private bool _wiperActivated = false;
    public PlayerInput playerInput;

    private Cerveau _cerveau1;
    private Cerveau _cerveau2;

    public GameObject gameoverScreen;

    [SerializeField] private float _timeBetweenEvents;
    [SerializeField] private float _timeBetweenEvents2;

    public static GameEvent GameFinished;
    public static GameEvent DynamoFill;
    public static GameEvent OxygenFill;
    public static GameEvent HealthFill;
    public static GameEvent GameOver;

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
        playerInput.actions.FindActionMap("PlayerControls").Enable();
        playerInput.actions.FindActionMap("GO").Disable();
    }

    private void Start()
    {
        _cerveau1 = gameObject.AddComponent<Cerveau>();
        _cerveau1.InitCerv(_timeBetweenEvents);
        _cerveau2 = gameObject.AddComponent<Cerveau>();
        _cerveau2.InitCerv(_timeBetweenEvents2);

        GameFinished += () => { Debug.Log("GameFinished"); };

        DynamoFill += UpdateGoalDistance;
        _dynamoCharge = _maxDynamoCharge;

        OxygenCharge = _maxOxygenCharge;

        GameOver += GameOverScreen;
        HealthFill?.Invoke();
        OxygenFill?.Invoke();

        Cerveau.NewBrainCycle(_cerveau1);
        Cerveau.NewBrainCycle(_cerveau2);
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

    public void StartFillOxygen()
    {
        if (!_isFillingOxygen)
        {
            AudioManager.Instance.PlaySound("AirFill");
            _isFillingOxygen = true;
            AudioManager.Instance.StopSound("AirLost");
            StartCoroutine(FillOxygen());
        }
    }

    private IEnumerator FillOxygen()
    {
        while (_isFillingOxygen)
        {
            if(_oxygenButton1Pressed && ((_oxygenRatio>= 0.25f && _oxygenRatio <0.5f) || (_oxygenRatio >= 0.75f && _oxygenRatio < 1.0f))){
                OxygenCharge += _oxygenFillingAmount;
                yield return new WaitForSeconds(_oxygenFillingSpeed);
            }
            else if(_oxygenButton2Pressed && ((_oxygenRatio >= 0.0f && _oxygenRatio < 0.25f) || (_oxygenRatio >= 0.50f && _oxygenRatio < 0.75f)))
            {
                OxygenCharge += _oxygenFillingAmount;
                yield return new WaitForSeconds(_oxygenFillingSpeed);
            }
            else
            {
                yield return new WaitForSeconds(_oxygeneCoyoteTime);
                if(!_oxygenButton1Pressed && !_oxygenButton2Pressed)
                {
                    _isFillingOxygen = false;
                }

            }
        }
        AudioManager.Instance.StopSound("AirFill");
        if (_oxygenEventOn)
        {
            AudioManager.Instance.PlaySound("AirLost");
        }
    }

    public void StartLosingOxygen()
    {
        _oxygenEventOn = true;
        StartCoroutine(OxygenTimer());
        StartCoroutine(LosingOxygen());
    }
    private IEnumerator OxygenTimer()
    {
        yield return new WaitForSeconds(_oxygenEventDuration);
        _oxygenEventOn = false;
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
        foreach (Cerveau cerveau in Cerveau.cerveaux)
        {
            if (cerveau.EventCerv is Oxygen)
            {
                cerveau.CompleteEvent();
            }
        }
    }

    public void DamageMecha(float damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, 1);
        HealthFill?.Invoke();
        if( _health <= 0)
        {
            GameOver?.Invoke();
        }
    }

    public void GameOverScreen()
    {
        playerInput.actions.FindActionMap("PlayerControls").Disable();
        playerInput.actions.FindActionMap("GO").Enable();
        gameoverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
