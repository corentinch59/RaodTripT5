using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _goalDistanceText;
    [SerializeField] private Material dynamoMat;

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
    }

    public void UpdateDynamoFillUI()
    {
        dynamoMat.SetFloat("_Battery", GameManager.Instance.DynamoCharge / GameManager.Instance.MaxDynamoCharge);
    }

    public void UpdateGoalDistanceUI()
    {
        _goalDistanceText.text = GameManager.Instance.GoalDistance.ToString() + " m";
    }
}
