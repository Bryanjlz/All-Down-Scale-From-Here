using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TMP_Text dialogueText;

    public Animator animator;
    public GameObject dialogueBox;

    private bool textStillAnimating;
    private string currentSentence;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Conversation!");

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        displayNextSentence();
        dialogueBox.SetActive(true);
        animator.SetBool("isOpen", true);
    }

    public void displayNextSentence ()
    {
        StopAllCoroutines();
        if (textStillAnimating)
        {
            dialogueText.SetText(currentSentence);
            textStillAnimating = false;
        } else
        {
            if (sentences.Count <= 0)
            {
                endDialogue();
                return;
            }

            currentSentence = sentences.Dequeue();
            textStillAnimating = true;
            StartCoroutine(typeSentence(currentSentence));
        }

        Debug.Log(currentSentence);
    }

    IEnumerator typeSentence(string sentence)
    {
        dialogueText.SetText("");
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        textStillAnimating = false;
    }

    public void endDialogue()
    {
        Debug.Log("Ending Conversation");
        dialogueText.SetText("");
        animator.SetBool("isOpen", false);
        dialogueBox.SetActive(false);
    }
}
