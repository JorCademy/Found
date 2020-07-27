using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour
{
    public Text madeByText;
    public Text musicUsedText;
    public Text thankForPlayingText;
    public bool displayMadeByText;
    public bool displayMusicUsedText;
    public bool displayThankForPlayingText;
    public bool switchToStartMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        StartCoroutine(StartCredits());

        displayMadeByText = false;
        displayMusicUsedText = false;
        displayThankForPlayingText = false;
        switchToStartMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (displayMadeByText)
        {
            madeByText.GetComponent<Animator>().enabled = true;
        }

        if (displayMusicUsedText)
        {
            musicUsedText.GetComponent<Animator>().enabled = true;
        }

        if (displayThankForPlayingText)
        {
            thankForPlayingText.GetComponent<Animator>().enabled = true;
        }

        if (switchToStartMenu)
        {
            SceneManager.LoadScene("Scenes/StartingMenu");
        }
    }

    IEnumerator StartCredits()
    {
        yield return new WaitForSeconds(2);

        displayMadeByText = true;

        yield return new WaitForSeconds(6);

        displayMusicUsedText = true;

        yield return new WaitForSeconds(6);

        displayThankForPlayingText = true;

        yield return new WaitForSeconds(6);

        switchToStartMenu = true;
    }
}
