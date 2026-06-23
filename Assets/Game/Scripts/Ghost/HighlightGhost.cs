using UnityEngine;
using UnityEngine.Events;

public class HighlightGhost : MonoBehaviour
{
    [SerializeField]
    private float _maxDistance = 10;

    [SerializeField]
    private float _dotTreshold = 0.8f;

    [SerializeField]
    private bool _autoActive = false;

    public UnityEvent OnSeeGhost;
    private bool _isActive = false;

    private void Awake()
    {
        _isActive = _autoActive;
    }

    public void SetActive(bool value)
    {
        _isActive = value;
    }

    private bool CheckPlayerSeeGhost()
    {
        Transform playerCamera = Camera.main.transform;
        Vector3 ghostDirection = (transform.position - playerCamera.position).normalized;

        //result = 1 searah
        //result = 0 tegak lurus
        //result = -1 terbalik

        float dotResult = Vector3.Dot(playerCamera.forward, ghostDirection);
        if (dotResult > _dotTreshold)
        {
            float distance = Vector3.Distance(playerCamera.position, transform.position);

            if (distance < _maxDistance)
            {
                return true;
            }
        }

        return false;
    }

    private void Update()
    {
        if (_isActive)
        {
            bool isPlayerSeeGhost = CheckPlayerSeeGhost();
            if (isPlayerSeeGhost)
            {
                OnSeeGhost?.Invoke();
                Destroy(this);
            }
        }
    }
}
