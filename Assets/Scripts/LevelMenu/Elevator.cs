using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;

    [SerializeField] public float speed;

    //[SerializeField] private Transform childTransform;
    [SerializeField] private Transform transformB;

    bool isMoving = false;
    bool reached = false;

    [SerializeField] private GameObject blocker;

    private void Start()
    {
        posA = gameObject.transform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            if (reached)
            {
                ChangeDestination();
            }
            isMoving = true;
            blocker.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isMoving = false;
        }
    }

    private void Update()
    {
        if (isMoving)
            Move();
    }

    private void Move()
    {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, nextPos, speed * Time.deltaTime);
        reached = false;
        if (Vector3.Distance(gameObject.transform.localPosition, nextPos) <= 0.1)
        {
            blocker.SetActive(true);
            reached = true;
        }
    }

    private void ChangeDestination()
    {
        nextPos = (nextPos != posA) ? posA : posB;
    }
}
