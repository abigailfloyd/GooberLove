using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private DialogueManager dialogueManager;
    [SerializeField] Pancho pancho;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        dialogueManager = GameObject.FindWithTag("Dialogue Manager").GetComponent<DialogueManager>();
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
        dialogueManager.HideOptions();
        pancho.TriggerDialogue();
        dialogueManager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { TriggerPanchoAnim(); });
        pancho.gameObject.GetComponent<SpriteRenderer>().sprite = pancho.originalSprite;
    }

    public void TriggerPanchoAnim()
    {
        pancho.animator.enabled = true;
        pancho.animator.SetBool("WalkLeft", true);
        //dialogueManager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        //dialogueManager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { dialogueManager.DisplayNextSentence(); });
        pancho.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        pancho.rb.constraints = RigidbodyConstraints2D.None;
        pancho.rb.velocity = new Vector2(-1, 0);
    }
}
