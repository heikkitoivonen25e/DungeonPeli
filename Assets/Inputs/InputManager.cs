using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _interactAction;
    [SerializeField] private PlayerController _playerController;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move", false);
        _interactAction = _playerInput.actions.FindAction("Interact", false);
        // _moveAction = _playerInput.actions["Move"];
        // _interactAction = _playerInput.actions["Interact"];

        

    }

    
    private void OnEnable()
    {
        // _interactAction.performed += OnInteractPerformed;
        if (_interactAction != null)
        {
            _interactAction.performed += OnInteractPerformed;
            Debug.Log("Interact callback subscribed.");
        }
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
        Debug.Log("INTERACT CALLBACK FIRED!");

        if (_playerController != null)
            _playerController.Interact();
        else
            Debug.LogError("PlayerController component not found!");
    }
}
