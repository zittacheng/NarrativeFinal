using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemController : MonoBehaviour
{
    public Sprite[] ItemImage;



    public int ItemCode;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer targetSpriteRenderer;
    private Animator SampleOnPlate;
    private GameObject InventoryDoor;
    private SpriteRenderer InventoryDoorSprite;
    private Animator inventoryDoor;
    private Animator AudioLogReader;
    private GameObject target;
    private string addName;
    public string targetObject;
    private Animator trashDoor;
    private int CollsionWithValidLocation = 0;
    [HideInInspector] public bool FromInventory = false;
    [HideInInspector] public bool FromResearchStation = false;
    [HideInInspector] public bool FromAudioReader = false;
    [HideInInspector] public bool AudioLog = false;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        SampleOnPlate = GameObject.Find("SampleOnPlate").GetComponent<Animator>();
        trashDoor = GameObject.Find("trash door").GetComponent<Animator>();
        inventoryDoor = GameObject.Find("inventory door").GetComponent<Animator>();
        target = GameObject.Find("research plate");
        InventoryDoor = GameObject.Find("inventory door");
        targetSpriteRenderer = target.GetComponent<SpriteRenderer>();
        InventoryDoorSprite = InventoryDoor.GetComponent<SpriteRenderer>();
        AudioLogReader = GameObject.Find("AudioLogReader").GetComponent<Animator>();
        trashDoor.SetBool("Open", true);
        inventoryDoor.SetBool("Open", true);
    }

    // Update is called once per frame
    void Update()
    {
        //ItemCode = InventorySelectControl.ItemCode;

        spriteRenderer.sprite = ItemImage[ItemCode];
        if (ItemCode == 3)
        {
            AudioLog = true;
        }




        //trashDoor.SetBool("Dump", false);
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
            if(FromInventory){
                
              InventoryDoorController.hasItem = true;
               trashDoor.SetBool("Open", false);
                trashDoor.SetBool("Dump", false);
                inventoryDoor.SetBool("Dump", false);
                inventoryDoor.SetBool("Open", false);
               //GameObject.Find("InventoryItemBoxes").GetComponent<InventorySelectControl>().AddItem(ItemCode);
               Destroy(gameObject);  
                
           }

            else if (FromResearchStation)
            {
                SampleOnPlate.SetInteger("ItemCode", ItemCode);
                SampleOnPlateController.CurrentItemOnPlateCode = ItemCode;
                ResearchButtonController.hasItem = true;
                SampleOnPlateController.hasItem = true;
                //InventoryDoorController.hasItem = false;
                //InventorySelectControl.ItemCode = 0;
                trashDoor.SetBool("Open", false);
                trashDoor.SetBool("Dump", false);
                inventoryDoor.SetBool("Dump", false);
                inventoryDoor.SetBool("Open", false);
                //GameObject.Find("InventoryItemBoxes").GetComponent<InventorySelectControl>().DeleteItem(ItemCode);
                Destroy(gameObject);
            }
            else if (FromAudioReader)
            {
                AudioLogReaderController.ItemCode = ItemCode;
                AudioLogReader.SetTrigger("PutBack");
                trashDoor.SetBool("Open", false);
                trashDoor.SetBool("Dump", false);
                inventoryDoor.SetBool("Dump", false);
                inventoryDoor.SetBool("Open", false);
                Destroy(gameObject);
            }
        }
        //    {
               // if (pz.x > target.transform.position.x - targetSpriteRenderer.bounds.size.x / 2
                 //  && pz.x < target.transform.position.x + targetSpriteRenderer.bounds.size.x / 2 &&
                //   pz.y > target.transform.position.y - targetSpriteRenderer.bounds.size.y / 2
                 //  && pz.y < target.transform.position.y + targetSpriteRenderer.bounds.size.y / 2)
              //  {

                    
         //   }
              //  else
               

            


                //collideWithBowl = false;
            }



            // void OnMouseUp()
            //{
            //    Destroy(gameObject);
            //     Debug.Log("adssad");
            // }
        

    void OnCollisionStay2D(Collision2D coll)
    {

        if (coll.gameObject.name == "trash door"|| coll.gameObject.name == "inventory door"|| coll.gameObject.name == "SampleOnPlate")
        {
            CollsionWithValidLocation++;
        }


        if (coll.gameObject.name == "trash door"&&Input.GetMouseButtonUp(0))
        {
            GameObject.Find("InventoryItemBoxes").GetComponent<InventorySelectControl>().DeleteItem(ItemCode);
            Debug.Log("delete item");
            
            trashDoor.SetBool("Dump", false);
            trashDoor.SetBool("Open",false);
            InventorySelectControl.ItemCode = 0;
            inventoryDoor.SetBool("Dump", false);
            inventoryDoor.SetBool("Open", false);
            // InventoryDoorController.
            Destroy(gameObject);
            //trigger trashdoor animation
        }
        else if (coll.gameObject.name == "trash door")
        {
            trashDoor.SetBool("Dump", true);
            
        }
        if (coll.gameObject.name == "inventory door"&& Input.GetMouseButtonUp(0))
        {

            inventoryDoor.SetBool("Dump", false);
            inventoryDoor.SetBool("Open",false);
            trashDoor.SetBool("Dump", false);
            trashDoor.SetBool("Open", false);
            AudioLogReaderController.ItemCode = 0;
           // GameObject.Find("InventoryItemBoxes").GetComponent<InventorySelectControl>().AddItem(ItemCode);
            Debug.Log("Add item to inventory");
            Destroy(gameObject);
        }
        else if(coll.gameObject.name == "inventory door")
        {
            inventoryDoor.SetBool("Dump",true);
            InventoryDoorController.hasItem = true;
        }

        if(coll.gameObject.name == "SampleOnPlate" && Input.GetMouseButtonUp(0)&&SampleOnPlateController.hasItem == false&&AudioLog == false)
        {
            SampleOnPlate.SetInteger("ItemCode", ItemCode);
            SampleOnPlateController.CurrentItemOnPlateCode = ItemCode;
            SampleOnPlateController.hasItem = true;
            ResearchButtonController.hasItem = true;
            InventoryDoorController.hasItem = false;
            InventorySelectControl.ItemCode = 0;
            trashDoor.SetBool("Open", false);
            trashDoor.SetBool("Dump", false);
            inventoryDoor.SetBool("Dump", false);
            inventoryDoor.SetBool("Open", false);
            //GameObject.Find("InventoryItemBoxes").GetComponent<InventorySelectControl>().DeleteItem(ItemCode);
            Destroy(gameObject);
        }
        if (coll.gameObject.name == "AudioLogReader" && Input.GetMouseButtonUp(0) && AudioLogReaderController.ItemCode == 0&&AudioLog == true)
        {
            AudioLogReaderController.ItemCode = ItemCode;
            AudioLogReaderController.reading = true;
            InventoryDoorController.hasItem = false;
            InventorySelectControl.ItemCode = 0;
            AudioLogReader.SetBool("Insert",true);
            trashDoor.SetBool("Open", false);
            trashDoor.SetBool("Dump", false);
            inventoryDoor.SetBool("Dump", false);
            inventoryDoor.SetBool("Open", false);
            Debug.Log("AudioLog in the reader");
            Destroy(gameObject);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       // if (collision.gameObject.name == "trash door" || collision.gameObject.name == "inventory door" || collision.gameObject.name == "SampleOnPlate")
       // {
        //    CollsionWithValidLocation --;
       // }
        if (collision.gameObject.name == "trash door")
        {
            trashDoor.SetBool("Dump", false);
        }
        if (collision.gameObject.name == "inventory door")
        {
            inventoryDoor.SetBool("Dump", false);
            //GameObject.Find("InventoryItemBoxes").GetComponent<InventorySelectControl>().DeleteItem(ItemCode);
            InventoryDoorController.hasItem = false;
        }
        
    }

    
}




