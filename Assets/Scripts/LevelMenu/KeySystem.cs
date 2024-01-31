using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySystem : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    [SerializeField] GameObject key;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            key.SetActive(true);
            sound.Play();
            Destroy(collision.gameObject);
        }
    }
}
