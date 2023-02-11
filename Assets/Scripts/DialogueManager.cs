using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private Queue<string> sentences;
    private bool dialogueOpen = false;
    private bool isTyping = false;
    private string sentence;

    void Start()
    {
        sentences = new Queue<string>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    void Update()
    {
        if (dialogueOpen)
        {
            Time.timeScale = 0f;
        }
    }

    public void StartDialogue(Dialogue dialogue) {
        animator.SetBool("isOpen", true);
        
        Time.timeScale = 0f;

        dialogueOpen = true;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.getSentences())
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0 && !isTyping) {
            EndDialogue();
            return;
        }
        if (!isTyping)
        {
            sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        } else
        {
            FastTypeSentence(sentence);
        }

    }

    void FastTypeSentence(string sentence)
    {
        isTyping = false;
        dialogueText.text = sentence;
    }

    IEnumerator TypeSentence (string sentence) {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            if (dialogueText.text == sentence)
            {
                break;
            }
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.02f);
        }
        isTyping = false;
    }

    public void EndDialogue() {
        animator.SetBool("isOpen", false);
        dialogueOpen = false;
        Time.timeScale = 1f;
    }
}
