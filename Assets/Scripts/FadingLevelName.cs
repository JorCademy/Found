using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingLevelName : MonoBehaviour
{
    public string levelName;
    private bool startFading;
    private Animator fadingTextAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // Getting and disabling the animator
        fadingTextAnimator = GetComponent<Animator>();
        fadingTextAnimator.enabled = false;

        // Making sure that the animator won't be enabled yet
        startFading = false;

        // Start the timer
        StartCoroutine(StartFading());
    }

    // Update is called once per frame
    void Update()
    {
        // Setting the correct levelName
        GetComponent<Text>().text = levelName;

        // Starting the animation
        if (startFading)
        {
            fadingTextAnimator.enabled = true;
        }
    }

    // Waiting one second before starting the fading animation
    IEnumerator StartFading()
    {
        yield return new WaitForSeconds(1);

        startFading = true;
    }
}
