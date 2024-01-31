using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfTheGame : MonoBehaviour
{
    public GameObject thendScreen;
    [SerializeField] AudioClip endmusic;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterMovement.instance.DontMove(true);
            thendScreen.SetActive(true);
            BackgroundMusic.instance.ChangeVolume(0.3f);
            BackgroundMusic.instance.PlaySound(endmusic);
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
