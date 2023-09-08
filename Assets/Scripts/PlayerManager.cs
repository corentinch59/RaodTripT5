using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    #region Properties
    public float NavigationSpeed => _navigationSpeed;
    #endregion

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _navigationSpeed;

    private Vector2 _previous;
    private Vector2 leftDirection;
    private Vector2 rightDirection;

    private void FixedUpdate()
    {
        EvaluateDirection(leftDirection, rightDirection);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();
       if(obstacle != null)
       {
            GameManager.Instance.DamageMecha(obstacle.Damage);
       }
        Destroy(other.gameObject);
    }

    public void Dynamo(InputAction.CallbackContext ctx)
    {
        Vector2 temp = ctx.ReadValue<Vector2>();

        float angle = Vector2.SignedAngle(temp, _previous);
        if (angle > 0)
        {
            GameManager.Instance.DynamoCharge = Mathf.Clamp(GameManager.Instance.DynamoCharge += GameManager.Instance.ChargingValue, 0, GameManager.Instance.MaxDynamoCharge);
        }
        _previous = temp;
    }

    public void RightJoystick(InputAction.CallbackContext ctx)
    {
        rightDirection = ctx.ReadValue<Vector2>();
    }

    public void LeftJoystick(InputAction.CallbackContext ctx)
    {
        leftDirection = ctx.ReadValue<Vector2>();
    }

    private void EvaluateDirection(Vector2 leftDirection, Vector2 rightDirection)
    {
        if (AreAnyDirectionsZero(leftDirection, rightDirection)) return;

        float dotProduct = Vector2.Dot(leftDirection, rightDirection);

        if (dotProduct < 0)
        {
            HandleOppositeDirections(leftDirection);
        }
        else if (dotProduct > 0)
        {
            HandleOrthogonalDirections(leftDirection);
        }
    }

    private bool AreAnyDirectionsZero(Vector2 left, Vector2 right)
    {
        _rb.velocity = Vector3.zero;
        return left == Vector2.zero || right == Vector2.zero;
    }

    private void HandleOppositeDirections(Vector2 leftDirection)
    {
        if (leftDirection.y > 0)
        {
            // Right
            _rb.velocity = new Vector3(_navigationSpeed * Time.fixedDeltaTime, 0.0f, 0.0f);
        }
        else
        {
            // Left
            _rb.velocity = new Vector3(-_navigationSpeed * Time.fixedDeltaTime, 0.0f, 0.0f);
        }
    }

    private void HandleOrthogonalDirections(Vector2 leftDirection)
    {
        if (leftDirection.y > 0)
        {
            // Up
            _rb.velocity = new Vector3(0.0f, -_navigationSpeed * Time.fixedDeltaTime, 0.0f);
        }
        else
        {
            // Down
            _rb.velocity = new Vector3(0.0f, _navigationSpeed * Time.fixedDeltaTime, 0.0f);
        }
    }

    public void OnOxygenButton1(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if((GameManager.Instance.OxygenRatio >= 0.25f && GameManager.Instance.OxygenRatio < 0.5f) || (GameManager.Instance.OxygenRatio >= 0.75f && GameManager.Instance.OxygenRatio < 1.0f))
            {
                GameManager.Instance.OxygenButton1Pressed = true;
                GameManager.Instance.StartFillOxygen();
            }
        }else if (ctx.canceled)
        {
            GameManager.Instance.OxygenButton1Pressed = false;
        }
    }

    public void OnOxygenButton2(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if ((GameManager.Instance.OxygenRatio >= 0.0f && GameManager.Instance.OxygenRatio < 0.25f) || (GameManager.Instance.OxygenRatio >= 0.50f && GameManager.Instance.OxygenRatio < 0.75f))
            {
                GameManager.Instance.OxygenButton2Pressed = true;
                GameManager.Instance.StartFillOxygen();
            }
        }
        else if (ctx.canceled)
        {
            GameManager.Instance.OxygenButton2Pressed = false;
        }
    }

    public void Wiper(InputAction.CallbackContext ctx)
    {
        Vector2 temp = ctx.ReadValue<Vector2>();

        if(temp.x == 1)
        {
            //active les essuie glasse
            GameManager.Instance.WiperActivated = true;
            UIManager.Instance.UpdateWiperUI();

            foreach (Cerveau cerveau in Cerveau.cerveaux)
            {
                if (ctx.performed && cerveau.EventCerv is DustCloud)
                {
                    cerveau.CompleteEvent();
                }
            }
            
        }else
        {
            //d�sactive les essuie glasse
            GameManager.Instance.WiperActivated = false;
            UIManager.Instance.UpdateWiperUI();
        }
    }

    public void DeclinePhone(InputAction.CallbackContext ctx)
    {
        foreach(Cerveau cerveau in Cerveau.cerveaux)
        {
            if (ctx.started && cerveau.EventCerv is PhoneCall)
            {
                cerveau.CompleteEvent();
            }
        }
        
    }

    public void LiberateTrash(InputAction.CallbackContext ctx)
    {
        foreach (Cerveau cerveau in Cerveau.cerveaux)
        {
            if (ctx.started && cerveau.EventCerv is TrashOverload)
            {
                cerveau.CompleteEvent();
            }
        }
    }

    public void TurnOffAlarmClock(InputAction.CallbackContext ctx)
    {
        foreach (Cerveau cerveau in Cerveau.cerveaux)
        {
            if (ctx.started && cerveau.EventCerv is AlarmClock)
            {
                cerveau.CompleteEvent();
            }
        }
    }
}
