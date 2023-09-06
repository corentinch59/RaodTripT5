using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private Vector2 _previous;

    public void Dynamo(InputAction.CallbackContext ctx)
    {
        Vector2 temp = ctx.ReadValue<Vector2>();

        float angle = Vector2.SignedAngle(temp, _previous);
        if(angle > 0)
        {
            GameManager.Instance.DynamoCharge = Mathf.Clamp(GameManager.Instance.DynamoCharge += GameManager.Instance.ChargingValue, 0, GameManager.Instance.MaxDynamoCharge);
        }
        _previous = temp;
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
        if(GameManager.Instance.Cerveau1 is PhoneCall)
        {
            GameManager.Instance.Cerveau1.CompleteEvent();
        }

    }

    public void LiberateTrash(InputAction.CallbackContext ctx)
    {
        if (GameManager.Instance.Cerveau1 is TrashOverload)
        {
            GameManager.Instance.Cerveau1.CompleteEvent();
        }
    }

    public void TurnOffAlarmClock()
    {
        if(GameManager.Instance.Cerveau1 is AlarmClock)
        {
            GameManager.Instance.Cerveau1.CompleteEvent();
        }
    }

}
