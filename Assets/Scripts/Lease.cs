using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lease : MonoBehaviour
{
    public GameManager GM;
    private bool typingName = false;
    public TMP_InputField inputField;
    public PlayerManager playerManager;
    public GameObject lease3C;
    public GameObject lease3A;
    public GameObject lease2B;
    public ScrollRect scrollRect;

    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().playerMovementEnabled = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().animator.SetFloat("Horizontal", 0.0f);
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().animator.SetFloat("Vertical", 0.0f);
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rb.velocity = new Vector2(0, 0);
        GM = GameObject.FindWithTag("GM").GetComponent<GameManager>();
        if (GM.currentApt == "3C")
        {
            scrollRect.content = lease3C.GetComponent<RectTransform>();
            lease3C.SetActive(true);
            lease3A.SetActive(false);
            lease2B.SetActive(false);
        }
        else if (GM.currentApt == "3A")
        {
            scrollRect.content = lease3A.GetComponent<RectTransform>();
            lease3C.SetActive(false);
            lease3A.SetActive(true);
            lease2B.SetActive(false);
        }
        else
        {
            scrollRect.content = lease2B.GetComponent<RectTransform>();
            lease3C.SetActive(false);
            lease3A.SetActive(false);
            lease2B.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (typingName && inputField.text.Length > 0)
            {
                GM.playerName = inputField.text;
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().playerMovementEnabled = true;
                gameObject.SetActive(false);
                playerManager.SignContract();
            }
        }
    }

    public void StartTypingName()
    {
        typingName = true;
    }

    public void EndTypingName()
    {
        typingName = false;
    }
}
