using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUnitAssign : MonoBehaviour {
    public TextUnit StartUnit;

    public void Awake()
    {
        TextControl.Main.StartUnit = StartUnit;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
