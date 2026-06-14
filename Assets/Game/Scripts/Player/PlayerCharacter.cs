using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _movement;

    [SerializeField]
    private PlayerStamina _stamina;

    [SerializeField]
    private InventoryManager _inventory;

    [SerializeField]
    private InteractDetector _interactDetector;

    [SerializeField]
    private CameraManager _cameraManager;

    [SerializeField]
    private InputMovement _input;

    [SerializeField]
    private Flashlight _flashlight;

    public UnityEvent OnDeath;

    // Property untuk mengakses variable _movement
    public PlayerMovement Movement => _movement;

    // Property untuk mengakses variable _stamina
    public PlayerStamina Stamina => _stamina;

    // Property untuk mengakses variable _inventory
    public InventoryManager Inventory => _inventory;

    // Property untuk mengakses variable _cameraManager
    public CameraManager Camera => _cameraManager;

    // Property untuk mengakses variable _interactDetector
    public InteractDetector InteractDetector => _interactDetector;

    public InputMovement Input => _input;

    public Flashlight Flashlight => _flashlight;

    public bool IsHiding { get; private set; }

    // Function untuk mengubah status hiding player
    public void SetIsHiding(bool isHiding)
    {
        IsHiding = isHiding;
    }

    private void Awake()
    {
        // Ketika game dijalankan,
        // cursor mouse akan disembunyikan
        Cursor.visible = false;
        // cursor mouse akan dikunci di tengah layar
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Death()
    {
        OnDeath?.Invoke();
    }
}
