using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEffect_DroidsBack : UnitEffect {

    public override void Effect()
    {
        base.Effect();
        FindObjectOfType<DroidButtonController>().animator.SetBool("Searching", false);
    }
}
