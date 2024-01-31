using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            CurrencySystem.instance.Gain(1);
            sound.Play();
            Destroy(collision.gameObject);
        }
        
    }
}
