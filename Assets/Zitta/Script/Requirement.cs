using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement : MonoBehaviour {
    public string Key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool Pass()
    {
        return true;
    }
}
