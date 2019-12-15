using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEffect_AnimatorEvent : UnitEffect {
    public string Key;

    public override void Effect()
    {
        base.Effect();
        DriveControl.Main.AnimatorEvent(Key);
    }
}
