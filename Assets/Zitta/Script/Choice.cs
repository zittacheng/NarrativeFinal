using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour {
    [TextArea]
    public string Content;
    public string Target;
    public TextUnit TargetUnit;
    public Requirement Req;

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
        if (TargetUnit)
            return TargetUnit;
        return TextControl.Main.GetUnit(Target);
    }
}
