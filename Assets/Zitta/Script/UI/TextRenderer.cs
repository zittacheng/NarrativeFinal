using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRenderer : MonoBehaviour {
    public TextMeshProUGUI TEXT;
    public TextMeshProUGUI AlterTEXT;
    public TextMeshProUGUI TestTEXT;
    public UnitType TargetType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        TestTEXT.text = TextControl.Main.GetFinalText(TargetType);
        string s = TextControl.Main.GetText(TargetType, out bool Alter);
        if (Alter)
        {
            if (TargetType == UnitType.Player && s.Length > 0)
                AlterTEXT.text = /*"- " + */s;
            else
                AlterTEXT.text = s;
            TEXT.text = "";
        }
        else
        {
            if (TargetType == UnitType.Player && s.Length > 0)
                TEXT.text = /*"- " + */s;
            else
                TEXT.text = s;
            AlterTEXT.text = "";
        }
    }

    public int GetLineCount()
    {
        return TestTEXT.textInfo.lineCount;
    }
}
