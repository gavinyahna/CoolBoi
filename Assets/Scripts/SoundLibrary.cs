using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundLibrary : MonoBehaviour
{

    public AudioClip[] sounds;

    Dictionary<string, AudioClip> groupDictionary = new Dictionary<string, AudioClip>();

    void Awake()
    {
        foreach (AudioClip sound in sounds)
        {
            groupDictionary.Add(sound.name, sound);
        }
    }

    public AudioClip GetClipFromName(string name)
    {
        if (groupDictionary.ContainsKey(name))
        {
            AudioClip sound = groupDictionary[name];
            return sound;
        }
        return null;
    }
}