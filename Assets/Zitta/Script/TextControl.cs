using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextControl : MonoBehaviour {
    [HideInInspector]
    public static TextControl Main;
    public TextUnit CurrentUnit;
    public TextUnit NextUnit;
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
    public TMP_FontAsset DefaultFont;

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
            CurrentDelay -= Time.deltaTime;
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

    public string GetText(int Index, out bool PlayerSide, out bool AlterFont)
    {
        AlterFont = false;
        int a = PastUnits.Count - 1 - Index;
        if (a < 0)
        {
            PlayerSide = false;
            return "";
        }
        TextUnit TU = PastUnits[a];
        PlayerSide = TU.PlayerSide;
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

    public void TriggerText(string Value)
    {

    }

    public void TakeOff()
    {

    }
}
