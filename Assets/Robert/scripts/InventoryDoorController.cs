using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public float scaleUp;
    public SpriteRenderer spriteRenderer;
    public GameObject prefab;
    private bool highlight = false;
    private Vector3 largeValue;
    private Vector3 smallValue;
    private int ItemCode;
    private Animator animator;
    public static bool hasItem = false;
    //private bool ifCollideWithMouse = false;
    void Start()
    {
        largeValue = new Vector3(transform.localScale.x * scaleUp, transform.localScale.y * scaleUp, 1);
        smallValue = new Vector3(transform.localScale.x / scaleUp, transform.localScale.y / scaleUp, 1);
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        ItemCode = InventorySelectControl.ItemCode;
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

        if (hasItem)
        {
            animator.SetBool("Dump", true);
            animator.SetBool("Open", true);
        }
        else 
        {
            animator.SetBool("Dump", false);
            animator.SetBool("Open", false);
        }
        
            

            //gameObject.transform.localScale = new Vector3(transform.localScale.x / scaleUp, transform.localScale.y / scaleUp, 1);
        
    }
    void OnMouseEnter()
    {
        //gameObject.transform.localScale = new Vector3(transform.localScale.x * scaleUp, transform.localScale.y * scaleUp, 1);
        //   Debug.Log("highlight");
        if (InventoryDoorController.hasItem == true)
        {
        InventoryDoorController.hasItem = true;
            //GameObject.Find("InventoryItemBoxes").GetComponent<InventorySelectControl>().AddItem(ItemCode);
        }
       
    }
    void OnMouseExit()
    {
        if (InventoryDoorController.hasItem == true)
        {
            InventoryDoorController.hasItem = false;
            //GameObject.Find("InventoryItemBoxes").GetComponent<InventorySelectControl>().DeleteItem(ItemCode);
        }

        //InventoryDoorController.hasItem = false;
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Item")
    //    {
   //         hasItem = true;
   //         Debug.Log("Item on door");
   //     }
  //  }




    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //  if (collision.gameObject.name == "mouse" && ifCollideWithMouse == false)
    //  {
    //       gameObject.transform.localScale = new Vector3(transform.localScale.x * scaleUp, transform.localScale.y * scaleUp, 1);
    //       Debug.Log("highlight");
    //      ifCollideWithMouse = true;
    //
    //    }
    //   else if (collision.gameObject.name != "mouse")
    //   {
    //        ifCollideWithMouse = false;
    //    }
    //  }


    void OnMouseDown()
    {
       // spriteRenderer.color = new Color(1, 1, 1, 1);

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;

        Instantiate(prefab, pz, Quaternion.identity);
        //GameObject.Find("Item(1)").GetComponent<ItemController>().
        
    }
    void OnMouseUp()
    {
       // spriteRenderer.color = new Color(0.8f, 0.8f, 0.8f, 1);
       // Debug.Log("mouse up");
    }
}