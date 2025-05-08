using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    public bool IsMouseButtonPressed { get; private set; }
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
        IsMouseButtonPressed = Input.GetKeyDown(KeyCode.Mouse0);
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