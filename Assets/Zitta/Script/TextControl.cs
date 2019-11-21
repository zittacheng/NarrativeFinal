using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour {
    [HideInInspector]
    public static TextControl Main;
    public TextUnit CurrentUnit;
    public List<TextUnit> Units;
    [Space]
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
        
    }

    public void LoadUnit(TextUnit TU)
    {
        if (!TU)
            return;
        TU.OnLoad();
        CurrentUnit = TU;
    }

    public void Choose(Choice C)
    {
        LoadUnit(GetUnit(C.Target));
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
}
