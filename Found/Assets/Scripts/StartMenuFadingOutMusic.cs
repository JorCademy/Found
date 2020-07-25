using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuFadingOutMusic : MonoBehaviour
{
    new public AudioSource audio;

    // Update is called once per frame
    void Update()
    {
        IEnumerator fadingSound = MusicManager.FadeOut(audio, 3f);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(fadingSound);
        }
    }

    public static IEnumerator FadeOut(AudioSource audio, float FadeTime)
    {
        float startVolume = audio.volume;

        while (audio.volume > 0)
        {
            audio.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audio.Stop();
        audio.volume = startVolume;
    }
}
