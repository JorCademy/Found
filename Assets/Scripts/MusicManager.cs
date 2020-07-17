using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    static bool audioBegin = false;
    new public AudioSource audio;
    public GameObject player;
    public GameObject door;

    void Awake()
    {
        if (!audioBegin)
        {
            audio.Play();
            DontDestroyOnLoad(audio);
            audioBegin = true;
        }
    }

    private void Update()
    {
        IEnumerator fadingSound = MusicManager.FadeOut(audio, 60f);

        if (PlayerPrefs.GetInt("Keys", 0) >= 6)
        {
            if (Vector2.Distance(player.transform.position, door.transform.position) < 3)
            {
                StartCoroutine(fadingSound);
            }
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