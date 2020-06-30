using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartingMenu")
        {
            // Starting the game when the player pressed SPACE in the Main Menu
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Center");
            }

            // Deleting the stored memory when starting a new game
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PlayerPrefs.DeleteAll();
            }
        }
    }
}
