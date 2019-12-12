using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour {
    public Animator BGAnim;
    public float LandDelay;
    public float TakeOffDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Land()
    {
        StartCoroutine("LandIE");
    }

    public IEnumerator LandIE()
    {
        DriveControl.Main.JumpLand();
        yield return new WaitForSeconds(LandDelay);
        BGAnim.SetTrigger("In");
    }

    public void TakeOff()
    {
        StartCoroutine("TakeOffIE");
    }

    public IEnumerator TakeOffIE()
    {
        BGAnim.SetTrigger("Out");
        yield return new WaitForSeconds(TakeOffDelay);
        DriveControl.Main.JumpOff();
    }
}
