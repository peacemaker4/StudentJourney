using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource source;

    [SerializeField] AudioSource deathscene;

    public static BackgroundMusic instance;

    private bool dead = false;

    private void Awake()
    {
        instance = this;

        source = GetComponent<AudioSource>();

    }
    public void Respawn()
    {
        dead = false;
        deathscene.Stop();
        source.Play();
    }
    public void Death()
    {
        if (!dead)
        {
            dead = true;
            Stop();
            deathscene.Play();
        }
    }
    public void PlaySound(AudioClip sound)
    {
        source.clip = sound;
        source.Play();
    }
    public void ChangeVolume(float vol)
    {
        source.volume = vol;
    }
    public void Stop()
    {
        source.Stop();
    }
}
