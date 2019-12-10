using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLineScript : MonoBehaviour
{
    public Animator animator;
    public string AnimationBoolName;
    public int LineLinkedDotCode1;
    public int LineLinkedDotCode2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LineLinkedDotCode1 == MapController.CurrentLocationCode && LineLinkedDotCode2 == MapController.CurrentSelectLocationCode)
        {
            animator.SetBool(AnimationBoolName,true);
        }
        else if (LineLinkedDotCode2 == MapController.CurrentLocationCode && LineLinkedDotCode1 == MapController.CurrentSelectLocationCode)
        {
            animator.SetBool(AnimationBoolName, true);
        }
        else
        {
            animator.SetBool(AnimationBoolName, false);
        }
    }
}
