using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

    public Interactable currentinteractable;
    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _dashDistance;
    private PlayerAction _playerAction;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveInput;

    private InputAction _interactAction;
    

    private void Awake()
    {
        //Initialize private Variables 
        _playerAction = new PlayerAction();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if(_rigidbody2D is null)
            Debug.LogError("Player Rigidbody is null");
    }

    private void Start()
    {
        _interactAction = _playerInput.actions.FindAction("Interact");
        _interactAction.performed += Interact;
    }

    private void OnEnable()
    {
        _playerAction.Player.Enable();
        _playerInput.actions.Enable();
    }

    private void OnDisable()
    {
        _playerAction.Player.Disable();
        _interactAction.performed -= Interact;
    }

    private void FixedUpdate()
    {
        _moveInput = _playerAction.Player.Movement.ReadValue<Vector2>();
        _rigidbody2D.velocity = _moveInput * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interactable collidedInteractable = other.GetComponent<Interactable>();

        if (collidedInteractable == null)
        {
            return;
        }

        currentinteractable = collidedInteractable;
        Gamemanager.instance.ShowInteractUI(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentinteractable == null)
        {
            return;
        }

        Interactable collidedInteractable = other.GetComponent<Interactable>();
        
        //Clear Interactable from the memory
        if (collidedInteractable == currentinteractable)
        {
            currentinteractable = null;
            Gamemanager.instance.ShowInteractUI(false);
        }
    }
    
    private void Interact(InputAction.CallbackContext obj)
    {
        if (currentinteractable == null) {return;}

        //Play Interact Animation if specified
        if (currentinteractable.interactAnimation != "")
        {
            //_animator.SetBool("EmoteButton",false);
            //_animator.Play(_currentinteractable.interactAnimation); //
        }
            
        currentinteractable.onInteract.Invoke();
    }
}
