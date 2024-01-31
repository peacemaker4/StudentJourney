using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private IEnumerator dialogueSeq;
        [SerializeField] private bool allowToDialogueFinished;
        private bool dialogueFinished;
        private void OnEnable()
        {
            if(CharacterMovement.instance != null)
                CharacterMovement.instance.DontMove(true);

            dialogueSeq = dialogueSequence();
            StartCoroutine(dialogueSeq);
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.Escape))
            {
                Deactivate();
                gameObject.SetActive(false);
                StopCoroutine(dialogueSeq);
                if (CharacterMovement.instance != null)
                    if(Input.GetKey(KeyCode.R))
                        CharacterMovement.instance.DontMove(false);
            }
        }
        private IEnumerator dialogueSequence()
        {
            if (!dialogueFinished)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Deactivate();
                    Transform child = transform.GetChild(i);
                    child.gameObject.SetActive(true);
                    yield return new WaitUntil(() => child.GetComponent<DialogueLine>().finished);
                }
            }
            else
            {
                int index = transform.childCount - 1;
                Deactivate();
                transform.GetChild(index).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(index).GetComponent<DialogueLine>().finished);
            }

            if (allowToDialogueFinished)
            {
                dialogueFinished = true;
            }
            gameObject.SetActive(false);
            if (CharacterMovement.instance != null)
                CharacterMovement.instance.DontMove(false);
        }
        private void Deactivate()
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}