using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Option1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject option1Triangle;
    public GameObject option2Triangle;
    public GameObject option1Text;
    public GameObject option2Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        option1Triangle.SetActive(true);
        option2Triangle.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exiting text");
        option1Triangle.SetActive(false);
    }

}
