using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private float playerX;
    private float playerY;
    public Vector3 finalTargetPosition;
    public AudioSource finalSceneAudioSource;
    private bool startTimerCamera;

    private void Start()
    {
        startTimerCamera = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "FinalLevel")
        {
            startTimerCamera = finalSceneAudioSource.GetComponent<EndScene>().startTimer;
        }

        if (!startTimerCamera)
        {
            playerY = player.GetComponent<Transform>().position.y;
            playerX = player.GetComponent<Transform>().position.x;
            transform.position = new Vector3(playerX, playerY, -10);
        }

        if (SceneManager.GetActiveScene().name == "FinalLevel")
        {
            if (startTimerCamera)
            {
                transform.position = Vector3.MoveTowards(transform.position, finalTargetPosition, 5f * Time.deltaTime);
                startTimerCamera = false;
            }  
        }
    }
}
