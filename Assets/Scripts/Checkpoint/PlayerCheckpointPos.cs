using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckpointPos : MonoBehaviour
{
    public static PlayerCheckpointPos instance;
    public CheckpointMaster cm;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointMaster>();
    }

    public void ReturnToLastCheckpoint()
    {
        CharacterMovement.instance.fallDamage = false;
        transform.position = cm.lastCheckpointPos;
    }
}
