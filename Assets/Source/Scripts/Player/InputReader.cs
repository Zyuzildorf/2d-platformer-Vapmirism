using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    public bool IsLeftMouseButtonPressed { get; private set; }
    public bool IsRightMouseButtonPressed { get; private set; }
    public bool IsSpacebarPressed { get; private set; }
    public float Direction { get; private set; }

    private void Update()
    {
        UpdateKeyboardInput();
        UpdateMouseButtonInput();
        UpdateSpaceBarInput();
    }

    private void UpdateMouseButtonInput()
    {
        IsLeftMouseButtonPressed = Input.GetKeyDown(KeyCode.Mouse0);
        IsRightMouseButtonPressed = Input.GetKeyDown(KeyCode.Mouse1);
    }

    private void UpdateKeyboardInput()
    {
        Direction = Input.GetAxis(Horizontal);
    }

    private void UpdateSpaceBarInput()
    {
        IsSpacebarPressed = Input.GetKeyDown(KeyCode.Space);
    }
}