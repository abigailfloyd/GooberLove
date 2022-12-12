using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string currentApt = "3C";
    public string playerName = "";

    public GameObject livingRoom3C;
    public GameObject bedroom3C;
    public GameObject bathroom3C;
    public GameObject balcony3C;
    public GameObject threeC;

    public GameObject livingRoom3A;
    public GameObject bedroom3A;
    public GameObject bathroom3A;
    public GameObject balcony3A;
    public GameObject threeA;

    public GameObject livingRoom2B;
    public GameObject bedroom2B;
    public GameObject bathroom2B;
    public GameObject balcony2B;
    public GameObject twoB;

    public GameObject elevator;
    public GameObject stairs;
    public GameObject lobby;
    public GameObject outsideApt;
    public GameObject townCenter;
    public GameObject postOffice;
    public GameObject postOfficeBathroom;
    public GameObject worldCanvas;
    public GameObject screenCanvas;
    public GameObject inventory;

    public GameObject hallway1;
    public GameObject hallway2;

    public GameObject player;

    public List<GameObject> doorColliders = new List<GameObject>();

    public DialogueManager dialogueManager;
    public Pancho pancho;
    public GameObject oxmanPrefab;

    public Image blackSquare;
    public GameObject mapAddedText;


    // Start is called before the first frame update
    void Start()
    {
        pancho.TriggerDialogue();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory.SetActive(!inventory.activeInHierarchy);
        }
    }

    public void ThirdFloorToStairs()
    {
        StartCoroutine(ThirdFloorToStairsCoroutine());
    }

    IEnumerator ThirdFloorToStairsCoroutine()
    {
        yield return new WaitForSeconds(1f);
        currentApt = "StairsUpper";
        hallway1.SetActive(false);
        stairs.SetActive(true);
        player.transform.position = GameObject.FindWithTag("Stairs/third floor spawn").transform.position;
        GameObject oxman = Instantiate(oxmanPrefab, new Vector3(1.17900014f, 0.551999986f, 0), Quaternion.identity);
        oxman.transform.SetParent(stairs.transform, true);
        oxman.transform.position = GameObject.FindWithTag("Oxman start").transform.position;
        oxman.GetComponent<Oxman>().TriggerDialogue();

    }

    public void SecondFloorToStairs()
    {
        StartCoroutine(SecondFloorToStairsCoroutine());
    }

    public IEnumerator MapAddedText()
    {
        yield return new WaitForSeconds(1.5f);
        mapAddedText.SetActive(true);
        StartCoroutine(HideMapText());
    }

    IEnumerator HideMapText()
    {
        yield return new WaitForSeconds(2);
        mapAddedText.SetActive(false);
    }

    IEnumerator SecondFloorToStairsCoroutine()
    {
        yield return new WaitForSeconds(1f);
        currentApt = "StairsLower";
        hallway2.SetActive(false);
        stairs.SetActive(true);
        player.transform.position = GameObject.FindWithTag("Stairs/second floor spawn").transform.position;
        GameObject oxman = Instantiate(oxmanPrefab, new Vector3(1.17900014f, 0.551999986f, 0), Quaternion.identity);
        oxman.transform.SetParent(stairs.transform, true);
        oxman.transform.position = GameObject.FindWithTag("Oxman Start lower").transform.position;
        oxman.GetComponent<Oxman>().TriggerDialogue();
    }

    public void StairsToSecondFloor()
    {
        StartCoroutine(StairsToSecondFloorCoroutine());
    }

    IEnumerator StairsToSecondFloorCoroutine()
    {
        yield return new WaitForSeconds(1f);
        stairs.SetActive(false);
        hallway2.SetActive(true);
        player.transform.position = GameObject.FindWithTag("Hallway/stairs spawn").transform.position;
    }

    public void StairsToThirdFloor()
    {
        StartCoroutine(StairsToThirdFloorCoroutine());
    }

    IEnumerator StairsToThirdFloorCoroutine()
    {
        yield return new WaitForSeconds(1f);
        stairs.SetActive(false);
        hallway1.SetActive(true);
        player.transform.position = GameObject.FindWithTag("Hallway/stairs spawn").transform.position;
    }

    public void HallwayToElevator()
    {
        StartCoroutine(HallwayToElevatorCoroutine());
    }

    IEnumerator HallwayToElevatorCoroutine()
    {
        yield return new WaitForSeconds(1f);
        currentApt = "Elevator";
        hallway1.SetActive(false);
        hallway2.SetActive(false);
        elevator.SetActive(true);
        player.transform.position = GameObject.FindWithTag("Elevator/hallway spawn").transform.position;
        GameObject oxman = Instantiate(oxmanPrefab, new Vector3(0.670000017f, -0.379999995f, 0), Quaternion.identity);
        oxman.transform.SetParent(elevator.transform, true);
        oxman.GetComponent<Oxman>().TriggerDialogue();

        Debug.Log("going from hallway to elevator");
    }

    public void ElevatorToHallway()
    {
        StartCoroutine(ElevatorToHallwayCoroutine());
    }

    IEnumerator ElevatorToHallwayCoroutine()
    {
        yield return new WaitForSeconds(1f);
        elevator.SetActive(false);
        hallway1.SetActive(true);
        player.transform.position = GameObject.FindWithTag("Hallway/elevator spawn").transform.position;

        Debug.Log("going from elevator to hallway");
    }


    public void LivingRoomToHallway()
    {
        StartCoroutine(LivingRoomToHallwayCoroutine());
    }

    IEnumerator LivingRoomToHallwayCoroutine()
    {
        yield return new WaitForSeconds(1f);

        pancho.gameObject.SetActive(false);
        if (currentApt == "3C")
        {
            threeC.SetActive(false);
            hallway1.SetActive(true);
            player.transform.position = GameObject.FindWithTag("Hallway/3C spawn").transform.position;
        }
        else if (currentApt == "3A")
        {
            threeA.SetActive(false);
            hallway1.SetActive(true);
            player.transform.position = GameObject.FindWithTag("Hallway/3A spawn").transform.position;
        }
        else
        {
            twoB.SetActive(false);
            hallway2.SetActive(true);
            player.transform.position = GameObject.FindWithTag("Hallway/2B spawn").transform.position;
        }
    }

    public void LivingRoomToBathroom()
    {
        StartCoroutine(LivingRoomToBathroomCoroutine());
        
    }

    IEnumerator LivingRoomToBathroomCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (currentApt == "3C")
        {
            livingRoom3C.SetActive(false);
            bathroom3C.SetActive(true);
        }
        else if (currentApt == "3A")
        {
            livingRoom3A.SetActive(false);
            bathroom3A.SetActive(true);
        }
        else
        {
            livingRoom2B.SetActive(false);
            bathroom2B.SetActive(true);
        }
        player.transform.position = GameObject.FindWithTag("Bathroom/living room spawn").transform.position;

        Debug.Log("going from living room to bathroom");
    }

    public void LivingRoomToBedroom()
    {
        StartCoroutine(LivingRoomToBedroomCoroutine());
       
    }

    IEnumerator LivingRoomToBedroomCoroutine()
    { 
        yield return new WaitForSeconds(1f);
        if (currentApt == "3C")
        {
            livingRoom3C.SetActive(false);
            bedroom3C.SetActive(true);
        }
        else if (currentApt == "3A")
        {
            livingRoom3A.SetActive(false);
            bedroom3A.SetActive(true);
        }
        else
        {
            livingRoom2B.SetActive(false);
            bedroom2B.SetActive(true);
        }

        player.transform.position = GameObject.FindWithTag("Bedroom/living room spawn").transform.position;
    }

    public void LivingRoomToBalcony()
    {
        StartCoroutine(LivingRoomToBalconyCoroutine());
    }

    IEnumerator LivingRoomToBalconyCoroutine()
    {
        yield return new WaitForSeconds(1f);

        if (currentApt == "3C")
        {
            livingRoom3C.SetActive(false);
            balcony3C.SetActive(true);
        }
        else if (currentApt == "3A")
        {
            livingRoom3A.SetActive(false);
            balcony3A.SetActive(true);
        }
        else
        {
            livingRoom2B.SetActive(false);
            balcony2B.SetActive(true);
        }

        player.transform.position = GameObject.FindWithTag("Balcony/living room spawn").transform.position;
    }

    public void BathroomToBedroom()
    {
        StartCoroutine(BathroomToBedroomCoroutine());
    }

    IEnumerator BathroomToBedroomCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (currentApt == "3C")
        {
            bathroom3C.SetActive(false);
            bedroom3C.SetActive(true);
        }
        else if (currentApt == "3A")
        {
            bathroom3A.SetActive(false);
            bedroom3A.SetActive(true);
        }
        else
        {
            bathroom2B.SetActive(false);
            bedroom2B.SetActive(true);
        }

        player.transform.position = GameObject.FindWithTag("Bedroom/bathroom spawn").transform.position;
    }

    public void BathroomToLivingRoom()
    {
        StartCoroutine(BathroomToLivingRoomCoroutine());
    }

    IEnumerator BathroomToLivingRoomCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (currentApt == "3C")
        {
            bathroom3C.SetActive(false);
            livingRoom3C.SetActive(true);
        }
        else if (currentApt == "3A")
        {
            bathroom3A.SetActive(false);
            livingRoom3A.SetActive(true);
        }
        else
        {
            bathroom2B.SetActive(false);
            livingRoom2B.SetActive(true);
        }
        player.transform.position = GameObject.FindWithTag("Living room/bathroom spawn").transform.position;
        Debug.Log("going from bathroom to living room");
    }

    public void BedroomToBathroom()
    {
        StartCoroutine(BedroomToBathroomCoroutine());
    }

    IEnumerator BedroomToBathroomCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (currentApt == "3C")
        {
            bedroom3C.SetActive(false);
            bathroom3C.SetActive(true);
        }
        else if (currentApt == "3A")
        {
            bedroom3A.SetActive(false);
            bathroom3A.SetActive(true);
        }
        else
        {
            bedroom2B.SetActive(false);
            bathroom2B.SetActive(true);
        }


        player.transform.position = GameObject.FindWithTag("Bathroom/bedroom spawn").transform.position;
    }

    public void BedroomToLivingRoom()
    {
        StartCoroutine(BedroomToLivingRoomCoroutine());
    }

    IEnumerator BedroomToLivingRoomCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (currentApt == "3C")
        {
            bedroom3C.SetActive(false);
            livingRoom3C.SetActive(true);
        }
        else if (currentApt == "3A")
        {
            bedroom3A.SetActive(false);
            livingRoom3A.SetActive(true);
        }
        else
        {
            bedroom2B.SetActive(false);
            livingRoom2B.SetActive(true);
        }


        player.transform.position = GameObject.FindWithTag("Living room/bedroom spawn").transform.position;
    }

    public void BalconyToLivingRoom()
    {
        StartCoroutine(BalconyToLivingRoomCoroutine());
       
    }

    IEnumerator BalconyToLivingRoomCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (currentApt == "3C")
        {
            balcony3C.SetActive(false);
            livingRoom3C.SetActive(true);
        }
        else if (currentApt == "3A")
        {
            balcony3A.SetActive(false);
            livingRoom3A.SetActive(true);
        }
        else
        {
            balcony2B.SetActive(false);
            livingRoom2B.SetActive(true);
        }


        player.transform.position = GameObject.FindWithTag("Living room/balcony spawn").transform.position;
    }

    public void TurnOffDoors()
    {
        foreach (GameObject door in doorColliders)
        {
            door.SetActive(false);
        }
    }

    public void TurnOnDoors()
    {
        foreach (GameObject door in doorColliders)
        {
            door.SetActive(true);
        }
    }

    public IEnumerator FadeToBlack()
    {
        if (!player.GetComponent<PlayerMovement>().oxmanAnimStarted)
        {
            player.GetComponent<PlayerMovement>().playerMovementEnabled = false;
            player.GetComponent<PlayerMovement>().animator.SetFloat("Horizontal", 0.0f);
            player.GetComponent<PlayerMovement>().animator.SetFloat("Vertical", 0.0f);
            player.GetComponent<PlayerMovement>().rb.velocity = new Vector2(0, 0);
            player.GetComponent<PlayerMovement>().animator.enabled = false;
        }
        worldCanvas.SetActive(false);
        screenCanvas.SetActive(true);
        Color c =  blackSquare.color;
        float alpha = 0;
        while (blackSquare.color.a < 1)
        {
            alpha = c.a + (2*Time.deltaTime);
            c = new Color(c.r, c.g, c.b, alpha);
            blackSquare.color = c;
            yield return null;
        }
        StartCoroutine(FadeIn());
    }
    
    public IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(.75f);
        Color c = blackSquare.color;
        float alpha = 1;
        while (blackSquare.color.a > 0)
        {
            alpha = c.a - (2*Time.deltaTime);
            c = new Color(c.r, c.g, c.b, alpha);
            blackSquare.color = c;
            yield return null;
        }
        screenCanvas.SetActive(false);
        worldCanvas.SetActive(true);
        if (!player.GetComponent<PlayerMovement>().oxmanAnimStarted)
        {
            player.GetComponent<PlayerMovement>().playerMovementEnabled = true;
            player.GetComponent<PlayerMovement>().animator.enabled = true;
            player.GetComponent<PlayerMovement>().animator.SetFloat("Horizontal", 0.0f);
            player.GetComponent<PlayerMovement>().animator.SetFloat("Vertical", 0.0f);

        }

    }
}
