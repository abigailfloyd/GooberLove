using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    private GameObject player;
    [SerializeField] Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < (gameObject.transform.position.y-.4))
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "Room";
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "NPC";
        }
    }
}
