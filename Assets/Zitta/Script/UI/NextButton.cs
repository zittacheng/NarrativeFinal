using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour {
    public Image image;
    public Collider Col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TextControl.Main.NextButtonActive())
        {
            image.enabled = true;
            Col.enabled = true;
        }
        else
        {
            image.enabled = false;
            Col.enabled = false;
        }
    }

    public void OnMouseDown()
    {
        TextControl.Main.NextButtonProccess();
    }
}
