using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float deadLevel;

    public int extraJump;
    public int extraJumpValue;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

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

        if (SceneManager.GetActiveScene().name != "Scenes/Center")
        {
            if (transform.position.y <= deadLevel)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Key")
        {
            if (SceneManager.GetActiveScene().name != "Scenes/Center")
            {
                SceneManager.LoadScene("Scenes/Center");
            }
        }
    }
}
