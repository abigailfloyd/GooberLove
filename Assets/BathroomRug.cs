using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomRug : MonoBehaviour
{
    public Sprite defaultRug;
    public Sprite highlightedRug;
    public GameObject customization;

    void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = highlightedRug;
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = defaultRug;
    }

    public void ShowCustomization()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = highlightedRug;
        customization.SetActive(true);
    }

    public void HideCustomization()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = defaultRug;
        customization.SetActive(false);
    }
}
