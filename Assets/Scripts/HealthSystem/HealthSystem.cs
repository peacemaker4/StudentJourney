using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public TMP_Text textHealth;
    public int defaultHealth = 100;
    [SerializeField] private int _health;
    Animator animator;
    [SerializeField] AudioSource hurtSound;
    [SerializeField] GameObject damagescreen;

    public static HealthSystem instance;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Init();
        instance = this;
    }

    public void Init()
    {
        _health = defaultHealth;
        UpdateUI();
    }
    public void Heal(int val)
    {
        _health += val;
        UpdateUI();
    }
    
    public bool Damage(int val)
    {
        damagescreen.SetActive(false);
        if (EnoughHealth(val))
        {
            _health -= val;
            hurtSound.Play();
            CharacterMovement.instance.DamageEffect();
            damagescreen.SetActive(true);
            UpdateUI();
            return true;
        }
        else
        {
            _health = 0;
            DeathCheck();
        }
        return false;
    }
    

    public bool EnoughHealth(int val)
    {
        if (val <= _health)
            return true;
        else
            return false;
    }
    void DeathCheck()
    {
        if (_health <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        gameObject.SetActive(false);
        DeathScreenMenu.instance.SetSceneActive();
    }
    public void Respawn()
    {
        gameObject.SetActive(true);
        PlayerCheckpointPos.instance.ReturnToLastCheckpoint();
        _health = defaultHealth;
        
        UpdateUI();
    }
    void UpdateUI()
    {
        textHealth.text = _health.ToString();

        if(_health == 100 && _health >= 90)
        {
            animator.SetFloat("heart_status", 4);
        }
        else if (_health < 90 && _health >= 70)
        {
            animator.SetFloat("heart_status", 3);
        }
        else if (_health < 70 && _health >= 40)
        {
            animator.SetFloat("heart_status", 2);
        }
        else if (_health < 40 && _health >= 1)
        {
            animator.SetFloat("heart_status", 1);
        }
        else if (_health == 0)
        {
            animator.SetFloat("heart_status", 0);
        }
    }

}
