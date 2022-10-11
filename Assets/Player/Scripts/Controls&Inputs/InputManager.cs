using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;

    private static InputManager _instance;

    public static InputManager Instance { get => _instance; }

    private void Awake()
    {
        if (_instance != null && _instance == this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            _instance = this;
        }

        playerControls = new PlayerControls();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>(); 
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }
}
