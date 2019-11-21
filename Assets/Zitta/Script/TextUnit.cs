using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUnit : MonoBehaviour {
    public string Key;
    [Space]
    public List<TextBlock> Blocks;
    public List<Choice> Choices;
    [HideInInspector]
    public string FinalText;
    [HideInInspector]
    public List<Choice> FinalChoices;
    [Space]
    public List<VariableChange> Changes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoad()
    {
        FinalText = "";
        FinalChoices = new List<Choice>();
        foreach (TextBlock TB in Blocks)
            if (TB.Active())
                FinalText += TB.Content;
        foreach (Choice C in Choices)
            if (C.Active())
                FinalChoices.Add(C);
        foreach (VariableChange VC in Changes)
            VC.Process();
    }

    public string GetText()
    {
        return FinalText;
    }

    public List<Choice> GetChoices()
    {
        return FinalChoices;
    }

    public Choice GetChoice(int Index)
    {
        return GetChoices()[Index];
    }

    public void EditorAssign()
    {
        Blocks = new List<TextBlock>();
        foreach (TextBlock TB in GetComponentsInChildren<TextBlock>())
            Blocks.Add(TB);
        Choices = new List<Choice>();
        foreach (Choice C in GetComponentsInChildren<Choice>())
            Choices.Add(C);
        Changes = new List<VariableChange>();
        foreach (VariableChange VC in GetComponentsInChildren<VariableChange>())
            Changes.Add(VC);
    }
}
