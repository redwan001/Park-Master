using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    public AudioClip pickupSound;
    public AudioClip winFXSound;
    public AudioClip LoseFXSound;
    public AudioClip policeSireSound;
    AudioSource audio;

    // Start is called before the first frame update

    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    void Start()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    public static SoundManager sharedManager()
    {
        return instance;
    }

    // Update is called once per frame
    public void PickUpLuggage()
    {
        audio.clip = pickupSound;
        audio.Play();
    }

    public void PlayWinFX()
    {
        audio.clip = winFXSound;
        audio.Play();
    }

    public void PlayLoseFX()
    {
        audio.clip = LoseFXSound;
        audio.Play();
    }
    public void SirenSound()
    {
        audio.clip = policeSireSound;
        audio.Play();
    }
}
