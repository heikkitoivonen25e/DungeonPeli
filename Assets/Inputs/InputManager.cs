using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _interactAction;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerController = GetComponent<PlayerController>();
        _moveAction = _playerInput.actions["Move"];
        _interactAction = _playerInput.actions["Interact"];
    }

    
    private void OnEnable()
    {
        _interactAction.performed += OnInteractPerformed;
    }

        private void OnDisable()
    {
        _interactAction.performed -= OnInteractPerformed;
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();
    }



    private void OnInteractPerformed(InputAction.CallbackContext ctx)
    {
        _playerController?.Interact();
    }
}
