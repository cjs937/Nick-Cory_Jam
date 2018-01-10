using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DestroyOnAudioStop : MonoBehaviour
{
    AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();

        if (source == null)
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
            Destroy(gameObject);
    }
}
