using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject continueButton;
    public Button option1;
    public Button option2;

    public Image dialogueDot;
    public Sprite continueDialogue;
    public Sprite endDialogue;

    public Animator animator;

    public Queue<string> sentences = new Queue<string>();

    private bool doneTyping = false;

    void Start()
    {
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count > 1)
        {
            dialogueDot.sprite = continueDialogue;
        }
        else
        {
            dialogueDot.sprite = endDialogue;
        }
        dialogueDot.SetNativeSize();
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        doneTyping = false;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.05f);
        }
        doneTyping = true;
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    public void StartShowOptionsCoroutine(string option1Text, string option2Text)
    {
        StartCoroutine(ShowOptions(option1Text, option2Text));
    }

    public IEnumerator ShowOptions(string option1Text, string option2Text)
    {
        yield return new WaitUntil(TextComplete);

        continueButton.SetActive(false);
        option1.gameObject.SetActive(true);
        option2.gameObject.SetActive(true);

        option1.gameObject.GetComponentsInChildren<TMP_Text>()[0].text = option1Text;
        option2.gameObject.GetComponentsInChildren<TMP_Text>()[0].text = option2Text;

        yield return null;
    }

    public void HideOptions()
    {
        continueButton.SetActive(true);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
    }

    public void HideAllButtons()
    {
        continueButton.SetActive(false);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
    }

    public bool TextComplete()
    {
        return doneTyping;
    }

    public void ResizeOptionText(int size1, int size2)
    {
        option1.gameObject.GetComponentsInChildren<TMP_Text>()[0].fontSize = size1;
        option2.gameObject.GetComponentsInChildren<TMP_Text>()[0].fontSize = size2;
    }
    
}
