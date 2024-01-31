using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D platformEffector2D;
    public float waitTime;

    private bool playerOnPlatform;

    private void Start()
    {
        platformEffector2D = GetComponent<PlatformEffector2D>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if(waitTime <= 0)
            {
                platformEffector2D.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            platformEffector2D.rotationalOffset = 0f;
        }
        
    }
    
}
