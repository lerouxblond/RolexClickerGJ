using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ClickerDataSO", menuName = "Scriptable Objects/ClickerDataSO")]
public class ClickerDataSO : ScriptableObject
{
    private static ClickerDataSO _instance;

    public static ClickerDataSO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<ClickerDataSO>("PlayerGearData/PlayerGearData");
                if (_instance == null)
                    Debug.Log("ClickerDataSO not found in Resources!");
            }
            return _instance;
        }
    }


    [field: Header("Clicker Data")]
    [field: SerializeField]
    public float gearCount { get; set; } = 0.0f;
    [field: SerializeField]
    public float gearPerSecond { get; set; } = 0.0f;
    [field: SerializeField]
    public float gearPerClick { get; set; } = 1.0f;

    [field: Header("Possessed Building Data")]
    [field: SerializeField]
    public BuildingListSO possesedBuilding { get; set; }

    [field: Header("Workshop Name")]
    [field: SerializeField]
    public string workshopName { get; set; }
    private const string DefaultWorkshopName = "Workshop";

    public UnityAction<string> OnWorkshopNameChange;

    private string checkIfEmptyWorkshopName(string name)
    {
        return string.IsNullOrWhiteSpace(workshopName) ? DefaultWorkshopName : name;
    }

    public string changeName(string name)
    {
        workshopName = checkIfEmptyWorkshopName(name);
        Debug.Log(workshopName);
        OnWorkshopNameChange?.Invoke(workshopName);
        return workshopName;
    }

    public void AddGear(float gearToAdd)
    {
        gearCount += gearToAdd;
    }

    public void RemoveGear(float gearToRemove)
    {
        gearCount -= gearToRemove;
        if(gearCount < 0)
        {
            gearCount = 0;
        }
    }

    public void AddGearPerSecond()
    {
        gearCount += gearPerSecond;
    }

    public float getGearRatePerSecond()
    {
        // return the rate of gear per second depending on the building multiplier
        
        return possesedBuilding.GetRPSBuildingMultiplier();
    }

    public float getGearRatePerClick()
    {
        // return the rate of gear per click depending on the building multiplier
        
        return possesedBuilding.GetRPCBuildingMultiplier();
    }

    public void setGearPerClick()
    {
        gearPerClick = 1.0f;
        gearPerClick += getGearRatePerClick();
    }

    public void setGearPerSecond()
    {
        gearPerSecond = 0.0f;
        gearPerSecond += getGearRatePerSecond();
    }

}
