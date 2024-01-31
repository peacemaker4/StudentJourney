using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    [SerializeField] private float destroyAfter = 0.1f;
    [SerializeField] private GameObject particle;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            particle.SetActive(true);
            Destroy(other.gameObject, destroyAfter);
        }
    }
}
