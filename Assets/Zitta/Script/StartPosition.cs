using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {
    public Vector3 Position;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
