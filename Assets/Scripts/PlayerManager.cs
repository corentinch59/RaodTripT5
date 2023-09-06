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
}
