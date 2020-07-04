using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villagers : MonoBehaviour
{
    // Declaring needed variables
    public float speed;
    private bool startWalking;
    private float direction;
    private float secondsToWait;
    private Rigidbody2D Rb;
    float randomNumberGenerated;
    public float minimumX;
    public float maximumX;
    public float positionX;
    // public Vector3 targetPosition;
    // private float targetPositionX;

    // Start is called before the first frame update
    void Start()
    {
        speed = 100f;
        
        Rb = GetComponent<Rigidbody2D>();
        
        startWalking = false;

        StartCoroutine(ToggleStartWalking());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if the NPC can start moving
        if (startWalking == true)
        {
            Rb.velocity = new Vector2(speed * Time.deltaTime, Rb.velocity.y);
        } else if (startWalking == false)
        {
            Rb.velocity = new Vector2(0, 0);
        }
    }

    private void Update()
    {
        positionX = transform.position.x;

        if (positionX >= maximumX)
        {
            speed *= -1;
        } else if (positionX <= minimumX)
        {
            speed *= -1;
        }
    }

    // Generating a random number
    float GenerateRandomNumber(string option)
    {
        if (option == "seconds")
        {
            randomNumberGenerated = Random.Range(0, 8);
        } else if (option == "direction")
        {
            randomNumberGenerated = Random.Range(0, 2);
        }

        return randomNumberGenerated;
    }

    IEnumerator ToggleStartWalking()
    {
        while (true)
        {
            secondsToWait = GenerateRandomNumber("seconds");
            direction = GenerateRandomNumber("direction");

            yield return new WaitForSeconds(secondsToWait);

            if (direction == 1 && transform.position.x < maximumX)
            {
                direction = 1;
            }
            else
            {
                direction = 0;
            }

            // Initializing the direction of the movement
            if (direction == 1)
            {
                speed = 100f;
            } else
            {
                speed = -100f;
            }

            // Passing whether or not the object should move
            if (startWalking == false)
            {
                startWalking = true;
                break;
            }
            else if (startWalking == true)
            {
                startWalking = false;
                break;
            }
        }

        // Starting the coroutine again
        StartCoroutine(ToggleStartWalking());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Makes sure the player can't push NPC's
        if (collision.collider.name == "Player")
        {
            Rb.isKinematic = true;
        }

        // Making sure that the NPC's Kylie and Brandon won't push each other forward
        if (collision.collider.name == "Kylie" || collision.collider.name == "Michael")
        {
            speed *= -1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Makes sure the player can't push NPC's
        if (collision.collider.name == "Player")
        {
            Rb.isKinematic = false;
        }
    }
}
