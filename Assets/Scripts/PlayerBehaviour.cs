using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed;
    private PlayerAction _playerAction;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveInput;

    private void Awake()
    {
        //Initialize private Variables 
        _playerAction = new PlayerAction();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if(_rigidbody2D is null)
            Debug.LogError("Player Rigidbody is null");
    }

    private void OnEnable()
    {
        _playerAction.Player.Enable();
    }

    private void OnDisable()
    {
        _playerAction.Player.Disable();
    }

    private void FixedUpdate()
    {
        _moveInput = _playerAction.Player.Movement.ReadValue<Vector2>();
        _rigidbody2D.velocity = _moveInput * _speed;
    }
}
