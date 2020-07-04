using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    // Declaring needed variables
    public Text dialogueText;
    public Text characterName;
    public GameObject characterKit;
    public string[] dialogues;
    public GameObject player;
    private Vector2 playerPosition;
    private Player playerScript;
    private string dialogueDisplayed;
    private bool spacePressed;
    private Villagers villagerScript;
    private int iterator;
    private bool readyForLevel;
    public string nextLevelName;
    private int amountOfKeys;
    public int npcRank;
    public string succeededLevelMessage;
    
    // Start is called before the first frame update
    void Start()
    {
        iterator = 0;

        spacePressed = false;
        
        characterKit.SetActive(false);
        
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        
        villagerScript = this.GetComponent<Villagers>();

        readyForLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Receiving the amount of keys stored in memory
        amountOfKeys = PlayerPrefs.GetInt("Keys", 0);
        Debug.Log(amountOfKeys);

        // Determining the player position
        playerPosition = player.transform.position;

        // Making sure the text is displayed
        if (npcRank > amountOfKeys)
        {
            dialogueText.text = dialogueDisplayed;
        }

        // Checking when space is pressed for starting conversation
        if (npcRank <= amountOfKeys)
        {
            dialogueText.text = succeededLevelMessage;
        } 

        if (gameObject.name == "Secret Door")
        {
            if (amountOfKeys >= 6)
            {
                if (Vector2.Distance(transform.position, playerPosition) < 3)
                {
                    characterKit.SetActive(true);
                    dialogueDisplayed = "Press 'E' to open the secret door.";
                    characterName.text = gameObject.name;

                    readyForLevel = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        playerScript.nextLevel = "Scenes/" + nextLevelName;
                    }
                }
            }
        }

        if (spacePressed == true && npcRank > amountOfKeys && gameObject.name != "Secret Door")
        {
            // Making sure that the player sees the dialogues
            characterKit.SetActive(true);

            // Making sure that the characters can't move during the conversation
            playerScript.playerSpeed = 0;
            playerScript.jumpForce = 0;
            villagerScript.speed = 0;

            // Looping through the dialogues when space is pressed
            while (true)
            {
                if (iterator < dialogues.Length)
                {
                    dialogueDisplayed = dialogues[iterator].ToString();

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        iterator++; 
                    }
                } else
                {
                    spacePressed = false;
                }

                // Making sure that the player can now play the character's level
                readyForLevel = true;

                break;
            }
        }

        // Making sure that the player can start the level when the conversation has taken place
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(transform.position, playerPosition) < 3 && npcRank > amountOfKeys)
        {
            playerScript.nextLevel = "Scenes/" + nextLevelName;
            playerScript.fadeToNextLevel = true;
        }

        if (npcRank <= amountOfKeys)
        {
            spacePressed = false;
        }

        // Making sure that the text disappears when there is no conversation anymore
        if (Vector2.Distance(transform.position, playerPosition) < 3 && spacePressed == false && gameObject.name != "Secret Door")
        {
            // Display the name of the NPC
            characterName.text = gameObject.name;

            iterator = 0;

            // Initializing the text the player sees when it is near the NPC
            if (npcRank > amountOfKeys)
            {
                if (readyForLevel == false)
                {
                    dialogueDisplayed = "Press Space to talk.";
                }
                else
                {
                    if (gameObject.name == "Mayor")
                    {
                        dialogueDisplayed = "Press Space to talk.\n\nPress 'E' to get in the " + gameObject.name + "'s mind.";
                    }
                    else
                    {
                        dialogueDisplayed = "Press Space to talk.\n\nPress 'E' to get in " + gameObject.name + "'s mind.";
                    }
                }
            }

            characterKit.SetActive(true);

            // Making sure that the player and NPC can move (again)
            playerScript.playerSpeed = 10;
            playerScript.jumpForce = 10f;
            villagerScript.speed = 100f;

            // Toggling the 'conversation-mode'
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spacePressed = true;
            }
        } else if (Vector2.Distance(transform.position, playerPosition) > 3 && spacePressed == false)
        {
            characterKit.SetActive(false);
        }
    }
}
