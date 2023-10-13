using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerActions playerActions;
    private bool jumpInputPressed;
    private bool grabInputPressed;
    private bool shootInputPressed;

    void Awake()
    {
        playerActions = new PlayerActions();
    }

    void OnEnable()
    {
        playerActions.PlayerMap.Enable();
    }

    void OnDisable()
    {
        playerActions.PlayerMap.Disable();
    }

    void ReadPlayerInputs()
    {
        jumpInputPressed = playerActions.PlayerMap.Jump.triggered;
        grabInputPressed = playerActions.PlayerMap.Grab.triggered;
        shootInputPressed = playerActions.PlayerMap.Fire.triggered;
    }

    void Update()
    {
        ReadPlayerInputs();
    }

    public bool GetJumpInputPressed()
    {
        return jumpInputPressed;
    }

    public bool GetGrabInputPressed()
    {
        return grabInputPressed;
    }

    public bool GetShootInputPressed()
    {
        return shootInputPressed;
    }

    public Vector2 GetHorizontalInput()
    {
        return playerActions.PlayerMap.Movement.ReadValue<Vector2>();
    }
}
