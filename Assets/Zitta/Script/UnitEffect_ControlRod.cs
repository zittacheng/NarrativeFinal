using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEffect_ControlRod : UnitEffect {
    public bool Land;
    public bool TakeOff;

    public override void Effect()
    {
        base.Effect();
        if (Land)
            LaunchButtonController.EnableLanding = true;
        else if (TakeOff)
            LaunchButtonController.EnableLaunch = true;
    }
}
