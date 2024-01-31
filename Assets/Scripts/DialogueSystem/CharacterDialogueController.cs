using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogueController : MonoBehaviour
{
    private NPCController npc;
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "NPC")
        {
            npc = collision.gameObject.GetComponent<NPCController>();
            if (Input.GetKey(KeyCode.E) || npc.DialogueOnCollision())
            {
                npc.ActivateDialogue();
            }
        }
    }
}
