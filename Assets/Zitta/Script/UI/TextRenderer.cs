using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRenderer : MonoBehaviour {
    public TextMeshProUGUI TEXT;
    public TextMeshProUGUI AlterTEXT;
    public int Index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string s = TextControl.Main.GetText(Index, out bool PlayerSide, out bool Alter);
        if (Alter)
        {
            AlterTEXT.text = s;
            TEXT.text = "";
        }
        else
        {
            TEXT.text = s;
            AlterTEXT.text = "";
        }
    }
}
