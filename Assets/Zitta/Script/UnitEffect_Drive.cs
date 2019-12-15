using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEffect_Drive : UnitEffect {
    public bool Land;
    public bool TakeOff;
    [Space]
    public bool Arrive;
    public bool Depart;

    public override void Effect()
    {
        base.Effect();
        if (Land)
            DriveControl.Main.Land();
        else if (TakeOff)
            DriveControl.Main.TakeOff();
        else if (Arrive)
            DriveControl.Main.Arrive();
        else if (Depart)
            DriveControl.Main.Depart();
    }
}
