using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText;
    public Canvas dialogueCanvas;
    public string[] dialogues;
    public GameObject player;
    private Vector2 playerPosition;
    private Player playerScript;
    private string dialogueDisplayed;
    private bool spacePressed;
    private Villagers villagerScript;

    // Start is called before the first frame update
    void Start()
    {
        spacePressed = false;
        dialogueCanvas.enabled = false;
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        villagerScript = this.GetComponent<Villagers>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;

        dialogueText.text = dialogueDisplayed;

        if (spacePressed == true)
        {
            dialogueCanvas.enabled = true;

            dialogueDisplayed = "Let me talk!!!";
            playerScript.playerSpeed = 0;
            playerScript.jumpForce = 0;
            villagerScript.speed = 0;

            if (Input.GetKeyDown(KeyCode.E))
            {
                spacePressed = false;
            }
        }

        if (Vector2.Distance(transform.position, playerPosition) < 3 && spacePressed == false)
        {
            dialogueDisplayed = "Press Space to talk.";

            dialogueCanvas.enabled = true;

            playerScript.playerSpeed = 10;
            playerScript.jumpForce = 10f;
            villagerScript.speed = 100f;

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
