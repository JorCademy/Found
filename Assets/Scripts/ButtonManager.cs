using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public AudioSource buttonPressedSound;
    public GameObject interactingObject;
    private Vector2 targetPositionInteractingObject;
    public float distanceDownButton;
    private Vector3 targetPositionButton;
    public float movementSpeed;
    private bool buttonPressed;
    public bool startMoving;
    public float distanceDownBarrier;

    // Start is called before the first frame update
    void Start()
    {
        buttonPressed = false;

        startMoving = false;

        // Determine the position the door should move towards when a button is pressed
        targetPositionInteractingObject = new Vector2(interactingObject.transform.position.x, (interactingObject.transform.position.y - distanceDownBarrier));
        
        // Making sure that the speed is the same for all screens
        movementSpeed = movementSpeed * Time.deltaTime;

        // Determining the target position of the button when it gets pressed
        targetPositionButton = new Vector3(transform.position.x, (transform.position.y - distanceDownButton), 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Code for opening the door
        if (startMoving == true)
        {
            interactingObject.transform.position = Vector2.MoveTowards(interactingObject.transform.position, targetPositionInteractingObject, movementSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player touches the button, the connected door will open and the button will move
        if (collision.collider.name == "Player")
        {
            if (!buttonPressed)
            {
                buttonPressedSound.Play();
                buttonPressed = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPositionButton, 100 * Time.deltaTime);

            startMoving = true;            
        }
    }
}
