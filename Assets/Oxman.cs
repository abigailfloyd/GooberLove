using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxman : NPC
{
    public PlayerMovement playerMovement;
    public Animator animator;
    public bool animStarted = false;
    public Sprite defaultSprite;
    private GameManager GM;
    public Rigidbody2D rb;


    void Start()
    {
        GM = GameObject.FindWithTag("GM").GetComponent<GameManager>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        animator.enabled = false;
        player = GameObject.FindWithTag("Player");

    }

    void Update()
    {
        base.Update();
        if (GameObject.FindWithTag("Dialogue Manager").GetComponent<DialogueManager>().sentences.Count == 0 && !animStarted)
        {
            animStarted = true;
            animator.enabled = true;
            if (GM.currentApt == "Elevator")
            {
                animator.SetBool("WalkUp", true);
                rb.velocity = new Vector2(0, .75f);
            }
            else if (GM.currentApt == "StairsUpper")
            {
                animator.SetBool("WalkLeft", true);
                rb.velocity = new Vector2(-.75f, 0);
            }
            else if (GM.currentApt == "StairsLower")
            {
                animator.SetBool("WalkRight", true);
                rb.velocity = new Vector2(.75f, 0);
            }
            
            
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            rb.constraints = RigidbodyConstraints2D.None;
            playerMovement.oxmanAnimStarted = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Elevator door")
        {
            animator.SetBool("WalkUp", false);
            gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
            gameObject.transform.SetParent(GM.lobby.transform, true);
        }
        if (other.tag == "Turn up")
        {
            WalkUp();
        }
        if (other.tag == "Turn down")
        {
            WalkDown();
        }
        if (other.tag == "Turn left")
        {
            WalkLeft();
        }
        if (other.tag == "Turn right")
        {
            WalkRight();
        }
        if (other.tag == "Front Door")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.SetParent(GM.outsideApt.transform, true);
        }
        if (other.tag == "Turn down right")
        {
            animator.SetBool("WalkRight", true);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkDown", false);
            animator.SetBool("WalkUp", false);
            rb.velocity = new Vector2(1, -.25f); ;
        }
        if (other.tag == "Stairs to first floor")
        {
            animator.SetBool("WalkRight", false);
            gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
            gameObject.transform.SetParent(GM.lobby.transform, true);
        }
        if (other.tag == "End of walkway")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
            gameObject.transform.SetParent(GM.townCenter.transform, true);
        }
        if (other.tag == "Post office")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
            gameObject.transform.SetParent(GM.postOffice.transform, true);
        }
    }
 
    public void PostOfficeDialogue()
    {
        dialogue.sentences.Clear();
        dialogue.sentences.Add("I'm gonna have to get a nice photo of you. Let me set up, the bathroom's to the left so go freshen up!");
        TriggerDialogue();
    }

    public void WalkUp()
    {
        animator.SetBool("WalkRight", false);
        animator.SetBool("WalkLeft", false);
        animator.SetBool("WalkDown", false);
        animator.SetBool("WalkUp", true);
        rb.velocity = new Vector2(0, 1);
    }

    public void WalkDown()
    {
        animator.SetBool("WalkRight", false);
        animator.SetBool("WalkLeft", false);
        animator.SetBool("WalkDown", true);
        animator.SetBool("WalkUp", false);
        rb.velocity = new Vector2(0, -1);
    }

    public void WalkRight()
    {
        animator.SetBool("WalkRight", true);
        animator.SetBool("WalkLeft", false);
        animator.SetBool("WalkDown", false);
        animator.SetBool("WalkUp", false);
        rb.velocity = new Vector2(1, 0);
    }

    public void WalkLeft()
    {
        animator.SetBool("WalkRight", false);
        animator.SetBool("WalkLeft", true);
        animator.SetBool("WalkDown", false);
        animator.SetBool("WalkUp", false);
        rb.velocity = new Vector2(-1, 0);
    }
}
