using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySystem : MonoBehaviour
{
    static int startingAmountOfKeys;
    public Text amounfOfKeysText;
    public string linkedNpcName;
    private string modifyPlayerLevel;
    private int collisionCounter;

    // Start is called before the first frame update
    void Start()
    {
        // Gathering the starting amount of keys in this session 
        startingAmountOfKeys =  PlayerPrefs.GetInt("Keys", 0);
        modifyPlayerLevel = "Played" + linkedNpcName + "Level";
        PlayerPrefs.SetInt(modifyPlayerLevel, 0);
        collisionCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Displaying the amount of keys in the console
        amounfOfKeysText.text = PlayerPrefs.GetInt("Keys", 0).ToString();

        Debug.Log("Mayor: " + PlayerPrefs.GetInt("PlayedMayorLevel"));
        Debug.Log("Mary: " + PlayerPrefs.GetInt("PlayedMaryLevel"));
        Debug.Log("John: " + PlayerPrefs.GetInt("PlayedJohnLevel"));
        Debug.Log("Michael: " + PlayerPrefs.GetInt("PlayedMichaelLevel"));
        Debug.Log("Kylie: " + PlayerPrefs.GetInt("PlayedKylieLevel"));
        Debug.Log("Brandon: " + PlayerPrefs.GetInt("PlayedBrandonLevel"));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Adding a key when colliding with one
        if (collision.collider.name == "Key")
        {
            if (collisionCounter < 1)
            {
                startingAmountOfKeys += 1;
                collisionCounter += 1;
            }

            PlayerPrefs.SetInt("Keys", startingAmountOfKeys);
            PlayerPrefs.SetInt(modifyPlayerLevel, 1);
        }
    }
}
