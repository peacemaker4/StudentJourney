using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectOnCollision : MonoBehaviour
{
    private bool active = false;
    [SerializeField] GameObject activeobject;
    [SerializeField] AudioSource sound;
    [SerializeField] bool activate = true;
    void Start()
    {
        if(activate)
            activeobject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (active == false)
        {
            if (collision.CompareTag("Player"))
            {
                if(activate)
                    activeobject.SetActive(true);
                else
                    activeobject.SetActive(false);
                sound.Play();
                active = true;
            }
        }
    }
}
