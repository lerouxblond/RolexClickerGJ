using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.Events;

public class BuildingListUI : MonoBehaviour
{
    [SerializeField] private Transform contentTransform;
    [SerializeField] private BuildingSlotUI buildingSlotPrefab;

    public UnityAction<BuildingSO> OnBuildingSlotBuy;
    public UnityAction<BuildingSO> OnBuildingSlotSell;


    public void InitializeBuildingSlots(BuildingListSO buildingList)
    {
        foreach (Transform child in contentTransform)
        {
            Destroy(child.gameObject);
        }
        foreach (BuildingSO buildingSO in buildingList.buildingList)
        {
            BuildingSlotUI buildingSlot = Instantiate(buildingSlotPrefab, contentTransform);
            buildingSlot.Initialize(buildingSO);
            buildingSlot.OnBuildingSlotBuy += OnBuildingSlotBuy;
            buildingSlot.OnBuildingSlotSell += OnBuildingSlotSell;
        }
    }

    public void UpdateBuildingSlots(BuildingListSO buildingList)
    {
        foreach (Transform child in contentTransform)
        {
            BuildingSlotUI buildingSlot = child.GetComponent<BuildingSlotUI>();
            if (buildingSlot != null)
            {
                buildingSlot.UpdateBuildingCost();
                buildingSlot.UpdateBuildingPossessed();
            }
        }
    }
}
