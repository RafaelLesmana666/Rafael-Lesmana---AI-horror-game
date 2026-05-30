using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string _name;

    // Variable untuk reference ke component transform pintu.
    // Component transform digunakan untuk menggeser posisi dan memutar pintu
    [SerializeField]
    protected Transform _doorTransform;

    // Variable untuk menentukan durasi animasi membuka dan menutup pintu
    [SerializeField]
    protected float _duration = 1f;

    // Variable untuk menentukan apakah pintu dikunci atau tidak
    [SerializeField]
    protected bool _isLocked;

    // Variable untuk menentukan id kunci untuk membuka pintu
    [SerializeField]
    protected string _keyID;

    // Variable untuk menentukan apakah pintu sedang dianimasikan untuk terbuka
    // dan tertutup
    protected bool _isAnimating;

    // Variable untuk menentukan apakah pintu sedang terbuka atau tertutup
    protected bool _isOpen;

    //lock coroutine / asynchronus
    protected Coroutine _animatingDoorCoroutine;

    // Property untuk mendapatkan variable _isAnimating
    public bool IsAnimating => _isAnimating;
    public string Name => _name;

    public UnityEvent OnDoorOpen;
    public UnityEvent OnDoorClose;

    // [ContextMenu("Interact Door")]
    public void Interact(PlayerCharacter mc)
    {
        if (_isLocked == true)
        {
            // Jika pintu dikunci
            // Mengecek apakah player memiliki kuncinya di inventory
            // dengan menggunakan ID nya
            bool hasKey = mc.Inventory.CheckInventory(_keyID);
            if (hasKey == true)
            {
                // Jika punya maka mengubah status pintu menajdi tidak terkunci
                _isLocked = false;
                // Kemudian buka pintu
                Open();
            }
        }
        else
        {
            // Jika tidak terkunci atau kunci telah dibuka
            // Mengecek apakah pintu sedang terbuka
            if (_isOpen == true)
            {
                // Jika pintu terbuka maka tutup pintu
                Close();
            }
            else
            {
                // Jika pintu tertutup maka buka pintu
                Open();
            }
        }
    }

    public virtual void Open()
    {
        _isOpen = true;
        OnDoorOpen?.Invoke();
    }

    public virtual void Close()
    {
        _isOpen = false;
        OnDoorClose?.Invoke();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
