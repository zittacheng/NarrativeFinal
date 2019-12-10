using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventChoice : MonoBehaviour {
    public TextUnit TargetUnit;
    public Requirement Req;
    public string Key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Active()
    {
        if (Req && !Req.Pass())
            return false;
        return true;
    }

    public TextUnit GetTarget()
    {
        return TargetUnit;
    }
}
