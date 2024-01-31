using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyNextScene : MonoBehaviour
{
    public AudioClip sound;
    private bool sounded;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!sounded)
            {
                AudioSource.PlayClipAtPoint(sound, Vector3.zero);
                Invoke("LoadScene", 0.5f);
                sounded = true;
            }
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
