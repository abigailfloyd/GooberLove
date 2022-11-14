using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pancho : NPC
{
    public void QuestionOne()
    {
        dialogue.sentences.Clear();
        dialogue.sentences.Add("So, would you like to take it?");
        TriggerDialogue();
        dialogueManager.StartShowOptionsCoroutine("Yes!", "No, show me other options");
        dialogueManager.option1.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option2.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option1.GetComponent<Button>().onClick.AddListener(delegate { Question1Option1(); });
        dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { Question1Option2(); });
    }

    public void Question1Option1()
    {
        // give player contract to sign
    }

    public void Question1Option2()
    {
        dialogueManager.HideAllButtons();
        dialogue.sentences.Clear();
        dialogue.sentences.Add("Okay. Would you like to visit 2B or 3A?");
        TriggerDialogue();
        dialogueManager.StartShowOptionsCoroutine("2B", "3A");
        dialogueManager.ResizeOptionText(600, 600);
        dialogueManager.option1.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option2.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option1.GetComponent<Button>().onClick.AddListener(delegate { Question2Option1(); });
        dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { Question2Option2(); });
    }

    public void Question2Option1()
    {
        // transport to 2B
    }

    public void Question2Option2()
    {
        // transport to 3A
    }
}
