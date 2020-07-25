using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySystem : MonoBehaviour
{
    static int startingAmountOfKeys;
    public Text amounfOfKeysText;

    // Start is called before the first frame update
    void Start()
    {
        // Gathering the starting amount of keys in this session 
        startingAmountOfKeys =  PlayerPrefs.GetInt("Keys", 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Displaying the amount of keys in the console
        amounfOfKeysText.text = PlayerPrefs.GetInt("Keys", 0).ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Adding a key when colliding with one
        if (collision.collider.name == "Key")
        {
            startingAmountOfKeys += 1;
            PlayerPrefs.SetInt("Keys", startingAmountOfKeys);
        }
    }
}
