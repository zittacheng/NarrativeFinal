using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableChange_String : VariableChange {
    public string Value;

    public override void Process()
    {
        SaveControl.SetString(Key, Value);
    }
}
