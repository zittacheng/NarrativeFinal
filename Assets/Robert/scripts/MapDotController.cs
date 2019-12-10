using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDotController : MonoBehaviour
{
    public int MapDotCode;
    public Animator animator;
    public string AnimationBoolName;
    public string PlanetName;
   // public string AnimationTriggerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MapController.CurrentLocationCode == MapDotCode)
        {
            animator.SetBool("Select", true);

        }
        else if (MapController.CurrentSelectLocationCode == MapDotCode)
        {
            animator.SetBool("Select", true);
            //InventoryDetail.SetActive(true);
        }
        else if (MapController.CurrentSelectLocationCode != MapDotCode)
        {
            animator.SetBool("Select", false);
        }
    }
    void OnMouseOver()
    {
        animator.SetBool(AnimationBoolName, true);
        //MouseOver = true;

    }
    void OnMouseExit()
    {
        animator.SetBool(AnimationBoolName, false);
        //MouseOver = false;
    }

    void OnMouseDown()
    {
        //spriteRenderer.color = new Color(1, 1, 1, 1);

        // Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  pz.z = 0;
        //animator.SetTrigger(AnimationTriggerName);
        //Instantiate(prefab, pz, Quaternion.identity);
        if (MapController.CurrentSelectLocationCode!=MapDotCode && MapController.CurrentLocationCode!=MapDotCode)
        {

            MapController.CurrentSelectLocationCode = MapDotCode;
            animator.SetBool("Select", true);
            //selected = true;
            //InventorySelectControl.OtherSelectedBox++;
            //InventoryDetail.SetActive(true);


            //deselect other boxes;
        }

        else if (MapController.CurrentSelectLocationCode == MapDotCode && MapController.CurrentLocationCode != MapDotCode)
        {
            animator.SetBool("Select", false);
            //selected = false;
            MapController.CurrentSelectLocationCode = 0;
           // InventoryDetail.SetActive(false);
            //InventorySelectControl.OtherSelectedBox--;
        }


    }

}
