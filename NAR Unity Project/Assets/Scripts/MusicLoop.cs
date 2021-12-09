using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioClip menu;
    private AudioSource Audio;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Audio.clip = menu;
        Audio.loop = true;
        Audio.Play();
    }
}
