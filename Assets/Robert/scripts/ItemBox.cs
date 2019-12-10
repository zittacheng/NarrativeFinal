using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Animator animator;
    public string AnimationBoolName;
    public string AnimationTriggerName;
    private bool selected = false;
    public GameObject InventoryDetail;
    private bool MouseOver;
    public int ItemCode;
    public SpriteRenderer spriteRenderer;

    // public Sprite Item1;
    // public Sprite Item2;
    // public Sprite Item3;
    // public Sprite Item4;
    // public Sprite Item5;
    // public Sprite Item6;
    // public Sprite Item7;
    // public Sprite Item8;
    // public Sprite Item9;
    public Sprite[] SampleImage;
    public AnimationClip[] animationClip;
    //public Animator animationOfSample;
    public Animator AnimationOfSample;



    
    // Start is called before the first frame update
    void Start()
    {
        InventoryDetail = GameObject.Find("inventory detail");
        //ItemCode = InventorySelectControl.CurrentItemCode;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        AnimationOfSample.SetInteger("ItemCode",ItemCode);
        spriteRenderer.sprite = SampleImage[ItemCode];
        
        //animationOfSample.Play("Item"+ItemCode.ToString()+"Analysis");
        //animationOfSample.clip = animationClip[ItemCode];
        if (InventorySelectControl.deleteAllBoxes == true)
        {
            Destroy(gameObject);
        }
      //  if (InventorySelectControl.OtherSelectedBox >=1 && MouseOver == false)
       // {

       //     selected = false;
      //      InventorySelectControl.OtherSelectedBox--;
            
      //  }
        if (InventorySelectControl.ItemCode != ItemCode)
        {
            animator.SetBool("selected", false);
            //animationOfSample.Stop();
            AnimationOfSample.SetBool("Selected",false);
        }
        else if (InventorySelectControl.ItemCode == ItemCode)
        {
            animator.SetBool("selected", true);
            //spriteRenderer.sprite = SampleImage[ItemCode];
            //InventoryDetail.SetActive(true);
            //animationOfSample.Play()
            AnimationOfSample.SetBool("Selected", true);

        }
    }


    void OnMouseOver()
    {
        animator.SetBool(AnimationBoolName, true);
        MouseOver = true;
        

    }
    void OnMouseExit()
    {
        animator.SetBool(AnimationBoolName, false);
        MouseOver = false;
    }

    void OnMouseDown()
    {
        //spriteRenderer.color = new Color(1, 1, 1, 1);

        // Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  pz.z = 0;
        animator.SetTrigger(AnimationTriggerName);
        //Instantiate(prefab, pz, Quaternion.identity);
        if (InventorySelectControl.ItemCode != ItemCode)
        {

            InventorySelectControl.ItemCode = ItemCode;
            animator.SetBool("selected", true);
            //selected = true;
            //InventorySelectControl.OtherSelectedBox++;
            InventoryDetail.SetActive(true);


            //deselect other boxes;
        }
        
        else if(InventorySelectControl.ItemCode == ItemCode)
        {
            animator.SetBool("selected", false);
            //selected = false;
            InventorySelectControl.ItemCode = 0;
            InventoryDetail.SetActive(false);
            //InventorySelectControl.OtherSelectedBox--;
        }


    }


    //void setItemCode(int a)
   // {   // you can't use start. But this is just as good.

    //    ItemCode = a;

   // }
}
