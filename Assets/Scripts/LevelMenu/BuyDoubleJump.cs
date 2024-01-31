using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDoubleJump : MonoBehaviour
{
    [SerializeField] GameObject newNPCDialogue;
    [SerializeField] GameObject buyedSign;
    [SerializeField] AudioSource sound;
    private bool buyed;
    [SerializeField] int cost = 30;
    [SerializeField] int jumpAmount = 2;
    private void Awake()
    {
        buyedSign.SetActive(false);
        newNPCDialogue.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.B) && CurrencySystem.instance.EnoughCurrency(cost) && !buyed)
            {
                CurrencySystem.instance.Use(cost);
                CharacterMovement.instance.ChangeJumpAmount(jumpAmount);
                buyedSign.SetActive(true);
                sound.Play();
                buyed = true;
                gameObject.SetActive(false);
                newNPCDialogue.SetActive(true);
            }
        }
        
        
    }
}
