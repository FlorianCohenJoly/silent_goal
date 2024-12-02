using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField, Range(0f, 1f)]
    private float m_Deceleration;

    
    private float m_MoveSpeed = 7;

    private float _dirX = 0;
    private float _dirY = 0;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Move(float dirX, float dirY)
    {
        _dirX = dirX;
        _dirY = dirY;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_dirX) > 0.01f || Mathf.Abs(_dirY) > 0.01f)
        {
            _rigidBody.velocity = new Vector2(_dirX * m_MoveSpeed, _dirY * m_MoveSpeed);
        }
        else
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x * m_Deceleration, _rigidBody.velocity.y * m_Deceleration);
        }
    }
}
