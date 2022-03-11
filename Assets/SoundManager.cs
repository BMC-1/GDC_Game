using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audioSource;
    
    [Header("Clips Available")]
    public AudioClip jumpEffect;

    public void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void JumpEffect()
    {
        audioSource.clip = jumpEffect;
        audioSource.Play();
    }
}
