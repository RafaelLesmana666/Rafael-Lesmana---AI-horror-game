using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static GameInputAction;

// kalo interface disini perlu implementasi semua function yang ada di interface (beda kaya golang)
public class InputMovement : MonoBehaviour, IPlayerActions
{
    private GameInputAction _inputAction;
    public UnityEvent<Vector2> OnMoveInput;
    public UnityEvent<bool> OnSprintInput;
    public UnityEvent<bool> OnJumpInput;
    public UnityEvent OnInteractInput;
    public UnityEvent OnFlashlightInput;

    private bool _isSprintButtonHeld;

    private void Awake()
    {
        _inputAction = new GameInputAction();
        _inputAction.Enable();
        _inputAction.Player.Enable();
        _inputAction.Player.SetCallbacks(this);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnInteractInput?.Invoke();
        }
    }

    public void OnFlashLight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnFlashlightInput?.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveInput?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnJumpInput?.Invoke(true);
        }
        else
        {
            OnJumpInput?.Invoke(false);
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isSprintButtonHeld = true;
        }
        else
        {
            _isSprintButtonHeld = false;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        OnSprintInput?.Invoke(_isSprintButtonHeld);
    }
}
