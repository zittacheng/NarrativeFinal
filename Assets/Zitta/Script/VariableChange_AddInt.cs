using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableChange_AddInt : VariableChange {
    public int Value;

    public override void Process()
    {
        SaveControl.SetInt(Key, SaveControl.GetInt(Key) + Value);
    }
}
