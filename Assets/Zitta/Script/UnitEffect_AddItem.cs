using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEffect_AddItem : UnitEffect {
    public int Value;

    public override void Effect()
    {
        base.Effect();
        FindObjectOfType<InventorySelectControl>().AddItem(Value);
    }
}
