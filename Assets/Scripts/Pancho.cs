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
    public PlayerMovement playerMovement;
    public GameManager GM;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement =  GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        GM = GameObject.FindWithTag("GM").GetComponent<GameManager>();
    }

    public void QuestionOne()
    {
        dialogueManager.ChangeBox();
        dialogue.sentences.Clear();
        dialogue.sentences.Add("So, would you like to take it?");
        TriggerDialogue();
        dialogueManager.StartShowOptionsCoroutine("Yes!", "No, show me other options");
        dialogueManager.option1.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option2.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option1.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.HideTriangles(); });
        dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.HideTriangles(); });
        dialogueManager.option1.GetComponent<Button>().onClick.AddListener(delegate { SignContract(); });
        if (GM.currentApt == "3C")
        {
            dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { MoveFrom3C(); });
        }
        else if (GM.currentApt == "3A")
        {
            dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { MoveFrom3A(); });
        }
        else
        {
            dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { MoveFrom2B(); });
        }

    }

    public void SignContract()
    {
        dialogueManager.DisplayNextSentence();
        contract.SetActive(true);
    }

    public void MoveFrom3C()
    {
        dialogueManager.ChangeBox();
        dialogueManager.HideAllButtons();
        dialogue.sentences.Clear();
        dialogue.sentences.Add("Okay. Would you like to visit 2B or 3A?");
        TriggerDialogue();
        dialogueManager.StartShowOptionsCoroutine("2B", "3A");
        dialogueManager.ResizeOptionText(600, 600);
        dialogueManager.option1.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option2.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option1.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.HideTriangles(); });
        dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.HideTriangles(); });
        dialogueManager.option1.GetComponent<Button>().onClick.AddListener(delegate { GoTo2B(); });
        dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { GoTo3A(); });
    }

    public void MoveFrom3A()
    {
        dialogueManager.ChangeBox();
        dialogueManager.HideAllButtons();
        dialogue.sentences.Clear();
        dialogue.sentences.Add("Okay. Would you like to visit 2B or 3C?");
        TriggerDialogue();
        dialogueManager.StartShowOptionsCoroutine("2B", "3C");
        dialogueManager.ResizeOptionText(600, 600);
        dialogueManager.option1.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option2.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option1.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.HideTriangles(); });
        dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.HideTriangles(); });
        dialogueManager.option1.GetComponent<Button>().onClick.AddListener(delegate { GoTo2B(); });
        dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { GoTo3C(); });
    }

    public void MoveFrom2B()
    {
        dialogueManager.ChangeBox();
        dialogueManager.HideAllButtons();
        dialogue.sentences.Clear();
        dialogue.sentences.Add("Okay. Would you like to visit 3A or 3C?");
        TriggerDialogue();
        dialogueManager.StartShowOptionsCoroutine("3A", "3C");
        dialogueManager.ResizeOptionText(600, 600);
        dialogueManager.option1.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option2.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.option1.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.HideTriangles(); });
        dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.HideTriangles(); });
        dialogueManager.option1.GetComponent<Button>().onClick.AddListener(delegate { GoTo3A(); });
        dialogueManager.option2.GetComponent<Button>().onClick.AddListener(delegate { GoTo3C(); });
    }

    public void GoTo2B()
    {
        dialogueManager.ChangeBoxBack();
        dialogueManager.DisplayNextSentence();
        
        dialogueManager.HideAllButtons();
        StartCoroutine(GM.FadeToBlack());
        StartCoroutine(GoTo2BCoroutine());
        StartCoroutine(playerMovement.GoTo2B());
    }

    IEnumerator GoTo2BCoroutine()
    {
        yield return new WaitForSeconds(1);
        dialogue.sentences.Clear();
        dialogue.sentences.Add("Welcome to 2B.");
        TriggerDialogue();
        dialogueManager.continueButton.SetActive(true);
    }

    public void GoTo3A()
    {
        dialogueManager.ChangeBoxBack();
        dialogueManager.DisplayNextSentence();
        dialogueManager.HideAllButtons();
        StartCoroutine(GM.FadeToBlack());
        StartCoroutine(GoTo3ACoroutine());
        StartCoroutine(playerMovement.GoTo3A());
    }

    IEnumerator GoTo3ACoroutine()
    {
        yield return new WaitForSeconds(1);
        dialogue.sentences.Clear();
        dialogue.sentences.Add("Welcome to 3A.");
        TriggerDialogue();
        dialogueManager.continueButton.SetActive(true);
    }

    public void GoTo3C()
    {
        dialogueManager.ChangeBoxBack();
        dialogueManager.DisplayNextSentence();
        dialogueManager.HideAllButtons();
        StartCoroutine(GM.FadeToBlack());
        StartCoroutine(GoTo3CCoroutine());
        StartCoroutine(playerMovement.GoTo3C());
    }

    IEnumerator GoTo3CCoroutine()
    {
        yield return new WaitForSeconds(1);
        dialogue.sentences.Clear();
        dialogue.sentences.Add("Welcome to 3C.");
        TriggerDialogue();
        dialogueManager.continueButton.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Front Door")
        {
            if (hasGivenMap == false)
            {
                rb.velocity = new Vector2(0, 0);
                if (GM.currentApt == "3C")
                {
                    animator.SetBool("WalkLeft", false);
                    StartCoroutine(WaitAndWalkRight());
                }
                else if (GM.currentApt == "3A")
                {
                    animator.SetBool("WalkDown", false);
                    StartCoroutine(WaitAndWalkUp());
                }
                else
                {
                    animator.SetBool("WalkRight", false);
                    StartCoroutine(WaitAndWalkLeft());
                }
                givingMap = true;
            }
            else
            {
               
                //StartCoroutine(GameObject.FindWithTag("GM").GetComponent<GameManager>().FadeToBlack());
                gameObject.SetActive(false);

            }
        }
        if (other.tag == "Pancho Start" && givingMap == true)
        {
            if (hasGivenMap == false)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                if (GM.currentApt == "3C")
                {
                    animator.SetBool("WalkRight", false);
                }
                else if (GM.currentApt == "3A")
                {
                    animator.SetBool("WalkUp", false);
                }
                else
                {
                    animator.SetBool("WalkLeft", false);
                }
                rb.velocity = new Vector2(0, 0);
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                dialogue.sentences.Clear();
                dialogue.sentences.Add("Almost forgot! This is for you.");
                TriggerDialogue();
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                StartCoroutine(GM.MapAddedText());
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - .5f, gameObject.transform.position.y, gameObject.transform.position.z);
                animator.enabled = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = givingMapSprite;
                if (GM.currentApt == "2B")
                {
                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                }
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

    IEnumerator WaitAndWalkUp()
    {
        yield return new WaitForSeconds(.75f);
        rb.velocity = new Vector2(0, 1);
        animator.SetBool("WalkUp", true);
    }

    IEnumerator WaitAndWalkLeft()
    {
        yield return new WaitForSeconds(.75f);
        rb.velocity = new Vector2(-1, 0);
        animator.SetBool("WalkLeft", true);
    }
}
