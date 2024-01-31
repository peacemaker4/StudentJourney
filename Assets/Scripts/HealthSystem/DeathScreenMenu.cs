using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenMenu : MonoBehaviour
{
    public static DeathScreenMenu instance;
    public GameObject deathScreen;
    public GameObject resurrectScreen;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        deathScreen.SetActive(false);
        resurrectScreen.SetActive(false);
    }
    public void SetSceneActive()
    {
        deathScreen.SetActive(true);
        resurrectScreen.SetActive(false);
        BackgroundMusic.instance.Death();
    }
    public void SetSceneUnActive()
    {
        deathScreen.SetActive(false);
        resurrectScreen.SetActive(true);
    }
    public void RespawnButton()
    {
        BackgroundMusic.instance.Respawn();
        HealthSystem.instance.Respawn();
        SetSceneUnActive();
    }
    

}
