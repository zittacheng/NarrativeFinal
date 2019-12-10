using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Sprite[] ItemImage;



    public static int ItemCode = 0;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer targetSpriteRenderer;
    private Animator SampleOnPlate;
    private GameObject InventoryDoor;
    private SpriteRenderer InventoryDoorSprite;

    private GameObject target;
    private string addName;
    public string targetObject;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        SampleOnPlate = GameObject.Find("SampleOnPlate").GetComponent<Animator>();
        target = GameObject.Find("research plate");
        InventoryDoor = GameObject.Find("inventory door");
        targetSpriteRenderer = target.GetComponent<SpriteRenderer>();
        InventoryDoorSprite = InventoryDoor.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ItemCode = InventorySelectControl.ItemCode;

        spriteRenderer.sprite = ItemImage[ItemCode];






        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;
        addName = gameObject.name;



      //  if (pz.x < InventoryDoor.transform.position.x - InventoryDoorSprite.bounds.size.x / 2
        //       && pz.x > InventoryDoor.transform.position.x + InventoryDoorSprite.bounds.size.x / 2 &&
        //       pz.y < InventoryDoor.transform.position.y - InventoryDoorSprite.bounds.size.y / 2
        //       && pz.y > InventoryDoor.transform.position.y + InventoryDoorSprite.bounds.size.y / 2)
       // {
       //     InventoryDoorController.hasItem = false;
        //    Debug.Log("leave doorayayayayayyyaayya");
      //  }
      // {


            if (Input.GetMouseButtonUp(0))
            {
                if (pz.x > target.transform.position.x - targetSpriteRenderer.bounds.size.x / 2
                   && pz.x < target.transform.position.x + targetSpriteRenderer.bounds.size.x / 2 &&
                   pz.y > target.transform.position.y - targetSpriteRenderer.bounds.size.y / 2
                   && pz.y < target.transform.position.y + targetSpriteRenderer.bounds.size.y / 2)
                {

                    SampleOnPlate.SetInteger("ItemCode", ItemCode);
                    ResearchButtonController.hasItem = true;
                    InventoryDoorController.hasItem = false;
                    InventorySelectControl.ItemCode = 0;
                    Destroy(gameObject);
                    
                }
                else
                {
                    // Debug.Log("not collide with bowl");
                    Destroy(gameObject);
                    InventoryDoorController.hasItem = true;
                    
                }




                //collideWithBowl = false;
            }



            // void OnMouseUp()
            //{
            //    Destroy(gameObject);
            //     Debug.Log("adssad");
            // }
        }


    
}




