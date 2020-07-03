using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveCharacter : MonoBehaviour
{
    public Rigidbody2D Rb;
    public bool finalLoveCubeMovement;
    public Vector3 finalTargetPosition;

    // Update is called once per frame
    private void Update()
    {
        finalLoveCubeMovement = gameObject.GetComponent<EndScene>().loveCubeMovement;

        if (gameObject.GetComponent<EndScene>().loveCubeMovement)
        {
            Debug.Log("Start moving!");

            transform.position = Vector3.MoveTowards(transform.position, finalTargetPosition, 0.05f);
        }
    }
}
