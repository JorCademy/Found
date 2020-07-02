using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public Animator animator;
    public string levelToLoad;
    public GameObject player;
    private bool fadeToNextLevelPlayer;

    // Update is called once per frame
    void Update()
    {
        // Importing the fadeToNextLevel variable from the Player script
        fadeToNextLevelPlayer = player.GetComponent<Player>().fadeToNextLevel;
        
        // Import the level to load next from the Player script
        if (SceneManager.GetActiveScene().name != "StartingMenu")
        {
            levelToLoad = player.GetComponent<Player>().nextLevel;
        }

        // Fading to the level when fadeToNextLevel is true
        if (fadeToNextLevelPlayer == true)
        {
            FadeToLevel();
        }
    }

    // Trigger the fading animation
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeIn");
    }

    // Action for when the fading animation has been completed
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
