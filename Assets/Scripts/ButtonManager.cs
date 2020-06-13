using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject interactingObject;
    private Vector2 targetPositionInteractingObject;
    public float movementSpeed;
    public bool startMoving;

    // Start is called before the first frame update
    void Start()
    {
        startMoving = false;
        targetPositionInteractingObject = new Vector2(interactingObject.transform.position.x, (interactingObject.transform.position.y - 20));
        movementSpeed = movementSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving == true)
        {
            interactingObject.transform.position = Vector2.MoveTowards(interactingObject.transform.position, targetPositionInteractingObject, movementSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            startMoving = true;            
        }
    }
}
