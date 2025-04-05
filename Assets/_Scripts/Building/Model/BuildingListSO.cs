using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingListSO", menuName = "Scriptable Objects/BuildingListSO")]
public class BuildingListSO : ScriptableObject
{
    [field: SerializeField]
    public List<BuildingSO> buildingList { get; set; }

    public float GetRPCBuildingMultiplier()
    {
        float totalMultiplier = 0f;
        foreach (var building in buildingList)
        {
            totalMultiplier += building.buildBuffs.gearPerClickBuff * building.amountOfBuilding;
        }
        return totalMultiplier;
    }

    public float GetRPSBuildingMultiplier()
    {
        float totalMultiplier = 0f;
        foreach (var building in buildingList)
        {
            totalMultiplier += building.buildBuffs.gearPerSecondBuff * building.amountOfBuilding;
        }
        return totalMultiplier;
    }

    public void addBuildingToList(BuildingSO building)
    {
        if(buildingList.Contains(building))
        {
            buildingList[buildingList.IndexOf(building)].amountOfBuilding++;
        }
        else
        {
            buildingList.Add(building);
            buildingList[buildingList.IndexOf(building)].amountOfBuilding = 1;
        }
    }

    public void removeBuildingFromList(BuildingSO buildingSO)
    {
        if (buildingList.Contains(buildingSO))
        {
            buildingList[buildingList.IndexOf(buildingSO)].amountOfBuilding--;
            if (buildingList[buildingList.IndexOf(buildingSO)].amountOfBuilding <= 0)
            {
                buildingList.Remove(buildingSO);
            }
        }
        else
        {
            Debug.Log("Building not found in the list");
        }
    }
}
