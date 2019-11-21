using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceRenderer : MonoBehaviour {
    public TextMeshProUGUI TEXT;
    public int Index;
    [HideInInspector]
    public Choice TargetChoice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TextControl.Main.GetCurrentUnit() && TextControl.Main.GetCurrentUnit().GetChoices().Count > Index)
            TargetChoice = TextControl.Main.GetCurrentUnit().GetChoice(Index);
        else
            TargetChoice = null;

        if (TargetChoice)
            TEXT.text = TargetChoice.Content;
        else
            TEXT.text = "";
    }

    public void OnMouseDown()
    {
        if (!TargetChoice)
            return;
        TextControl.Main.Choose(TargetChoice);
    }
}
