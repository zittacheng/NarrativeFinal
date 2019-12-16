using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapController : MonoBehaviour
{
    [HideInInspector]public static int CurrentLocationCode = 1;
    [HideInInspector] public static int CurrentSelectLocationCode = 0;
    [HideInInspector] public static bool AbleToSelectDestination = false;
    public GameObject[] mapdots;
    public int[,] PlanetList;
    public static bool EnableButton = false;
    public  GameObject ConfirmButton;
    public TextMeshPro TextOnButton;
    // Start is called before the first frame update
    void Start()
    {
        PlanetList = new int[,] { { 0,0,0,0},{ 2,0,0,0},{5,3,6,1 },{ 2,6,4,0},{ 3,5,7,0},{ 2,4,0,0},{2,3,0,0 },{4,8,0,0 }, { 9,7,0,0},{ 8,10,11,0},{ 9,11,0,0},{ 9,10,0,0} };
    }

    // Update is called once per frame
    void Update()
    {
        if (AbleToSelectDestination == false)
        {
            TextOnButton.text = "Unable to select destination.";
            ConfirmButton.SetActive(false);
        }
        else
        {
            if (CurrentSelectLocationCode > 0)
            {
                int count = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (PlanetList[CurrentLocationCode, i] == CurrentSelectLocationCode)
                    {
                        EnableButton = true;
                        
                    }
                    else
                    {
                        count++;
                    }
                    // else if (EnableButton == false)
                    //{

                    //  }
                }
                if (count >= 4)
                {
                    EnableButton = false;
                }
            }

            if (EnableButton == true)
            {
                ConfirmButton.SetActive(true);
                TextOnButton.text = "Go";
            }
            else
            {
                ConfirmButton.SetActive(false);
                TextOnButton.text = "Invalid destination";
            }
        }
        
    }
}
