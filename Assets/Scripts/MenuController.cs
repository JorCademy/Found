using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource startingSound;

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Starting the game when the player pressed SPACE in the Main Menu
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startingSound.Play();

            StartCoroutine(WaitWhenStarting());
        }

        // Deleting the stored memory when starting a new game
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    IEnumerator WaitWhenStarting()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Scenes/StartingMessage");
    }
}
