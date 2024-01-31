using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAlarm : MonoBehaviour
{
    [SerializeField] AudioSource alarm;
    private bool active = true;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>(); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(active == true) { 
            if (collision.CompareTag("Player"))
            {
                alarm.Stop();
                active = false;
                animator.SetBool("active", false);
            }
        }
    }
}
