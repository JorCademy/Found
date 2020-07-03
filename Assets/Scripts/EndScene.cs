using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public GameObject player;
    public bool startTimer;
    public bool displayHeart;
    public bool loveCubeMovement;
    public bool playerMovement;
    public bool displayTitle;
    public bool fadeToNextLevelPlayer;
    public bool smallPause;
    public Image heartImage;
    public Canvas pauseMenuCanvas;

    // public Image heart;
    public Text foundText;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = false;
        displayHeart = false;
        loveCubeMovement = false;
        playerMovement = false;
        displayTitle = false;
        smallPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 34)
        {
            startTimer = true;
        }

        if (startTimer)
        {
            pauseMenuCanvas.enabled = false;
            StartCoroutine(EndGameTimer());
        }

        if (displayHeart)
        {
            heartImage.GetComponent<Animator>().enabled = true;
        }

        if (displayTitle == true)
        {
            foundText.GetComponent<Animator>().enabled = true;
        }
    }

    IEnumerator EndGameTimer()
    {
        yield return new WaitForSeconds(4);

        displayHeart = true;

        yield return new WaitForSeconds(6);

        loveCubeMovement = true;

        yield return new WaitForSeconds(0.25f);

        playerMovement = true;

        yield return new WaitForSeconds(3);

        displayTitle = true;

        yield return new WaitForSeconds(6);

        fadeToNextLevelPlayer = true;
    }
}
