using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pancho : NPC
{
   
    public GameObject contract;
    public Animator animator;
    public Rigidbody2D rb;
    bool hasGivenMap = false;
    bool givingMap = false;
    public Sprite givingMapSprite;
    public Sprite originalSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.constraints = RigidbodyConstraints2D.FreezePosition;
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

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
        dialogueManager.DisplayNextSentence();
        contract.SetActive(true);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Front Door")
        {
            if (hasGivenMap == false)
            {
                rb.velocity = new Vector2(0, 0);
                animator.SetBool("WalkLeft", false);
                StartCoroutine(WaitAndWalkRight());
                givingMap = true;
            }
            else
            {
                dialogueManager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
                dialogueManager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.DisplayNextSentence(); });
                //StartCoroutine(GameObject.FindWithTag("GM").GetComponent<GameManager>().FadeToBlack());
                gameObject.SetActive(false);

            }
        }
        if (other.tag == "Pancho Start" && givingMap == true)
        {
            if (hasGivenMap == false)
            {
                animator.SetBool("WalkRight", false);
                rb.velocity = new Vector2(0, 0);
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                dialogue.sentences.Clear();
                dialogue.sentences.Add("Almost forgot! This is for you.");
                TriggerDialogue();
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - .5f, gameObject.transform.position.y, gameObject.transform.position.z);
                animator.enabled = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = givingMapSprite;
                hasGivenMap = true;
            }
            
            
        }
    }



    IEnumerator WaitAndWalkRight()
    {
        yield return new WaitForSeconds(.75f);
        rb.velocity = new Vector2(1, 0);
        animator.SetBool("WalkRight", true);
    }
}
