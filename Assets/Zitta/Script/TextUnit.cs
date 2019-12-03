using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUnit : MonoBehaviour {
    public string Key;
    public TextUnit NextUnit;
    public Requirement NextUnitReq;
    public float Delay;
    public float AddReadDelay;
    public bool PlayerSide;
    [Space]
    public List<TextBlock> Blocks;
    public List<Choice> Choices;
    [HideInInspector] public string FinalText;
    [HideInInspector] public List<Choice> FinalChoices;
    [HideInInspector] public bool Loading;
    public int LoadIndex;
    public int RealIndex;
    [HideInInspector] public float CurrentDelay;
    [Space]
    public List<string> Commands;
    public List<Vector2Int> CommandRanges;
    [Space]
    public List<VariableChange> Changes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Loading)
        {
            if (CurrentDelay > 0)
            {
                CurrentDelay -= Time.deltaTime;
            }
            else
            {
                CurrentDelay = GetReadDelay();
                LoadIndex++;
                IndexCheck();
            }
        }
    }

    public void OnLoad()
    {
        Loading = true;
        LoadIndex = 0;
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
        CurrentDelay = GetReadDelay();
        CommandCheck();
        IndexCheck();
    }

    public void CommandCheck()
    {
        Commands = new List<string>();
        CommandRanges = new List<Vector2Int>();
        int t = 0;
        while (FinalText.IndexOf("*", t) >= 0)
        {
            Vector2Int v = new Vector2Int();
            int a = FinalText.IndexOf("*", t);
            t = a + 1;
            int b = FinalText.IndexOf("*", t);
            if (b < 0)
                break;
            t = b + 1;
            v = new Vector2Int(a, b);
            string c = FinalText.Substring(a + 1, b - a - 1);
            Commands.Add(c);
            CommandRanges.Add(v);
        }
    }

    public void IndexCheck()
    {
        for (int i = CommandRanges.Count - 1; i >= 0; i--)
        {
            if (LoadIndex == CommandRanges[i].x)
            {
                LoadIndex = CommandRanges[i].y;
                ExeCommand(Commands[i]);
                IndexCheck();
            }
        }
        if (LoadIndex >= FinalText.Length)
            Loading = false;
    }

    public void ExeCommand(string Value)
    {
        if (Value == "n")
        {
            return;
        }
        else if (Value.IndexOf("D") == 0 && float.TryParse(Value.Substring(1), out float r))
        {
            CurrentDelay = r * GetReadDelay();
        }
    }

    public string GetText()
    {
        RealIndex = LoadIndex;
        if (RealIndex >= FinalText.Length)
            RealIndex = FinalText.Length - 1;
        int a = -1;
        for (int i = CommandRanges.Count - 1; i >= 0; i--)
        {
            if (RealIndex >= CommandRanges[i].y)
            {
                if (Commands[i] == "n")
                    continue;
                a = i;
                break;
            }
        }
        string TempText = FinalText.Substring(0, RealIndex + 1);
        if (a >= 0)
        {
            for (int i = a; i >= 0; i--)
            {
                if (Commands[i] == "n")
                    continue;
                TempText = TempText.Substring(0, CommandRanges[i].x) + TempText.Substring(CommandRanges[i].y + 1);
            }
        }
        TempText = TempText.Replace(oldValue: "*n*", newValue: "\n");
        return TempText;
    }

    public List<Choice> GetChoices()
    {
        return FinalChoices;
    }

    public Choice GetChoice(int Index)
    {
        if (GetChoices().Count <= Index)
            return null;
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

    public TextUnit GetNextUnit()
    {
        if (NextUnitReq && !NextUnitReq.Pass())
            return null;
        return NextUnit;
    }

    public float GetReadDelay()
    {
        return TextControl.Main.ReadDelay + AddReadDelay;
    }
}
