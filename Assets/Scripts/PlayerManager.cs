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

            foreach (Cerveau cerveau in GameManager.Instance.cerveaux)
            {
                if (ctx.performed && cerveau.EventCerv is DustCloud)
                {
                    cerveau.CompleteEvent();
                }
            }
            
        }else
        {
            //désactive les essuie glasse
            GameManager.Instance.WiperActivated = false;
            UIManager.Instance.UpdateWiperUI();
        }
    }

    public void DeclinePhone(InputAction.CallbackContext ctx)
    {
        foreach(Cerveau cerveau in GameManager.Instance.cerveaux)
        {
            if (ctx.started && cerveau.EventCerv is PhoneCall)
            {
                cerveau.CompleteEvent();
            }
        }
        
    }

    public void LiberateTrash(InputAction.CallbackContext ctx)
    {
        foreach (Cerveau cerveau in GameManager.Instance.cerveaux)
        {
            if (ctx.started && cerveau.EventCerv is TrashOverload)
            {
                cerveau.CompleteEvent();
            }
        }
    }

    public void TurnOffAlarmClock(InputAction.CallbackContext ctx)
    {
        foreach (Cerveau cerveau in GameManager.Instance.cerveaux)
        {
            if (ctx.started && cerveau.EventCerv is AlarmClock)
            {
                cerveau.CompleteEvent();
            }
        }
    }

}
