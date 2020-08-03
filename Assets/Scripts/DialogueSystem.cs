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
    private NpcMovement npcScript;
    private int iterator;
    private bool readyForLevel;
    public string nextLevelName;
    private int amountOfKeys;
    public string succeededLevelMessage;

    // Checking whether or not the player has played certain levels
    private string playedLevelCheckName;

    // Start is called before the first frame update
    void Start()
    {
        iterator = 0;

        spacePressed = false;
        
        characterKit.SetActive(false);
        
        playerScript = player.GetComponent<Player>();
        
        npcScript = GetComponent<NpcMovement>();

        readyForLevel = false;

        playedLevelCheckName = "Played" + gameObject.name + "Level";
    }

    // Update is called once per frame
    void Update()
    {
        // Receiving the amount of keys stored in memory
        amountOfKeys = PlayerPrefs.GetInt("Keys", 0);

        // Determining the player position
        playerPosition = player.transform.position;

        // Making sure the text is displayed
        if (PlayerPrefs.GetInt(playedLevelCheckName, 0) == 0)
        {
            dialogueText.text = dialogueDisplayed;
        } else
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
            } else
            {
                characterKit.SetActive(false);
            }
        }

        if (spacePressed == true && PlayerPrefs.GetInt(playedLevelCheckName, 0) == 0 && gameObject.name != "Secret Door")
        {
            // Making sure that the player sees the dialogues
            characterKit.SetActive(true);

            // Making sure that the characters can't move during the conversation
            playerScript.playerSpeed = 0;
            playerScript.jumpForce = 0;
            npcScript.npcSpeed = 0;

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
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(transform.position, playerPosition) < 3 && PlayerPrefs.GetInt(playedLevelCheckName, 0) == 0)
        {
            playerScript.nextLevel = "Scenes/" + nextLevelName;
            playerScript.fadeToNextLevel = true;
        }

        if (PlayerPrefs.GetInt(playedLevelCheckName, 0) == 1)
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
            if (PlayerPrefs.GetInt(playedLevelCheckName, 0) == 0)
            {
                if (readyForLevel == false)
                {
                    dialogueDisplayed = "Press Space to talk.";
                }
                else
                {
                    if (gameObject.name == "Mayor")
                    {
                        dialogueDisplayed = "Press Space to talk.\n\nPress 'E' to play the " + gameObject.name + "'s level.";
                    }
                    else
                    {
                        dialogueDisplayed = "Press Space to talk.\n\nPress 'E' to play " + gameObject.name + "'s level.";
                    }
                }
            }

            characterKit.SetActive(true);

            // Making sure that the player and NPC can move (again)
            playerScript.playerSpeed = 10;
            playerScript.jumpForce = 10f;
            npcScript.npcSpeed = 3f;

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
