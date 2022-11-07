using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject livingRoom;
    public GameObject bedroom;
    public GameObject bathroom;
    public GameObject balcony;

    public GameObject player;

    public List<GameObject> doorColliders = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LivingRoomToBathroom()
    {
        livingRoom.SetActive(false);
        bathroom.SetActive(true);

        player.transform.position = GameObject.FindWithTag("Bathroom/living room spawn").transform.position;

        Debug.Log("going from living room to bathroom");

    }

    public void LivingRoomToBedroom()
    {
        livingRoom.SetActive(false);
        bedroom.SetActive(true);

        player.transform.position = GameObject.FindWithTag("Bedroom/living room spawn").transform.position;
    }

    public void LivingRoomToBalcony()
    {
        livingRoom.SetActive(false);
        balcony.SetActive(true);

        player.transform.position = GameObject.FindWithTag("Balcony/living room spawn").transform.position;
    }

    public void BathroomToBedroom()
    {
        bathroom.SetActive(false);
        bedroom.SetActive(true);

        player.transform.position = GameObject.FindWithTag("Bedroom/bathroom spawn").transform.position;
    }

    public void BathroomToLivingRoom()
    {
        bathroom.SetActive(false);
        livingRoom.SetActive(true);

        player.transform.position = GameObject.FindWithTag("Living room/bathroom spawn").transform.position;

        Debug.Log("going from bathroom to living room");
    }

    public void BedroomToBathroom()
    {
        bedroom.SetActive(false);
        bathroom.SetActive(true);

        player.transform.position = GameObject.FindWithTag("Bathroom/bedroom spawn").transform.position; 
    }

    public void BedroomToLivingRoom()
    {
        bedroom.SetActive(false);
        livingRoom.SetActive(true);

        player.transform.position = GameObject.FindWithTag("Living room/bedroom spawn").transform.position; 
    }

    public void BalconyToLivingRoom()
    {
        balcony.SetActive(false);
        livingRoom.SetActive(true);

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
}
