using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement_Planet : Requirement {
    public int Value;

    public override bool Pass()
    {
        return DriveControl.Main.NextPlanet == Value;
    }
}
