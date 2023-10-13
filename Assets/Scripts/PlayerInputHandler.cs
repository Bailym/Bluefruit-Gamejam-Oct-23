using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private InputActionMap playerActionMap;
    private bool jumpInputPressed;
    private bool grabInputPressed;
    private bool fireInputPressed;

    private Vector2 pointDirection;

    void Awake()
    {
        playerActionMap = GetComponent<PlayerInput>().currentActionMap;
    }

    void OnEnable()
    {
        playerActionMap.Enable();
    }

    void OnDisable()
    {
        playerActionMap.Disable();
    }

    void ReadPlayerInputs()
    {
        jumpInputPressed = playerActionMap.FindAction("Jump").triggered;
        grabInputPressed = playerActionMap.FindAction("Grab").triggered;
        fireInputPressed = playerActionMap.FindAction("Fire").triggered;
        pointDirection = playerActionMap.FindAction("Point").ReadValue<Vector2>();
        Debug.Log(pointDirection);
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

    public bool GetFireInputPressed()
    {
        return fireInputPressed;
    }

    public Vector2 GetHorizontalInput()
    {
        return playerActionMap.FindAction("Movement").ReadValue<Vector2>();
    }

    public Vector2 GetPointDirection()
    {
        return pointDirection;
    }
}
