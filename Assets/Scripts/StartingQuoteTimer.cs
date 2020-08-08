using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingQuoteTimer : MonoBehaviour
{
    public Animator quoteAnimator;
    private bool makeVisible;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        makeVisible = false;
        quoteAnimator = GetComponent<Animator>();
        StartCoroutine(StartingQuote());
    }

    // Update is called once per frame
    void Update()
    {
        if (makeVisible)
        {
            quoteAnimator.enabled = true;
        }
    }

    IEnumerator StartingQuote()
    {
        yield return new WaitForSeconds(2);

        makeVisible = true;

        yield return new WaitForSeconds(10);

        SceneManager.LoadScene("Scenes/Center");
    }
}
