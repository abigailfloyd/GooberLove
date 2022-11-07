using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rb;
    public float speed = 1;

    [SerializeField] GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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

    void OnTriggerEnter2D(Collider2D other)
    {
        GM.TurnOffDoors();
        if (other.tag == "Living room to bathroom")
        {
            GM.LivingRoomToBathroom();
        }

        if (other.tag == "Living room to bedroom")
        {
            GM.LivingRoomToBedroom();
        }

        if (other.tag == "Living room to balcony")
        {
            GM.LivingRoomToBalcony();
        }

        if (other.tag == "Bedroom to bathroom")
        {
            GM.BedroomToBathroom();
        }

        if (other.tag == "Bedroom to living room")
        {
            GM.BedroomToLivingRoom();
        }

        if (other.tag == "Bathroom to bedroom")
        {
            GM.BathroomToBedroom();
        }

        if (other.tag == "Bathroom to living room")
        {
            GM.BathroomToLivingRoom();
        }

        if (other.tag == "Balcony to living room")
        {
            GM.BalconyToLivingRoom();
        }
        GM.TurnOnDoors();
    }

}
