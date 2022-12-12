using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Option2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
        option2Triangle.SetActive(true);
        option1Triangle.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        option2Triangle.SetActive(false);
    }


}
