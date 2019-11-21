using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement_Int : Requirement {
    public Method Comparison;
    public int Value;

    public override bool Pass()
    {
        int a = SaveControl.GetInt(Key);
        if (Comparison == Method.Equal)
            return a == Value;
        else if (Comparison == Method.Greater)
            return a > Value;
        else if (Comparison == Method.Less)
            return a < Value;
        else if (Comparison == Method.NotEqual)
            return a != Value;
        else
            return false;
    }
}

public enum Method
{
    Greater,
    Less,
    Equal,
    NotEqual
}