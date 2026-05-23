using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _charaController;

    [SerializeField]
    private PlayerStamina _playerStamina;

    [SerializeField]
    private Transform _groundCheck;

    [SerializeField]
    private float _gravityScale = 1;

    [SerializeField]
    private float _walkSpeed = 1;

    [SerializeField]
    private float _sprintSpeed = 5;

    [SerializeField]
    private float _acceleration = 0.5f;

    private float _velocityY;
    private Vector3 _movementDirection;
    private Vector3 _velocityXZ;

    private float _currentSpeed;
    private bool _isSprint;
    private bool _isJump;

    public void SetMoveDirection(Vector2 inputDirection)
    {
        _movementDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
    }

    public void SetSprint(bool isSprint)
    {
        _isSprint = isSprint;
    }

    public void SetJump(bool isJump)
    {
        _isJump = isJump;
    }

    private void CalculateVelocityXZ()
    {
        // Mendapatkan transform camera untuk mendapatkan rotasi camera
        Transform cameraTransform = Camera.main.transform;
        // Menghitung arah gerakkan sumbu x
        // disesuaikan dengan arah samping camera
        Vector3 xDirection = _movementDirection.x * cameraTransform.right;
        // Menghitung arah gerakkan sumbu z
        // disesuaikan dengan arah depan camera
        Vector3 zDirection = _movementDirection.z * cameraTransform.forward;
        // Menggabung arah gerakkan sumbu x dan sumbu z ke dalam satu vector
        Vector3 direction = xDirection + zDirection;
        // Arah gerakkan y dibuat nol,
        // karena tidak ada gerakan ke arah atas dan bawah
        direction.y = 0;
        //ngecek kalo ada inputan di x kalo ! = 0

        if (_movementDirection.magnitude >= 0.01)
        {
            _velocityXZ = direction.normalized * _currentSpeed * Time.deltaTime;
        }
        else
        {
            _velocityXZ = Vector3.zero;
        }
    }

    private void CalculateAcceleration()
    {
        // Mengecek apakah player character bergerak atau tidak
        if (_movementDirection.magnitude >= 0.01)
        {
            // Jika karakter bergerak maka akan mengecek
            // Apakah character sedang sprint atau tidak
            Debug.Log(_playerStamina.CanSprint);
            if (_isSprint && _playerStamina.CanSprint)
            {
                // Jika sedang sprint maka kecepatan akan bertambah
                // sebesar nilai acceleration setiap detik
                _currentSpeed = _currentSpeed + _acceleration * Time.deltaTime;
                _playerStamina.CalculateStamina();
            }
            else
            {
                // Jika berhenti sprint maka kecepatan akan berkurang
                // sebesar nilai acceleration setiap detik
                _currentSpeed = _currentSpeed - _acceleration * Time.deltaTime;
            }

            _currentSpeed = Mathf.Clamp(_currentSpeed, _walkSpeed, _sprintSpeed);
        }
        else
        {
            // Jika tidak bergerak kecepatan diset nol,
            // agar character tidak bisa bergerak
            _currentSpeed = 0;
        }
    }

    public void Move()
    {
        // Menghitung arah dan kecepatan gerakan character di sumbu x dan z
        CalculateVelocityXZ();
        // Menghitung arah dan kecepatan gerakan character di sumbu y
        // CalculateVelocityY();
        // Menggabung arah dan kecepatan gerakan character di sumbu x, y, dan z
        Vector3 velocity = new Vector3(_velocityXZ.x, _velocityY, _velocityXZ.z);
        // Menggerakkan character sesuai arah dan kecepatan yang sudah dihitung
        _charaController.Move(velocity);
    }

    //check grounded
    private bool _isGrounded;

    private void CheckIsGrounded()
    {
        // Mendapatkan layer Ground
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        Debug.Log(groundLayer);
        // Membuat pendeteksi berbentuk bola
        // Posisi pendeteksi nya di transform.position(posisi kaki character)
        // Radius = 0.5
        // Layer object yang dicek adalah layer ground
        // Jika terdeteksi _isGrounded bernilai true,
        // jika tidak _isGrounded bernilai false
        _isGrounded = Physics.CheckSphere(_groundCheck.position, 0.5f, groundLayer);
    }

    private void ResetVelocity()
    {
        if (_isGrounded == true)
        {
            _velocityY = 0;

            if (_isJump)
            {
                _velocityY = 1;
                _isJump = false;
            }
        }
        else
        {
            _velocityY = _velocityY + Physics.gravity.y * _gravityScale * Time.deltaTime;
        }
    }

    private void Update()
    {
        CheckIsGrounded();
        CalculateAcceleration();

        ResetVelocity();
        Move();
    }
}
