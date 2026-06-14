using UnityEngine;

public class DisplayCursor : MonoBehaviour
{
    public void ShowCursor()
    {
        Cursor.visible = true;
        // cursor mouse akan dikunci di tengah layar
        Cursor.lockState = CursorLockMode.None;
    }
}
