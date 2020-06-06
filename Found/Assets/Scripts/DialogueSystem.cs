using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    // Declaring needed variables
    public Text dialogueText;
    public Canvas dialogueCanvas;
    public string[] dialogues;
    public GameObject player;
    private Vector2 playerPosition;
    private Player playerScript;
    private string dialogueDisplayed;
    private bool spacePressed;
    private Villagers villagerScript;
    private int iterator;
    
    // Start is called before the first frame update
    void Start()
    {
        iterator = 0;

        spacePressed = false;
        
        dialogueCanvas.enabled = false;
        
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        
        villagerScript = this.GetComponent<Villagers>();
    }

    // Update is called once per frame
    void Update()
    {
        // Determining the player position
        playerPosition = player.transform.position;

        // Making sure the text is displayed
        dialogueText.text = dialogueDisplayed;

        // Checking when space is pressed for starting conversation
        if (spacePressed == true)
        {
            // Making sure that the player sees the dialogues
            dialogueCanvas.enabled = true;

            // Making sure that the characters can't move during the conversation
            playerScript.playerSpeed = 0;
            playerScript.jumpForce = 0;
            villagerScript.speed = 0;

            // Looping through the dialogues when space is pressed
            while (true)
            {
                if (iterator < dialogues.Length)
                {
                    dialogueDisplayed = this.gameObject.name + " - " + dialogues[iterator].ToString();

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        iterator++; 
                    }
                } else
                {
                    spacePressed = false;
                }

                break;
            }
        }

        // Making sure that the text disappears when there is no conversation anymore
        if (Vector2.Distance(transform.position, playerPosition) < 3 && spacePressed == false)
        {
            iterator = 0;

            // Initializing the text the player sees when it is near the NPC
            dialogueDisplayed = "Press Space to talk.";

            dialogueCanvas.enabled = true;

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
            dialogueCanvas.enabled = false;
        }
    }
}
