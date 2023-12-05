using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource SFXAudioSource;

    [Header("Music")]
    public AudioClip gameMusic;
    public AudioClip menuMusic;

    [Header("SFX")]
    public AudioClip createArea;
    public AudioClip fireProjectile;
    public AudioClip killEnemy;
    public AudioClip levelUp;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(menuMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        SFXAudioSource.PlayOneShot(clip);
    }


}
