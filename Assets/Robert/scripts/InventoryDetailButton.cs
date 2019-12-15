using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDetailButton : MonoBehaviour
{

    public Animator animator;
    public string AnimationBoolName;
    public string AnimationTriggerName;
    private Animator InventoryButton;
    private Animator InventoryDoor;

    // Start is called before the first frame update
    void Start()
    {
        InventoryButton = GameObject.Find("inventory button").GetComponent<Animator>();
        InventoryDoor = GameObject.Find("inventory door").GetComponent<Animator>();
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
        animator.SetTrigger(AnimationTriggerName);
        AfterSelect();

    }

    void OnMouseOver()
    {
        animator.SetBool(AnimationBoolName, true);

    }
    void OnMouseExit()
    {
        animator.SetBool(AnimationBoolName, false);
    }
    void AfterSelect()
    {
        if (InventorySelectControl.ItemCode == 4||InventorySelectControl.ItemCode == 17)
        {
            
            TextControl.Main.Event("Upgrade", InventorySelectControl.ItemCode);
            Debug.Log("Upgrade");
            GameObject.Find("InventoryItemBoxes").GetComponent<InventorySelectControl>().DeleteItem(InventorySelectControl.ItemCode);
            InventoryButton.SetTrigger("Click");
        }
        else
        {
        InventoryButton.SetTrigger("Click");
        InventoryDoor.SetBool("Open", true);
        InventoryDoorController.hasItem = true;
        }
        
        //spawn inventory item there
    }
}
