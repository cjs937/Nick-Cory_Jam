using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource audioSource;
    bool isLooped = true;
    bool fading;
    float fadeTime;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void play(AudioClip _audio, float _volume, bool _looped)
    {
        audioSource.clip = _audio;

        audioSource.volume = _volume;

        audioSource.loop = isLooped = _looped;

        audioSource.Play();
    }


    // Update is called once per frame
    void Update ()
    {
        if (!isLooped && !audioSource.isPlaying)
            Destroy(gameObject);

        if (fading)
            fadeOut();
	}

    public void startFade(float _fadeTime)
    {
        fading = true;

        fadeTime = _fadeTime;
    }

    public void fadeOut()
    {
        audioSource.volume -= Time.deltaTime * fadeTime;

        if (audioSource.volume <= 0)
        {
            audioSource.Stop();

            fading = false;
        }
    }
}
