using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Properties
    public GameObject Dusts => _dusts;
    public GameObject PhoneCallPopup => _phoneCallPopup;
    public GameObject TrashOverloadPopup => _trashOverloadPopup;
    #endregion

    [SerializeField] private TextMeshProUGUI _goalDistanceText;

    [SerializeField] private Material dynamoMat;
    [SerializeField] private Material healthMat;
    [SerializeField] private Material oxygenMat;

    [SerializeField] private Image _wiperImage;
    [SerializeField] private GameObject _dusts;

    [SerializeField] private GameObject _phoneCallPopup;
    [SerializeField] private GameObject _trashOverloadPopup;

    [SerializeField] private Material btnTrashMat;
    [SerializeField] public Material BtnTrashMat { 
        get => btnTrashMat; 
        set => btnTrashMat = value; 
    }

    public Material btnOxygenRedMat;
    public Material btnPhoneCall;
    public Material btnAlarmClock;
    
    private static UIManager _instance;
    public static UIManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("Duplicate UIManager with name : " + name);
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        GameManager.DynamoFill += UpdateDynamoFillUI;
        GameManager.DynamoFill += UpdateGoalDistanceUI;
        GameManager.OxygenFill += UpdateOxygenFillUI;
        GameManager.HealthFill += UpdateHealthFillUI;

        btnTrashMat.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1.0f));
        btnTrashMat.SetColor("_BaseColor", new Color(1.0f, 1.0f, 1.0f));

        btnAlarmClock.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1f));
        btnAlarmClock.SetColor("_BaseColor", new Color(1.0f, 1.0f, 1f));

        btnPhoneCall.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1f));
        btnPhoneCall.SetColor("_BaseColor", new Color(1.0f, 1.0f, 1f));

        btnOxygenRedMat.DisableKeyword("_EmissionMap");
    }

    public void UpdateDynamoFillUI()
    {
        dynamoMat.SetFloat("_Battery", GameManager.Instance.DynamoCharge / GameManager.Instance.MaxDynamoCharge);
    }

    public void UpdateGoalDistanceUI()
    {
        _goalDistanceText.text = GameManager.Instance.GoalDistance.ToString() + " m";
    }

    public void UpdateOxygenFillUI()
    {
        oxygenMat.SetFloat("_Oxygen", GameManager.Instance.OxygenRatio);
    }

    public void UpdateHealthFillUI()
    {
        healthMat.SetFloat("_Health", GameManager.Instance.Health / GameManager.Instance.MaxHealth);
    }

    public void UpdateWiperUI()
    {
        
        if (GameManager.Instance.WiperActivated)
        {
            _wiperImage.color = Color.green;
        }
        else
        {
            _wiperImage.color = Color.red;
        }
    }
}
