using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRigidbodyToObject : MonoBehaviour
{
    private bool added = false;
    [SerializeField] GameObject gameobject;
    [SerializeField] float objectMass = 10f;
    [SerializeField] AudioSource sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (added == false)
        {
            if (collision.CompareTag("Player"))
            {
                gameobject.AddComponent<Rigidbody2D>();
                gameobject.GetComponent<Rigidbody2D>().mass = objectMass;
                gameobject.GetComponent<Rigidbody2D>().gravityScale = 10;
                sound.Play();
                added = true;
            }
        }
    }
}
