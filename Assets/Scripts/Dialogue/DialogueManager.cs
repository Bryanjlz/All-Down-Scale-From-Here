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

    public AudioManager audioManager;

    public Image canvasBackground;

    public GameObject desktop;

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
        canvasBackground.color = new Color(0.4f, 0.4f, 0.4f);

        // deal with colliders on desktop
        foreach (var c in desktop.GetComponentsInChildren<BoxCollider2D>())
        {
            c.enabled = false;
        }

        animator.SetBool("isOpen", true);
    }

    public void displayNextSentence ()
    {
        audioManager.Play("click");
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
            audioManager.Play("clickdeep");
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
        textStillAnimating = false;
    }

    public void endDialogue()
    {
        Debug.Log("Ending Conversation");
        dialogueText.SetText("");
        animator.SetBool("isOpen", false);
        canvasBackground.color = new Color(1, 1, 1);

        // reenable colliders on desktop
        foreach (var c in desktop.GetComponentsInChildren<BoxCollider2D>())
        {
            c.enabled = true;
        }

        dialogueBox.SetActive(false);
    }
}
