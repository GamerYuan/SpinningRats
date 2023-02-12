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
        string[] controls = new string[4] {
        "Press the 'A' key to turn left and the 'D' key to turn right.", 
        "Pressing both 'A' and 'D' at the same time will boost you forward. Note that dashing consumes rats.",
        "Grow your rat army by keeping everyone well fed, though remember that you can't eat more than your own weight in cheese at once!", 
        "Finally, make sure not to get eaten by cats and try not to knock into the dead bodies of your brethren. Reach 1,000,000 rats to pull the cheese moon towards you and end your rat homelessness.", };

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
