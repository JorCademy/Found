using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    private bool paused;
    public Canvas pauseMenuCanvas;
    public GameObject player;
    public ParticleSystem flyingParticles;
    private float startingPlayerSpeed;
    private float startingPlayerJumpForce;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the pauseMenuCanvas at the start of the scene        
        paused = false;

        // Get the starting playerSpeed
        startingPlayerSpeed = player.GetComponent<Player>().playerSpeed;
        startingPlayerJumpForce = player.GetComponent<Player>().jumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(paused);

        // Enable or disable pauseMenuCanvas
        if (paused == false)
        {
            pauseMenuCanvas.enabled = false;
            pauseGameObjects();
        }
        else
        {
            pauseMenuCanvas.enabled = true;
            pauseGameObjects();
        }

        // Toggle pauseMenu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {
                paused = true;
            }
            else
            {
                paused = false;
            }
        }

        // Continue the game when paused and Continue selected
        if (paused == true)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                paused = false;
            } 
        }
    }

    void pauseGameObjects()
    {
        Debug.Log(paused);

        if (paused == true)
        {
            // Stop player movement
            player.GetComponent<Player>().playerSpeed = 0;
            player.GetComponent<Player>().jumpForce = 0;

            // Stop flying particles
            flyingParticles.Pause(true);
        }
        else
        {
            // Restart player movement
            player.GetComponent<Player>().playerSpeed = startingPlayerSpeed;
            player.GetComponent<Player>().jumpForce = startingPlayerJumpForce;

            // Restart flying particles
            flyingParticles.Play(true);
        }
    }
}
