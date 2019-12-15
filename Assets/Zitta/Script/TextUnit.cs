using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUnit : MonoBehaviour {
    public string Key;
    public TextUnit NextUnit;
    public Requirement NextUnitReq;
    public UnitType UType;
    public float AddDelay;
    public float AddReadDelay;
    public bool AutoNext;
    public bool EventMode;
    public bool AlterFont;
    [Space]
    public List<TextBlock> Blocks;
    public List<Choice> Choices;
    public List<EventChoice> EventChoices;
    [HideInInspector] public string FinalText;
    [HideInInspector] public List<Choice> FinalChoices;
    [HideInInspector] public List<EventChoice> FinalEventChoices;
    [HideInInspector] public bool Loading;
    [HideInInspector] public int LoadIndex;
    [HideInInspector] public int RealIndex;
    [HideInInspector] public float CurrentDelay;
    [HideInInspector] public List<string> Commands;
    [HideInInspector] public List<Vector2Int> CommandRanges;
    [Space]
    public List<NextUnitOverride> Overrides;
    public List<VariableChange> Changes;
    public List<UnitEffect> Effects;

    public void Awake()
    {

    }

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
        LoadIndex = -1;
        FinalText = "";
        FinalChoices = new List<Choice>();
        FinalEventChoices = new List<EventChoice>();
        foreach (TextBlock TB in Blocks)
            if (TB.Active())
                FinalText += TB.Content;
        foreach (Choice C in Choices)
            if (C.Active())
                FinalChoices.Add(C);
        foreach (EventChoice EC in EventChoices)
            if (EC.Active())
                FinalEventChoices.Add(EC);
        foreach (VariableChange VC in Changes)
            VC.Process();
        CurrentDelay = GetDelay() * 0.25f;
        CommandCheck();
        IndexCheck();
        foreach (UnitEffect UE in Effects)
            UE.Effect();
        foreach (NextUnitOverride NUO in Overrides)
        {
            if (NUO.Active())
            {
                NextUnit = NUO.GetUnit();
                break;
            }
        }

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
        if (LoadIndex < 0)
            return;
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

    public string GetFinalText()
    {
        int a = -1;
        for (int i = CommandRanges.Count - 1; i >= 0; i--)
        {
            if (Commands[i] == "n")
                continue;
            a = i;
            break;
        }
        string TempText = FinalText;
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

    public void OnEnd()
    {
        foreach (UnitEffect UE in Effects)
            UE.EndEffect();
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

    public List<EventChoice> GetEventChoices()
    {
        return FinalEventChoices;
    }

    public EventChoice GetEventChoice(string Key)
    {
        for (int i = GetEventChoices().Count - 1; i >= 0; i--)
        {
            if (GetEventChoices()[i].Key == Key)
                return GetEventChoices()[i];
        }
        return null;
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
        Effects = new List<UnitEffect>();
        foreach (UnitEffect UE in GetComponentsInChildren<UnitEffect>())
            Effects.Add(UE);
        EventChoices = new List<EventChoice>();
        foreach (EventChoice EC in GetComponentsInChildren<EventChoice>())
            EventChoices.Add(EC);
        Overrides = new List<NextUnitOverride>();
        foreach (NextUnitOverride NUO in GetComponentsInChildren<NextUnitOverride>())
            Overrides.Add(NUO);
    }

    public void EditorNextUnit()
    {
        List<TextUnit> TU = new List<TextUnit>();
        foreach (TextUnit T in transform.parent.GetComponentsInChildren<TextUnit>())
            TU.Add(T);
        int i = TU.IndexOf(this);
        if (i < 0 || i == TU.Count - 1)
            return;
        NextUnit = TU[i + 1];
    }

    public TextUnit GetNextUnit()
    {
        if (NextUnitReq && !NextUnitReq.Pass())
            return null;
        return NextUnit;
    }

    public float GetDelay()
    {
        return TextControl.Main.DefaultDelay + AddDelay;
    }

    public float GetReadDelay()
    {
        return TextControl.Main.ReadDelay + AddReadDelay;
    }
}

public enum UnitType
{
    AI,
    Player,
}
