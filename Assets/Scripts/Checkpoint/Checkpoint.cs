using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    public GameObject checkpointParticle;
    public GameObject text;
    public GameObject checkpoint_light;
    private CheckpointMaster cm;
    [SerializeField] AudioSource sound;

    private bool effectActivated;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointMaster>();
    }
    void Update()
    {
        if (cm.lastCheckpointPos != (Vector2)transform.position)
        {
            animator.SetBool("GetCheckpoint", false);
            text.SetActive(false);
            checkpoint_light.SetActive(false);
            effectActivated = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cm.lastCheckpointPos = transform.position;
            animator.SetBool("GetCheckpoint", true);
            if (effectActivated == false)
            {
                sound.Play();
                text.SetActive(true);
                checkpoint_light.SetActive(true);
                checkpointParticle.SetActive(true);
                Instantiate(checkpointParticle, transform.position, checkpointParticle.transform.rotation);
                effectActivated = true;
            }
        }
    }
}
