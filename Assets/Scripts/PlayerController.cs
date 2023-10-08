using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerBody;
    public float speed = 2.5f;
    public float jumpHeight = 5f;
    public Transform groundCheck;
    public Transform leftCheck;
    public Transform rightCheck;
    public LayerMask groundLayer;
    public LayerMask wallsLayer;
    public float environmentCheckRadius = 0.05f;
    private bool jumpPressed = false;
    private bool isGrounded = false;
    private bool isAgainstWallOnLeft = false;
    private bool isAgainstWallOnRight = false;

    private PlayerActions playerActions;

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

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 newHorizontalVelocity = GetNewHorizontalVelocity();
        Vector2 newVerticalVelocity = GetNewVerticalVelocity();
        playerBody.velocity = new Vector2(newHorizontalVelocity.x, newVerticalVelocity.y);
    }

    void Update()
    {
        GetEnvironmentChecks();
        if (playerActions.PlayerMap.Jump.triggered && isGrounded)
        {
            jumpPressed = true;
        }
    }

    void GetEnvironmentChecks()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, environmentCheckRadius, groundLayer);
        isAgainstWallOnLeft = Physics2D.OverlapCircle(leftCheck.position, environmentCheckRadius, wallsLayer);
        isAgainstWallOnRight = Physics2D.OverlapCircle(rightCheck.position, environmentCheckRadius, wallsLayer);
    }

    Vector2 GetNewHorizontalVelocity()
    {
        Vector2 newHorizontalVelocity = playerBody.velocity;
        Vector2 horizontalInput = playerActions.PlayerMap.Movement.ReadValue<Vector2>();

        bool isMovingTowardsWallOnLeft = horizontalInput.x < 0 && isAgainstWallOnLeft;
        bool isMovingTowardsWallOnRight = horizontalInput.x > 0 && isAgainstWallOnRight;

        if(isMovingTowardsWallOnLeft || isMovingTowardsWallOnRight)
        {
            newHorizontalVelocity.x = 0;
        }
        else
        {
            newHorizontalVelocity.x = horizontalInput.x * speed;
        }

        return newHorizontalVelocity;
    }

    Vector2 GetNewVerticalVelocity()
    {
        Vector2 newVerticalVelocity = playerBody.velocity;

        if (jumpPressed)
        {
            newVerticalVelocity.y = jumpHeight;
            jumpPressed = false;
        }

        return newVerticalVelocity;
    }
}
