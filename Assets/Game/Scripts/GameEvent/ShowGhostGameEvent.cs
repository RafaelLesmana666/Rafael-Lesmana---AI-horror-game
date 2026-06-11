using UnityEngine;

public class ShowGhostGameEvent : GameEventBase
{
    [SerializeField]
    private GameObject _ghostObject;

    [SerializeField]
    private bool _isDestoryAfterFinished;

    public override void Trigger()
    {
        if (_ghostObject != null)
        {
            _ghostObject.SetActive(true);
        }
        base.Trigger();
    }

    public override void Finish()
    {
        if (_ghostObject != null && _isDestoryAfterFinished == true)
        {
            Destroy(_ghostObject);
        }

        base.Finish();
    }
}
