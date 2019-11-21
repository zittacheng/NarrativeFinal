using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement_Group : Requirement {
    public List<Requirement> Required;
    public List<Requirement> Avoided;

    public override bool Pass()
    {
        foreach (Requirement R in Required)
            if (!R.Pass())
                return false;
        foreach (Requirement R in Avoided)
            if (R.Pass())
                return false;
        return true;
    }
}
