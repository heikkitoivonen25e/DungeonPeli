using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Vector2 _movement;
    private Rigidbody2D _rb;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);
        _rb.linearVelocity = _movement * _moveSpeed;
    }



}
