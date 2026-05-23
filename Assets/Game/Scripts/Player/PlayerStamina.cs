using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    // Membuat variable untuk menentukan maksimum stamina player
    [SerializeField]
    private float _maxStamina = 100;

    // Membuat variable untuk menentukan jumlah stamina yang dibutuhkan untuk sprint
    [SerializeField]
    private float _sprintStaminaCost = 20;

    // Membuat variable untuk menentukan nilai regenerasi stamina
    [SerializeField]
    private float _staminaRegenValue = 20;

    // Membuat menghitung stamina yang dimiliki player character
    private float _currentStamina;

    //kalo stamina abis gaboleh lari tapi kalo udah full baru boleh selama button nya dipress
    public bool CanSprint { get; private set; } = true;

    public void CalculateStamina()
    {
        _currentStamina = _currentStamina - _sprintStaminaCost * Time.deltaTime;
        _currentStamina = Mathf.Clamp(_currentStamina, 0, _maxStamina);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentStamina = _maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentStamina < _maxStamina && !CanSprint)
        {
            _currentStamina = _currentStamina + _staminaRegenValue * Time.deltaTime;
            _currentStamina = Mathf.Clamp(_currentStamina, 0, _maxStamina);

            if (_currentStamina == _maxStamina)
            {
                CanSprint = true;
            }
        }

        if (_currentStamina == 0)
        {
            CanSprint = false;
        }
    }
}
