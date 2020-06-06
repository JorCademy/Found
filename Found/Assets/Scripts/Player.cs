using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D Rb;
    public float playerSpeed;
    public float jumpForce;
    private float direction;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJump;
    public int extraJumpValue;

    // Start is called before the first frame update
    void Start()
    {
        extraJump = extraJumpValue;
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        direction = Input.GetAxis("Horizontal");

        Rb.velocity = new Vector2(direction * playerSpeed, Rb.velocity.y);
    }

    private void Update()
    {
        if (isGrounded)
        {
            extraJump = 1;
        }

        if (Input.GetKeyDown(KeyCode.W) && extraJump > 0)
        {
            Rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJump == 0 && isGrounded == true)
        {
            Rb.velocity = Vector2.up * jumpForce;
        }
    }
}
