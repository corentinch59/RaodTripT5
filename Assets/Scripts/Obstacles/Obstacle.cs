using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField, Range(0,1)] private float _damage;
    protected Rigidbody _rb;
    public float Damage => _damage;

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
