using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLogReaderController : MonoBehaviour

   
{
    public static int ItemCode = 0;
    public GameObject prefab;
    [HideInInspector]public static bool reading = false;
    public Animator animator;
    private float targetTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reading == true)
        {

            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                animator.SetBool("Insert",false);
                reading = false;
                targetTime = 5.0f;
            }
        }
    }

    void OnMouseDown()
    {
        // spriteRenderer.color = new Color(1, 1, 1, 1);

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        if (ItemCode != 0 && ItemCode != 4&& reading == false)
        {
            var a = Instantiate(prefab, pz, Quaternion.identity);
            animator.SetTrigger("Take");
            a.GetComponent<ItemController>().FromAudioReader = true;
            a.GetComponent<ItemController>().ItemCode = ItemCode;
            ItemCode = 0;
        }

        //GameObject.Find("Item(1)").GetComponent<ItemController>().

    }
}
