using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundMusicOnEnter : MonoBehaviour
{
    [SerializeField] AudioClip background;
    [SerializeField] float volume = 0.5f;
    bool isPlaying = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isPlaying)
        {
            BackgroundMusic.instance.PlaySound(background);
            BackgroundMusic.instance.ChangeVolume(volume);
            isPlaying = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isPlaying)
        {
            BackgroundMusic.instance.Stop();
            isPlaying = false;
        }
    }
}
