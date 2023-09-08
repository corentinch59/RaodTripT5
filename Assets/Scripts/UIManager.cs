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

    [SerializeField] private Image _wiperImage;
    [SerializeField] private GameObject _dusts;

    [SerializeField] private GameObject _phoneCallPopup;
    [SerializeField] private GameObject _trashOverloadPopup;

    [SerializeField] private Slider _oxygenSlider;
    
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
        _oxygenSlider.value = GameManager.Instance.OxygenRatio;
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
