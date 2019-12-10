using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapButtonController : MonoBehaviour
{
    public float scaleUp;
    public SpriteRenderer spriteRenderer;
    //public GameObject prefab;
    private bool highlight = false;
    private Vector3 largeValue;
    private Vector3 smallValue;
    public string buttonName;
    private GameObject screenText;
    public Animator animator;
    public string AnimationTriggerName;
    private bool mapOpen = false;
    public GameObject MapInterface;


    //private bool ifCollideWithMouse = false;
    void Start()
    {
        largeValue = new Vector3(transform.localScale.x * scaleUp, transform.localScale.y * scaleUp, 1);
        smallValue = new Vector3(transform.localScale.x / scaleUp, transform.localScale.y / scaleUp, 1);
        screenText = GameObject.Find("screen text");


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;

        if (pz.x > gameObject.transform.position.x - spriteRenderer.bounds.size.x / 2 && pz.x < gameObject.transform.position.x + spriteRenderer.bounds.size.x / 2 &&
                pz.y > gameObject.transform.position.y - spriteRenderer.bounds.size.y / 2 && pz.y < gameObject.transform.position.y + spriteRenderer.bounds.size.y / 2
               )
        {
            //gameObject.transform.localScale = new Vector3(transform.localScale.x * scaleUp, transform.localScale.y * scaleUp, 1);
            highlight = true;
            Debug.Log("highlight");
        }
        else
        {
            //gameObject.transform.localScale = new Vector3(transform.localScale.x / scaleUp, transform.localScale.y / scaleUp, 1);
            highlight = false;
        }

        if (highlight)
        {


        }
        else
        {


            //gameObject.transform.localScale = new Vector3(transform.localScale.x / scaleUp, transform.localScale.y / scaleUp, 1);
        }
    }
    void OnMouseOver()
    {
        screenText.GetComponent<TextMeshPro>().text = buttonName;
        gameObject.transform.localScale = largeValue;
        Debug.Log("Mouse is over GameObject.");
    }
    void OnMouseExit()
    {
        screenText.GetComponent<TextMeshPro>().text = "  ";
        gameObject.transform.localScale = smallValue;
        Debug.Log("Mouse is no longer on GameObject.");
    }

    void OnMouseDown()
    {
        //spriteRenderer.color = new Color(1, 1, 1, 1);

        // Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  pz.z = 0;

        //Instantiate(prefab, pz, Quaternion.identity);
        animator.SetTrigger(AnimationTriggerName);


    }
    void OnMouseUp()
    {
        //spriteRenderer.color = new Color(0.8f, 0.8f, 0.8f, 1);
        Debug.Log("mouse up");
    }

    void OpenOrCloseMap()
    {
        if (MapInterface.activeSelf  == false)
        {
           // mapOpen = true;
            MapInterface.SetActive(true);
        }
        else if (MapInterface.activeSelf == true)
        {
           // mapOpen = false;
            MapInterface.SetActive(false);
        }
    }

    
}
