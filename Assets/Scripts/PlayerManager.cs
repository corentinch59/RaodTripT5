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
            _rb.velocity = new Vector3(-_navigationSpeed * Time.fixedDeltaTime, 0.0f, 0.0f);
        }
        else
        {
            // Left
            _rb.velocity = new Vector3(_navigationSpeed * Time.fixedDeltaTime, 0.0f, 0.0f);
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

    public void Wiper(InputAction.CallbackContext ctx)
    {
        Vector2 temp = ctx.ReadValue<Vector2>();

        if(temp.x == 1)
        {
            //active les essuie glasse
            GameManager.Instance.WiperActivated = true;
            UIManager.Instance.UpdateWiperUI();

            if (ctx.performed && GameManager.Instance.Cerveau1 is DustCloud)
            {
                GameManager.Instance.Cerveau1.CompleteEvent();
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
        if(ctx.started && GameManager.Instance.Cerveau1 is PhoneCall)
        {
            GameManager.Instance.Cerveau1.CompleteEvent();
        }
    }

    public void LiberateTrash(InputAction.CallbackContext ctx)
    {
        if (ctx.started && GameManager.Instance.Cerveau1 is TrashOverload)
        {
            GameManager.Instance.Cerveau1.CompleteEvent();
        }
    }

    public void TurnOffAlarmClock(InputAction.CallbackContext ctx)
    {
        if(ctx.started && GameManager.Instance.Cerveau1 is AlarmClock)
        {
            GameManager.Instance.Cerveau1.CompleteEvent();
        }
    }
}
