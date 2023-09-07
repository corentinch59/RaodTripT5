using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected Rigidbody _rb;
    protected RaycastHit _hit;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        ObstacleMovement();
    }

    public virtual void ObstacleMovement()
    {
        _rb.velocity = new Vector3(0.0f, 0.0f, -5000.0f * GameManager.Instance.Speed * Time.fixedDeltaTime);
       
    }
}
