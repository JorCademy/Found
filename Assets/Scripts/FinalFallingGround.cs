using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFallingGround : MonoBehaviour
{
    public Vector3 finalGroundPosition;
    private bool finalFallingGroundObject;

    // Update is called once per frame
    void Update()
    {
        finalFallingGroundObject = GetComponent<EndScene>().fallingGround;

        if (finalFallingGroundObject)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalGroundPosition, 5f * Time.deltaTime);
        }
    }
}
