using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text nameText1;
    public TMP_Text dialogueText1;
    public GameObject continueButton1;
    public Button option1;
    public Button option2;

    public TMP_Text nameText2;
    public TMP_Text dialogueText2;
    public GameObject continueButton2;

    public Image dialogueDot1;
    public Image dialogueDot2;
    public Sprite continueDialogue;
    public Sprite endDialogue;
    public GameObject dialogueBox1;
    public GameObject dialogueBox2;

    public Animator animator;

    public GameObject dialogueBox;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject continueButton;
    public Image dialogueDot;

    public Queue<string> sentences = new Queue<string>();

    private bool doneTyping = false;

    public GameObject option1Triangle;
    public GameObject option2Triangle;

    void Start()
    {
        nameText = nameText1;
        dialogueText = dialogueText1;
        continueButton = continueButton1;
        dialogueDot = dialogueDot1;
        dialogueBox = dialogueBox1;
    }

    void Update()
    {
        dialogueBox2.GetComponent<RectTransform>().localPosition = dialogueBox1.GetComponent<RectTransform>().localPosition;
    }

    public void HideTriangles()
    {
        option1Triangle.SetActive(false);
        option2Triangle.SetActive(false);
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

    public void ChangeBox()
    {
        dialogueBox = dialogueBox2;
        dialogueBox1.SetActive(false);
        dialogueBox2.SetActive(true);
        nameText = nameText2;
        dialogueText = dialogueText2;
        continueButton = continueButton2;
        dialogueDot = dialogueDot2;
    }

    public void ChangeBoxBack()
    {
        dialogueBox = dialogueBox1;
        dialogueBox2.SetActive(false);
        dialogueBox1.SetActive(true);
        nameText = nameText1;
        dialogueText = dialogueText1;
        continueButton = continueButton1;
        dialogueDot = dialogueDot1;
    }

    public IEnumerator ShowOptions(string option1Text, string option2Text)
    {

        continueButton.SetActive(false);
        yield return new WaitUntil(TextComplete);

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
        //option1.gameObject.GetComponentsInChildren<TMP_Text>()[0].fontSize = size1;
        //option2.gameObject.GetComponentsInChildren<TMP_Text>()[0].fontSize = size2;
    }
    
   
}
