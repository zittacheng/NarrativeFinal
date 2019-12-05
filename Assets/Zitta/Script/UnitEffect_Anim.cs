using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEffect_Anim : UnitEffect {
    public Animator Anim;
    public string Key;

    public override void Effect()
    {
        base.Effect();
        Anim.SetTrigger(Key);
    }
}
