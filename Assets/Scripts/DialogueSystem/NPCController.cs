using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private bool _onCollision = false;

    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
        _onCollision = false;
    }
    public bool DialogueOnCollision()
    {
        return _onCollision;
    }
    public bool DialogueActive()
    {
        return dialogue.activeInHierarchy;
    }

}
