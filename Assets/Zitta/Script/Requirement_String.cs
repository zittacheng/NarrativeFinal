using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement_String : Requirement {
    public string Value;

    public override bool Pass()
    {
        return SaveControl.GetString(Key) == Value;
    }
}