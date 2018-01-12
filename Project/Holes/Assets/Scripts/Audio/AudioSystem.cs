using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    TRASH,
    PLAYER_HIT
}

[System.Serializable]
public struct NamedAudio
{
    public AudioType audioType;
    public AudioClip audioClip;
}

[RequireComponent(typeof(AudioPlayer))]
public class AudioSystem : MonoBehaviour
{
    public List<NamedAudio> audioClips = null;

    [HideInInspector]
    public AudioPlayer mainAudioSource;
    [HideInInspector]
    public static AudioSystem instance;

    private void Awake()
    {
        if (AudioSystem.instance == null)
            AudioSystem.instance = this;
        else
            Destroy(gameObject);

        mainAudioSource = GetComponent<AudioPlayer>();

        //playGlobalAudio(AudioType.LARRY_MUSIC, true);
    }

    public static void playGlobalAudio(AudioType _type, float _volume, bool _looped = false)
    {
        instance.mainAudioSource.play(getClip(_type), _volume, _looped);
    }

    public static AudioPlayer playLocalAudio(AudioType _type, Vector3 _sourcePosition, float _volume, bool _looped = false)
    {
        if (!hasClip(_type))
            return null;

        GameObject newObject = new GameObject();

        newObject.transform.position = _sourcePosition;

        newObject.name = _type.ToString();

        AudioPlayer newPlayer = newObject.AddComponent<AudioPlayer>();

        newPlayer.play(getClip(_type), _volume, _looped);

        return newPlayer;
    }


    static bool hasClip(AudioType _type)
    {
        foreach (NamedAudio audioClip in AudioSystem.instance.audioClips)
        {
            if (audioClip.audioType == _type)
                return true;
        }

        return false;
    }

    static AudioClip getClip(AudioType _type)
    {
        foreach (NamedAudio audioClip in AudioSystem.instance.audioClips)
        {
            if (audioClip.audioType == _type)
                return audioClip.audioClip;
        }

        return null;
    }
}