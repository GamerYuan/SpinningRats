using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;
public class DialogueTrigger : MonoBehaviour
{
    private Dialogue dialogue = new Dialogue();
    private DialogueManager dialogueManager;
    private bool isOpen = false;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        string[] controls = new string[2] {
        "Press the 'A' key to turn left and the 'D' key to turn right.", 
        "Pressing both 'A' and 'D' at the same time will boost you forward. Note that dashing consumes rats.",
        "You can only eat cheese that is smaller than you. Bumping into asteroids larger than you will damage you.", 
        "Finally, make sure not to get eaten by cats!", };

        dialogue.setSentences(controls);
        dialogue.setName("(=^-w-^=)");
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue() {
        if (!isOpen) {
            dialogueManager.StartDialogue(dialogue);
            isOpen = true;
        } else {
            dialogueManager.EndDialogue();
            isOpen = false;
        }
    }
}
