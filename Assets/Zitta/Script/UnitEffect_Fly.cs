using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEffect_Fly : UnitEffect {
    public bool Land;
    public bool TakeOff;

    public override void Effect()
    {
        base.Effect();
        if (Land)
            DriveControl.Main.Land();
        else if (TakeOff)
            DriveControl.Main.TakeOff();
    }
}
