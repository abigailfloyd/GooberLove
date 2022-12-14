using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rb;
    public float speed = 1;
    public bool doneTouring = false;
    public bool playerMovementEnabled = true;

    public Animation Opening;
    public Animation elevatorClosing;
    public Sprite defaultSprite;
    public bool oxmanAnimStarted = false;

    [SerializeField] GameManager GM;
    [SerializeField] DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementEnabled)
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            if (Input.GetAxis("Horizontal") == 0)
            {
                animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
            }
            else
            {
                animator.SetFloat("Vertical", 0.0f);
            }


            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = 0.0f;
            if (horizontal == 0)
            {
                vertical = Input.GetAxisRaw("Vertical");
            }

            rb.velocity = new Vector2(horizontal * speed, vertical * speed);

            //Vector3 tempVect = new Vector3(horizontal, vertical, 0);
            // tempVect = tempVect.normalized * speed * Time.deltaTime;
            //transform.position += tempVect;
        }


    }

    IEnumerator LobbyToOutside()
    {
        yield return new WaitForSeconds(1f);
        GM.lobby.SetActive(false);
        GM.outsideApt.SetActive(true);
        GameObject.FindWithTag("Oxman").GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.position = GameObject.FindWithTag("Player start").transform.position;
        GameObject.FindWithTag("Oxman").transform.position = GameObject.FindWithTag("Oxman start").transform.position;
        GameObject.FindWithTag("Oxman").GetComponent<Oxman>().WalkDown();
        WalkDown();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Front Door")
        {
            if (!oxmanAnimStarted)
            {
                if (!doneTouring)
                {
                    GM.pancho.dialogue.sentences.Clear();
                    GM.pancho.dialogue.sentences.Add("Running away already? You?ll hafta make a decision first.");
                    GM.pancho.TriggerDialogue();
                }
                else
                {
                    StartCoroutine(GM.FadeToBlack());
                    GM.LivingRoomToHallway();
                }
            }
            else
            {
                StartCoroutine(GM.FadeToBlack());
                StartCoroutine(LobbyToOutside());
            }
        }
        if (other.tag == "Living room to bathroom")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.LivingRoomToBathroom();
        }

        if (other.tag == "Living room to bedroom")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.LivingRoomToBedroom();
        }

        if (other.tag == "Living room to balcony")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.LivingRoomToBalcony();
        }

        if (other.tag == "Bedroom to bathroom")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.BedroomToBathroom();
        }

        if (other.tag == "Bedroom to living room")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.BedroomToLivingRoom();
        }

        if (other.tag == "Bathroom to bedroom")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.BathroomToBedroom();
        }

        if (other.tag == "Bathroom to living room")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.BathroomToLivingRoom();
        }

        if (other.tag == "Balcony to living room")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.BalconyToLivingRoom();
        }
        if (other.tag == "Hallway to elevator")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.HallwayToElevator();
        }  
        if (other.tag == "Hallway1 to stairs")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.ThirdFloorToStairs();
        }
        if (other.tag == "Hallway2 to stairs")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.SecondFloorToStairs();
        }
        if (other.tag == "Stairs to third floor")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.StairsToThirdFloor();
        }
        if (other.tag == "Stairs to second floor")
        {
            StartCoroutine(GM.FadeToBlack());
            GM.StairsToSecondFloor();
        }
        if (other.tag == "Stairs to first floor" && oxmanAnimStarted)
        {
            StartCoroutine(GM.FadeToBlack());
            StartCoroutine(StartFollowAnimStairs());
        }
        if (other.tag == "DoorTo3C")
        {
            StartCoroutine(GM.FadeToBlack());
            StartCoroutine(GoTo3C());
        }
        if (other.tag == "DoorTo3A")
        {
            StartCoroutine(GM.FadeToBlack());
            StartCoroutine(GoTo3A());
        }
        if (other.tag == "DoorTo2B")
        {
            StartCoroutine(GM.FadeToBlack());
            StartCoroutine(GoTo2B());
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
        if (other.tag == "Turn down right")
        {
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
            rb.velocity = new Vector2(1, -.25f); ;
        }
        if (other.tag == "Oxman start")
        {
            WalkRight();
        }
        if (other.tag == "Elevator door" && oxmanAnimStarted)
        {
            StartCoroutine(GM.FadeToBlack());
            StartCoroutine(StartFollowAnimElevator());
        }
        if (other.tag == "End of walkway")
        {
            StartCoroutine(GM.FadeToBlack());
            StartCoroutine(EndOfWalkway());
        }
        if (other.tag == "Post office")
        {
            StartCoroutine(GM.FadeToBlack());
            StartCoroutine(IntoPostOffice());
        }
        if (other.tag == "Post office bathroom")
        {
            StartCoroutine(GM.FadeToBlack());
            StartCoroutine(IntoPostOfficeBathroom());
        }
        if (other.tag == "Post office main room")
        {
            StartCoroutine(GM.FadeToBlack());
            StartCoroutine(IntoPostOfficeMainRoom());
        }
        if (other.tag == "Rug")
        {
            other.gameObject.GetComponent<BathroomRug>().ShowCustomization();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Rug")
        {
            other.gameObject.GetComponent<BathroomRug>().HideCustomization();
        }
    }

    IEnumerator IntoPostOfficeMainRoom()
    {
        yield return new WaitForSeconds(1f);
        GM.postOfficeBathroom.SetActive(false);
        GM.postOffice.SetActive(true);
        gameObject.transform.position = GameObject.FindWithTag("Post office main room bathroom spawn").transform.position;
    }

    IEnumerator IntoPostOfficeBathroom()
    {
        yield return new WaitForSeconds(1f);
        GM.postOffice.SetActive(false);
        GM.postOfficeBathroom.SetActive(true);
        gameObject.transform.position = GameObject.FindWithTag("Post office bathroom spawn").transform.position;
    }

    IEnumerator IntoPostOffice()
    {
        yield return new WaitForSeconds(1f);
        GM.townCenter.SetActive(false);
        GM.postOffice.SetActive(true);
        GameObject.FindWithTag("Oxman").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindWithTag("Oxman").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.transform.position = GameObject.FindWithTag("Player start").transform.position;
        GameObject.FindWithTag("Oxman").transform.position = GameObject.FindWithTag("Oxman start").transform.position;
        GameObject.FindWithTag("Oxman").GetComponent<Oxman>().PostOfficeDialogue();
        playerMovementEnabled = true;
        animator.SetFloat("Horizontal", 0.0f);
        animator.SetFloat("Vertical", 0.0f);
        GameObject.FindWithTag("Oxman").GetComponent<BoxCollider2D>().isTrigger = false;
    }

    IEnumerator EndOfWalkway()
    {
        yield return new WaitForSeconds(1f);
        GM.outsideApt.SetActive(false);
        GM.townCenter.SetActive(true);
        GameObject.FindWithTag("Oxman").GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.position = GameObject.FindWithTag("Player start").transform.position;
        GameObject.FindWithTag("Oxman").transform.position = GameObject.FindWithTag("Oxman start").transform.position;
        GameObject.FindWithTag("Oxman").GetComponent<Oxman>().WalkDown();
        WalkDown();
    }

    public void WalkUp()
    {
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 1);
        rb.velocity = new Vector2(0, 1);
    }
    
    public void WalkDown()
    {
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", -1);
        rb.velocity = new Vector2(0, -1);
    }
    
    public void WalkRight()
    {
        animator.SetFloat("Horizontal", 1);
        animator.SetFloat("Vertical", 0);
        rb.velocity = new Vector2(1, 0);
    }
    
    public void WalkLeft()
    {
        animator.SetFloat("Horizontal", -1);
        animator.SetFloat("Vertical", 0);
        rb.velocity = new Vector2(-1, 0);
    }

    public IEnumerator StartFollowAnimElevator()
    {
        dialogueManager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.continueButton.GetComponent<Button>().onClick.AddListener(dialogueManager.DisplayNextSentence);
        playerMovementEnabled = false;
        animator.SetFloat("Horizontal", 0.0f);
        animator.SetFloat("Vertical", 0.0f);
        rb.velocity = new Vector2(0, 0);
        animator.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
        yield return new WaitForSeconds(1);
        GM.elevator.SetActive(false);
        GM.lobby.SetActive(true);
        gameObject.transform.position = GameObject.FindWithTag("Elevator door").transform.position;
        GameObject.FindWithTag("Oxman").transform.position = GameObject.FindWithTag("Oxman start").transform.position;
        GM.lobby.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1f);
        GameObject.FindWithTag("Oxman").GetComponent<Oxman>().WalkRight();
        yield return new WaitForSeconds(.5f);
        animator.enabled = true;
        animator.SetFloat("Vertical", -1);
        rb.velocity = new Vector2(0, -1);
    }

    IEnumerator StartFollowAnimStairs()
    {
        dialogueManager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.DisplayNextSentence(); });
        playerMovementEnabled = false;
        animator.SetFloat("Horizontal", 0.0f);
        animator.SetFloat("Vertical", 0.0f);
        rb.velocity = new Vector2(0, 0);
        animator.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
        yield return new WaitForSeconds(1);
        GM.stairs.SetActive(false);
        GM.lobby.SetActive(true);
        gameObject.transform.position = GameObject.FindWithTag("Stairs/stairs").transform.position;
        GameObject.FindWithTag("Oxman").transform.position = GameObject.FindWithTag("Oxman Start lower").transform.position;
        yield return new WaitForSeconds(1f);
        GameObject.FindWithTag("Oxman").GetComponent<Oxman>().WalkRight();
        yield return new WaitForSeconds(.5f);
        animator.enabled = true;
        animator.SetFloat("Horizontal", 1);
        rb.velocity = new Vector2(1, 0);
    }

    public IEnumerator GoTo3A()
    {
        yield return new WaitForSeconds(1);
        GM.currentApt = "3A";
        GM.threeC.SetActive(false);
        GM.twoB.SetActive(false);
        GM.threeA.SetActive(true);
        GM.hallway1.SetActive(false);
        GM.hallway2.SetActive(false);
        gameObject.transform.position = GameObject.FindWithTag("Living room/hallway spawn").transform.position;
        if (!doneTouring)
        {
            GM.pancho.gameObject.SetActive(true);
            GM.pancho.gameObject.transform.position = GameObject.FindWithTag("Pancho Start").transform.position;
            GM.pancho.gameObject.transform.SetParent(GM.livingRoom3A.transform);
        }
        
    }

    public IEnumerator GoTo2B()
    {
        yield return new WaitForSeconds(1);
        GM.currentApt = "2B";
        GM.threeC.SetActive(false);
        GM.twoB.SetActive(true);
        GM.threeA.SetActive(false);
        GM.hallway1.SetActive(false);
        GM.hallway2.SetActive(false);
        gameObject.transform.position = GameObject.FindWithTag("Living room/hallway spawn").transform.position;
        if (!doneTouring)
        {
            GM.pancho.gameObject.SetActive(true);
            GM.pancho.gameObject.transform.position = GameObject.FindWithTag("Pancho Start").transform.position;
            GM.pancho.gameObject.transform.SetParent(GM.livingRoom2B.transform);
        }
    }

    public IEnumerator GoTo3C()
    {
        yield return new WaitForSeconds(1);
        GM.currentApt = "3C";
        GM.threeC.SetActive(true);
        GM.twoB.SetActive(false);
        GM.threeA.SetActive(false);
        GM.hallway1.SetActive(false);
        GM.hallway2.SetActive(false);
        gameObject.transform.position = GameObject.FindWithTag("Living room/hallway spawn").transform.position;
        if (!doneTouring)
        {
            GM.pancho.gameObject.SetActive(true);
            GM.pancho.gameObject.transform.position = GameObject.FindWithTag("Pancho Start").transform.position;
            GM.pancho.gameObject.transform.SetParent(GM.livingRoom3C.transform);
        }
    }



}
