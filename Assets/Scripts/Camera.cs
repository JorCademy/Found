using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private float playerX;
    private float playerY;

    // Update is called once per frame
    void Update()
    {
        playerY = player.GetComponent<Transform>().position.y;
        playerX = player.GetComponent<Transform>().position.x;
        transform.position = new Vector3(playerX, playerY, -10);
    }
}
