using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraSmooth : MonoBehaviour
{
    [SerializeField] float smooth = 1f;
    [SerializeField] GameObject camera;
    private CameraFollow follow;
    bool isInside = false;

    private void Awake()
    {
        follow = camera.gameObject.GetComponent<CameraFollow>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isInside)
        {
            follow.ChangeSmooth(smooth);
            isInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isInside)
        {
            follow.ChangeSmooth(10);
            isInside = false;
        }
    }
}
