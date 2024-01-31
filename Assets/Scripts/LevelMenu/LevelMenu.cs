using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public GameObject menuscreen;
    private bool active;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!active)
            {
                menuscreen.SetActive(true);
                active = true;
                if (CharacterMovement.instance != null)
                    CharacterMovement.instance.DontMove(true);
            }
            else
            {
                menuscreen.SetActive(false);
                active = false;
                if (CharacterMovement.instance != null)
                    CharacterMovement.instance.DontMove(false);
            }
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
