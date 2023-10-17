using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerBody;
    public float speed = 250f;
    public float jumpHeight = 300f;
    private BoxCollider2D playerOffsetCollider;
    public LayerMask groundLayer;
    public LayerMask wallsLayer;
    private bool doJump = false;
    private bool isGrabbingWall = false;
    private bool isGrounded = false;
    private bool isAgainstWall = false;
    private  PlayerInputHandler playerInputs;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerOffsetCollider = GetComponent<BoxCollider2D>();
        playerInputs = GetComponent<PlayerInputHandler>();
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
        UpdatePlayerState();
    }

    void GetEnvironmentChecks()
    {
        isGrounded = playerOffsetCollider.IsTouchingLayers(groundLayer);
        isAgainstWall = playerOffsetCollider.IsTouchingLayers(wallsLayer);
    }

    void UpdatePlayerState()
    {
        if(!isAgainstWall)
        {
            isGrabbingWall = false;
        }

        if(isGrounded && !isAgainstWall)
        {
            isGrabbingWall = false;
        }

        if (playerInputs.GetJumpInputPressed() && isGrounded)
        {
            doJump = true;
        }

        if (playerInputs.GetGrabInputPressed() && !isGrounded && isAgainstWall)
        {
            isGrabbingWall = true;
            isGrounded = true;
        }
        
        if(isAgainstWall && isGrabbingWall && playerInputs.GetJumpInputPressed())
        {
            doJump = true;
            isGrabbingWall = false;
        }
    }

    Vector2 GetNewHorizontalVelocity()
    {
        Vector2 newHorizontalVelocity = playerBody.velocity;
        Vector2 horizontalInput = playerInputs.GetHorizontalInput();

        newHorizontalVelocity.x = horizontalInput.x * speed * Time.deltaTime;
        
        return newHorizontalVelocity;
    }

    Vector2 GetNewVerticalVelocity()
    {
        Vector2 newVerticalVelocity = playerBody.velocity;

        if (doJump)
        {
            newVerticalVelocity.y = jumpHeight * Time.deltaTime;
            doJump = false;
        }

        if (isGrabbingWall)
        {
            newVerticalVelocity.y = 0;
        }
        else
        {
            newVerticalVelocity.y += Physics2D.gravity.y * Time.deltaTime;
        }
        

        return newVerticalVelocity;
    }
}
