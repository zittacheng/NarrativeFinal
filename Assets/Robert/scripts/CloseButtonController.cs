using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonController : MonoBehaviour
{
    public Animator animator;
    public GameObject ControlledWindow;
    public bool IfInventoryWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseDown()
    {
        //spriteRenderer.color = new Color(1, 1, 1, 1);

        // Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  pz.z = 0;

        //Instantiate(prefab, pz, Quaternion.identity);
        animator.SetTrigger("Click");


    }

    void OnMouseOver()
    {
        animator.SetBool("Highlight", true);

    }
    void OnMouseExit()
    {
        animator.SetBool("Highlight", false);
    }

    void CloseWindow()
    {
        //MapController.CurrentSelectLocationCode = 0;
        if (IfInventoryWindow)
        {
            InventoryButtonController.animator.SetTrigger("Click");
        }
        else
        {
            ControlledWindow.SetActive(false);
        }
        
    }

}
