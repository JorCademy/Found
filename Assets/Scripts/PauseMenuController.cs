using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public bool paused;
    public Canvas pauseMenuCanvas;
    public GameObject player;
    private Player playerScript;
    public ParticleSystem flyingParticles;
    private float startingPlayerSpeed;
    private float startingPlayerJumpForce;
    public bool toStartingMenu;

    // Start is called before the first frame update
    void Start()
    {
        toStartingMenu = false;

        // Disable the pauseMenuCanvas at the start of the scene        
        paused = false;

        // Get the starting playerSpeed
        startingPlayerSpeed = player.GetComponent<Player>().playerSpeed;
        startingPlayerJumpForce = player.GetComponent<Player>().jumpForce;

        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
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
