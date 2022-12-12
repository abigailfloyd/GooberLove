using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private DialogueManager dialogueManager;
    private GameManager GM;
    [SerializeField] Pancho pancho;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        dialogueManager = GameObject.FindWithTag("Dialogue Manager").GetComponent<DialogueManager>();
        GM = GameObject.FindWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SignContract()
    {
        playerMovement.doneTouring = true;
        pancho.dialogue.sentences.Clear();
        pancho.dialogue.sentences.Add("Pleasure to have you here! If you need me I'll be downstairs in 2A - just give me a knock knock knock. Bye bye bye.");
        dialogueManager.ChangeBoxBack();
        dialogueManager.HideOptions();
        pancho.TriggerDialogue();
        dialogueManager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        if (GM.currentApt == "3C")
        {
            dialogueManager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { TriggerPanchoAnim3C(); });
        }
        else if (GM.currentApt == "3A")
        {
            dialogueManager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { TriggerPanchoAnim3A(); });
        }
        else
        {
            dialogueManager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { TriggerPanchoAnim2B(); });
        }
        pancho.gameObject.GetComponent<SpriteRenderer>().sprite = pancho.originalSprite;
    }

    public void TriggerPanchoAnim3C()
    {
        

        pancho.animator.enabled = true;
        pancho.animator.SetBool("WalkLeft", true);
        //dialogueManager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        //dialogueManager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.DisplayNextSentence(); });
        pancho.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        pancho.rb.constraints = RigidbodyConstraints2D.None;
        pancho.rb.velocity = new Vector2(-1, 0);
    }

    public void TriggerPanchoAnim3A()
    {
        
        pancho.animator.enabled = true;
        pancho.animator.SetBool("WalkDown", true);
        //dialogueManager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        //dialogueManager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.DisplayNextSentence(); });
        pancho.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        pancho.rb.constraints = RigidbodyConstraints2D.None;
        pancho.rb.velocity = new Vector2(0, -1);
    }

    public void TriggerPanchoAnim2B()
    {
        
        pancho.animator.enabled = true;
        pancho.animator.SetBool("WalkRight", true);
        //dialogueManager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        //dialogueManager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.DisplayNextSentence(); });
        pancho.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        pancho.rb.constraints = RigidbodyConstraints2D.None;
        pancho.rb.velocity = new Vector2(1, 0);
    }

   
}
