using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool startMoving;
    private Rigidbody2D Rb;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure that the platform isn't moving at the start of the scene
        startMoving = false;

        Rb = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {
        // Determine the movementSpeed based on the startMoving variable
        if (startMoving)
        {
            Rb.velocity = Vector2.right * movementSpeed;
        } else
        {
            Rb.velocity = Vector2.right * 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check whether or not the platform should be moving
        if (collision.collider.name == "FinalPlatform")
        {
            startMoving = false;
        } else if (collision.collider.name == "Player")
        {
            startMoving = true;
        }
    }
}
