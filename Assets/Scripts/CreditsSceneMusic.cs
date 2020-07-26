using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSceneMusic : MonoBehaviour
{
    static bool audioBegin = false;
    public AudioSource loveMusic;
    public EndScene endSceneScript;

    // Update is called once per frame
    void Update()
    {
        if (endSceneScript.displayHeart)
        {
            if (!audioBegin)
            {
                loveMusic.Play();
                DontDestroyOnLoad(loveMusic);
                audioBegin = true;
            }
        }
    }

    private void FixedUpdate()
    {
        IEnumerator fadingSoundLove = MusicManager.FadeOut(loveMusic, 3000f);

        if (SceneManager.GetActiveScene().name == "Credits")
        {
            StartCoroutine(fadingSoundLove);
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
