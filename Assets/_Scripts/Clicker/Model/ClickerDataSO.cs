using System;
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

    public void AddGear()
    {
        gearCount += gearPerClick;
    }

    public void RemoveGear(int gearToRemove)
    {
        gearCount -= gearToRemove;
    }

    public void AddGearPerSecond()
    {
        gearCount += gearPerSecond;
    }
}
