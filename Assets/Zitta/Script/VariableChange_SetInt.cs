using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableChange_SetInt : VariableChange {
    public int Value;

    public override void Process()
    {
        SaveControl.SetInt(Key, Value);
    }
}
