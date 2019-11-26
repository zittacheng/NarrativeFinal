using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRenderer : MonoBehaviour {
    public TextMeshProUGUI TEXT;
    public int Index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TEXT.text = TextControl.Main.GetText(Index, out bool PlayerSide);
        if (TEXT.text == "")
            return;
        if (PlayerSide)
        {
            TEXT.alignment = TextAlignmentOptions.MidlineRight;
            TEXT.text = TEXT.text + " -";
        }
        else
        {
            TEXT.alignment = TextAlignmentOptions.MidlineLeft;
            TEXT.text = "- " + TEXT.text;
        }
    }
}
