using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour {
    [HideInInspector]
    public static TextControl Main;
    public TextUnit CurrentUnit;
    public TextUnit NextUnit;
    public float CurrentDelay;
    public bool ChoiceActive;
    public List<TextUnit> PastUnits;
    [Space]
    public List<TextUnit> Units;
    public TextUnit StartUnit;

    public void Awake()
    {
        Main = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (StartUnit)
            LoadUnit(StartUnit);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDelay -= Time.deltaTime;
        if (CurrentDelay <= 0 && !HaveChoice() && GetCurrentUnit())
        {
            if (GetCurrentUnit().GetNextUnit())
                LoadUnit(GetCurrentUnit().GetNextUnit());
            else if (GetCurrentUnit().GetChoices().Count > 0)
                ChoiceActive = true;
        }
    }

    public void LoadUnit(TextUnit TU)
    {
        if (!TU)
            return;
        TU.OnLoad();
        ChoiceActive = false;
        CurrentUnit = TU;
        NextUnit = TU.GetNextUnit();
        CurrentDelay = TU.Delay;
        PastUnits.Add(TU);
    }

    public TextUnit GetUnit(string Key)
    {
        foreach (TextUnit TU in Units)
            if (TU.Key == Key)
                return TU;
        return null;
    }

    public TextUnit GetCurrentUnit()
    {
        return CurrentUnit;
    }

    public void EditorAssign()
    {
        Units = new List<TextUnit>();
        foreach (TextUnit TU in GetComponentsInChildren<TextUnit>())
            Units.Add(TU);
    }

    public void ChooseChoice(Choice C)
    {
        LoadUnit(C.GetTarget());
    }

    //很重要
    //Return第Index项对话内容
    //(当前对话Index为0，上一个对话Index为1，再上一个Index为2...)
    //(输出的Bool代表是否Return的对话是玩家角色说出的)
    //
    public string GetText(int Index, out bool PlayerSide)
    {
        int a = PastUnits.Count - 1 - Index;
        if (a < 0)
        {
            PlayerSide = false;
            return "";
        }
        TextUnit TU = PastUnits[a];
        PlayerSide = TU.PlayerSide;
        return TU.FinalText;
    }

    //也很重要
    //Return当前是否需要玩家选择对话选项
    //
    public bool HaveChoice()
    {
        return ChoiceActive;
    }

    //同样重要
    //Return第Index项对话选项里的字符串
    //
    public string GetChoice(int Index)
    {
        if (HaveChoice() && GetCurrentUnit().GetChoice(Index))
            return GetCurrentUnit().GetChoice(Index).Content;
        else
            return "";
    }

    //也同样重要
    //选择第Index项对话选项
    //
    public void Choose(int Index)
    {
        ChooseChoice(GetCurrentUnit().GetChoice(Index));
    }
}
