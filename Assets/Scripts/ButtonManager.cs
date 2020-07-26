using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject interactingObject;
    private Vector2 targetPositionInteractingObject;
    private Vector3 targetPositionButton;
    public float movementSpeed;
    public bool startMoving;
    public float distanceDown;

    // Start is called before the first frame update
    void Start()
    {
        startMoving = false;

        // Determine the position the door should move towards when a button is pressed
        targetPositionInteractingObject = new Vector2(interactingObject.transform.position.x, (interactingObject.transform.position.y - distanceDown));
        
        // Making sure that the speed is the same for all screens
        movementSpeed = movementSpeed * Time.deltaTime;

        // Determining the target position of the button when it gets pressed
        targetPositionButton = new Vector3(transform.position.x, transform.position.y - 4, 4f);
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
            transform.position = Vector3.MoveTowards(transform.position, targetPositionButton, 100 * Time.deltaTime);

            startMoving = true;            
        }
    }
}
