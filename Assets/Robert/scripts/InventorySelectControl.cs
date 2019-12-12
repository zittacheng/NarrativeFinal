using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySelectControl : MonoBehaviour
{
    [HideInInspector]public static int OtherSelectedBox = 0;
    private GameObject InventoryDetail;
    public static int ItemCode = 0;
    public TextMeshPro descriptionText;
    public string[] ItemDescription;
    private int[ ,] itemList;
    private int[] itemObtained = new int[9];
    public GameObject prefabSelectBox;
    public GameObject parent;
    private string GameObjectName;
    [HideInInspector]public static bool deleteAllBoxes = false;
    public static bool ReadyToInstantiate = true;
   // [HideInInspector]public static int CurrentItemCode = 0;
    //public string Item2;

    // Start is called before the first frame update
    void Awake()
    {
        itemList = new int[3,3];

        InventoryDetail = GameObject.Find("inventory detail");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j< 3; j++)
            {
                itemList[i,j] = 0;
            }
        }
        for (int i = 0; i < itemObtained.Length; i++)
        {
            itemObtained[i] = 0;
        }
        //itemList[0,0] = 2;
        //itemList[1,0] = 3;
       // itemList[2, 0] = 4;
    }

    void Start()
    {
        AddItem(1);
        AddItem(2);
        AddItem(3);
    }

    void OnEnable()
    {
       // Debug.Log("PrintOnEnable: script was enabled");
    }

    // Update is called once per frame
    void Update()
    {
        //if (ItemCode == 1)
        // {
        //     descriptionText.text = Item1;
        // }
        // else if (ItemCode == 2)
        // {
        // descriptionText.text = Item2;
        // }
        Refresh2DArray();
        descriptionText.text = ItemDescription[ItemCode];
        if (ItemCode == 0)
        {
            InventoryDetail.SetActive(false);
        }
        else InventoryDetail.SetActive(true);
        //if (OtherSelectedBox>0)
        // {
        //  InventoryDetail.SetActive(true);
        // }
        // else
        // {
        //   InventoryDetail.SetActive(false);
        // }
    }

  
    public void InstantiateAllBoxes()
    {
        GameObject[] ItemBoxes = GameObject.FindGameObjectsWithTag("ItemBox");
        foreach (GameObject ItemBox in ItemBoxes)
            GameObject.Destroy(ItemBox);

        ItemCode = 0;
        InventoryDoorController.hasItem = false;
        GameObject.Find("inventory door").GetComponent<Animator>().SetBool("Open", false);
        //instantiate all new boxes
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (itemList[i,j] != 0)
                {
                    //GameObjectName = "gameObjectCode" + (i + j * 3).ToString();
                    
                    Debug.Log("instantiate box");
                    //CurrentItemCode = itemList[i, j];

                    //-3.7f + i * 1.8f, 3f - j * 1.8f
                    var obj = (GameObject)Instantiate(prefabSelectBox, new Vector3(parent.transform.position.x-3.8f+i*1.8f,parent.transform.position.y+2f-j*1.8f), Quaternion.identity,parent.transform);
                    obj.GetComponent<ItemBox>().ItemCode = itemList[i, j];
                    //obj.transform.parent = parent.transform;

                    //Instantiate(prefabSelectBox, new Vector3(-4f + i * 1.8f, 3.6f - j * 1.8f), Quaternion.identity, parent.transform);
                // ClickBox.SendMessage("setItemCode", itemList[i,j]);
                }
            }
        }
        Debug.Log("Instantiate all boxes");
    }



    public void AddItem(int ThisItemCode)
    {
        for (int i = 0; i < itemObtained.Length; i++)
        {
            if(itemObtained[i] == 0)
            {
                itemObtained[i] = ThisItemCode;
                i = 20;
            }
        }
        Debug.Log("add new item" + ThisItemCode);
        Refresh2DArray();
    }
    public void DeleteItem(int ThisItemCodeA)
    {
        for (int i = 0; i < itemObtained.Length; i++)
        {
            if (itemObtained[i] == ThisItemCodeA)
            {
                itemObtained[i] = 0;
                i = 20;
            }

        }
        for (int i = 0; i < itemObtained.Length - 1; i++)
        {
            if (itemObtained[i] == 0)
            {
                itemObtained[i] = itemObtained[i+1];
                itemObtained[i + 1] = 0;
            }

        }
        Refresh2DArray();
    }


    void Refresh2DArray()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                itemList[i, j] = itemObtained[i+j*3];
            }
        }
    }
}
