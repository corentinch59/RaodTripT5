using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _previous;

    public void Dynamo(InputAction.CallbackContext ctx)
    {
        Vector2 temp = ctx.ReadValue<Vector2>();

        float angle = Vector2.SignedAngle(temp, _previous);

        _previous = temp;
    }
}
