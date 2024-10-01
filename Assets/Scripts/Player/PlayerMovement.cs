
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Attributes")]
    public float maxSpeed = 12f;
    public float acceleration = 10f;
    public float deceleration = 20f;
    public float changeDirectionDeceleration = 50f; // Mayor desaceleración al cambiar de dirección

    [Header("Gravity attributes")]
    public float gravityScale = 3f;
    private bool gravityInverted = false;

    private Rigidbody2D rb;
    private float moveInput;
    private bool facingRight = true;
    public float actualSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleGravity();
        }
    }

    void FixedUpdate()
    {
        Movement();

        if (facingRight == false && moveInput > 0)
            Flip();
        else if (facingRight == true && moveInput < 0)
            Flip();

        actualSpeed = Mathf.Abs(rb.velocity.x);
    }

    void Movement()
    {
        float targetSpeed = moveInput * maxSpeed;
        float currentChangeRate = acceleration;

        if (moveInput == 0)
        {
            currentChangeRate = deceleration;
        }
        else if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(moveInput))
        {
            currentChangeRate = changeDirectionDeceleration;
        }
        else if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(targetSpeed))
        {
            currentChangeRate = deceleration;  
        }

        float movement = Mathf.MoveTowards(rb.velocity.x, targetSpeed, currentChangeRate * Time.fixedDeltaTime);
        rb.velocity = new Vector2(movement, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void ToggleGravity()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);

        gravityInverted = !gravityInverted;

        if (gravityInverted)
        {
            rb.gravityScale = -gravityScale;
            transform.rotation = Quaternion.Euler(0, 0, 180f);
        }
        else
        {
            rb.gravityScale = gravityScale;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    #region ----- Mobile Buttons -----
    public void OnLeftButtonDown()
    {
        moveInput = -1f;
    }

    public void OnLeftButtonUp()
    {
        moveInput = 0f;
    }

    public void OnRightButtonDown()
    {
        moveInput = 1f;
    }

    public void OnRightButtonUp()
    {
        moveInput = 0f;
    }
    #endregion
}
