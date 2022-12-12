using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public GameObject player;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dialogueManager = GameObject.FindWithTag("Dialogue Manager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (player.transform.position.y < (gameObject.transform.position.y-.3))
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "Room";
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "NPC";
        }

    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    
    

   






}
