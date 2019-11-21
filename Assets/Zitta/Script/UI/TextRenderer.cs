using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRenderer : MonoBehaviour {
    public TextMeshProUGUI TEXT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TextControl.Main.GetCurrentUnit())
            TEXT.text = TextControl.Main.GetCurrentUnit().GetText();
        else
            TEXT.text = "";
    }
}
