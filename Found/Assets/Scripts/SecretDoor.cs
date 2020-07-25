using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    private int amountOfKeys;
    private bool doorOpened;
    public Sprite closedDoorSprite;
    public Sprite openedDoorSprite;
    public GameObject goldenKeyParticles;

    // Start is called before the first frame update
    void Start()
    {
        // Determining the sprite to use at the start of the scene
        CheckAmountOfKeys();
        SetOpenedOrClosedDoor();
    }

    // Update is called once per frame
    void Update()
    {
        // Determining the sprite to use per frame
        CheckAmountOfKeys();
        SetOpenedOrClosedDoor();
    }

    void CheckAmountOfKeys()
    {
        // Getting the amount of keys from the memory
        amountOfKeys = PlayerPrefs.GetInt("Keys", 0); ;

        // Determining whether or not the door should be opened or not
        if (amountOfKeys >= 6)
        {
            doorOpened = true;
        } else
        {
            doorOpened = false;
        }
    }

    void SetOpenedOrClosedDoor()
    {
        // Determining the sprite to use
        if (doorOpened)
        {
            // Set opened sprite
            gameObject.GetComponent<SpriteRenderer>().sprite = openedDoorSprite;
            goldenKeyParticles.SetActive(true);
        }
        else
        {
            // Set closed sprite
            gameObject.GetComponent<SpriteRenderer>().sprite = closedDoorSprite;
            goldenKeyParticles.SetActive(false);
        }
    }
}
