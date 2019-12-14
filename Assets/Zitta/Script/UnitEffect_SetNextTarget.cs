using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEffect_SetNextTarget : UnitEffect {
    public List<int> PlanetIndex;
    public List<TextUnit> Units;

    public override void Effect()
    {
        base.Effect();
        for (int i = 0; i < PlanetIndex.Count; i++)
        {
            if (PlanetIndex[i] == DriveControl.Main.NextPlanet)
            {
                GetComponent<TextUnit>().NextUnit = Units[i];
                break;
            }
        }
    }
}
