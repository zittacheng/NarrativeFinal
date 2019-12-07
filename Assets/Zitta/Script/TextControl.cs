using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextControl : MonoBehaviour {
    [HideInInspector]
    public static TextControl Main;
    public TextUnit CurrentUnit;
    public TextUnit NextUnit;
    public TextUnit AIUnit;
    public TextUnit PlayerUnit;
    public float CurrentDelay;
    public bool ChoiceActive;
    public bool NextActive;
    public List<TextUnit> PastUnits;
    [Space]
    public List<TextUnit> Units;
    public TextUnit StartUnit;
    public float DefaultDelay;
    public float ReadDelay;
    [Space]
    public Animator ChoiceBarAnim;
    public Animator PlayerAnim;
    public Animator AIAnim;

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
        if (!GetCurrentUnit() || !GetCurrentUnit().Loading)
        {
            CurrentDelay -= Time.deltaTime;
            PlayerAnim.SetBool("Active", false);
            AIAnim.SetBool("Active", false);
        }
        else
        {
            if (GetCurrentUnit().UType == UnitType.AI)
            {
                PlayerAnim.SetBool("Active", false);
                AIAnim.SetBool("Active", true);
            }
            else if (GetCurrentUnit().UType == UnitType.Player)
            {
                PlayerAnim.SetBool("Active", true);
                AIAnim.SetBool("Active", false);
            }
        }
        if (CurrentDelay <= 0 && !HaveChoice() && GetCurrentUnit())
        {
            if (GetCurrentUnit().GetNextUnit())
            {
                if (GetCurrentUnit().AutoNext)
                    LoadUnit(GetCurrentUnit().GetNextUnit());
                else
                    NextActive = true;
            }
            else if (GetCurrentUnit().GetChoices().Count > 0)
                ChoiceActive = true;
        }

        if (ChoiceBarAnim)
            ChoiceBarAnim.SetBool("Active", HaveChoice());
    }

    public void LoadUnit(TextUnit TU)
    {
        if (!TU)
            return;

        TU.OnLoad();
        NextActive = false;
        ChoiceActive = false;
        CurrentUnit = TU;
        NextUnit = TU.GetNextUnit();
        CurrentDelay = TU.GetDelay();
        PastUnits.Add(TU);

        if (TU.UType == UnitType.Player)
            PlayerUnit = TU;
        else
        {
            AIUnit = TU;
            PlayerUnit = null;
        }
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

    public TextUnit GetUnit(UnitType TargetType)
    {
        if (TargetType == UnitType.AI)
            return AIUnit;
        else if (TargetType == UnitType.Player)
            return PlayerUnit;
        return null;
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

    public string GetText(UnitType TargetType, out bool AlterFont)
    {
        AlterFont = false;
        if (!GetUnit(TargetType))
            return "";
        TextUnit TU = GetUnit(TargetType);
        AlterFont = TU.AlterFont;
        return TU.GetText();
    }

    public bool HaveChoice()
    {
        return ChoiceActive;
    }

    public string GetChoice(int Index)
    {
        if (HaveChoice() && GetCurrentUnit().GetChoice(Index))
            return GetCurrentUnit().GetChoice(Index).Content;
        else
            return "";
    }

    public void Choose(int Index)
    {
        ChooseChoice(GetCurrentUnit().GetChoice(Index));
    }

    public void NextButtonProccess()
    {
        if (GetCurrentUnit() && GetCurrentUnit().GetNextUnit())
            LoadUnit(GetCurrentUnit().GetNextUnit());
    }

    public bool NextButtonActive()
    {
        return NextActive;
    }

    public bool PlayerUnitActive()
    {
        return PlayerUnit;
    }
}
