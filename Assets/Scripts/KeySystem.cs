using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySystem : MonoBehaviour
{
    static int startingAmountOfKeys;
    public Text amounfOfKeysText;
    private bool addedKey;
    public string linkedNpcName;

    // Start is called before the first frame update
    void Start()
    {
        // Gathering the starting amount of keys in this session 
        startingAmountOfKeys =  PlayerPrefs.GetInt("Keys", 0);
        addedKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Displaying the amount of keys in the console
        amounfOfKeysText.text = PlayerPrefs.GetInt("Keys", 0).ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (linkedNpcName == "Mayor")
        {
            PlayerPrefs.SetInt("PlayedMayorLevel", 1);
        } else if (linkedNpcName == "Mary")
        {
            PlayerPrefs.SetInt("PlayedMaryLevel", 1);
        } else if (linkedNpcName == "John")
        {
            PlayerPrefs.SetInt("PlayedJohnLevel", 1);
        } else if (linkedNpcName == "Michael")
        {
            PlayerPrefs.SetInt("PlayedMichaelLevel", 1);
        } else if (linkedNpcName == "Kylie")
        {
            PlayerPrefs.SetInt("PlayedKylieLevel", 1);
        } else
        {
            PlayerPrefs.SetInt("PlayedBrandonLevel", 1);
        }

        // Adding a key when colliding with one
        if (collision.collider.name == "Key")
        {
            if (addedKey != true)
            {
                startingAmountOfKeys += 1;
                PlayerPrefs.SetInt("Keys", startingAmountOfKeys);
                addedKey = true;
            }
        }
    }
}
