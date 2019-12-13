using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveControl : MonoBehaviour {
    [HideInInspector]
    public static DriveControl Main;
    public Animator JumpAnim;
    [Space]
    public List<BackgroundControl> Planets;
    public int NextPlanet;

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
        BackgroundControl BGC = Planets[NextPlanet];
        BGC.Land();
    }

    public void TakeOff()
    {
        BackgroundControl BGC = Planets[NextPlanet];
        BGC.TakeOff();
    }

    public void SetNextPlanet(int NextIndex)
    {
        NextPlanet = NextIndex;
    }

    public void JumpLand()
    {
        JumpAnim.SetTrigger("Out");
    }

    public void JumpOff()
    {
        JumpAnim.SetTrigger("In");
    }
}
