using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextUnitOverride : MonoBehaviour {
    public TextUnit Unit;
    public Requirement Req;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TextUnit GetUnit()
    {
        return Unit;
    }

    public bool Active()
    {
        if (Req)
            return Req.Pass();
        return true;
    }
}
