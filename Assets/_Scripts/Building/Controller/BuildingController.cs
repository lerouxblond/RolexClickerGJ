using System;
using UnityEngine;
using UnityEngine.Events;

public class BuildingController : MonoBehaviour
{
    #region Data
    [field: SerializeField]
    public BuildingListSO buildingList { get; set; }

    #endregion

    #region UI
    [SerializeField] private BuildingListUI buildingListUI;

    #endregion
    #region Events
    public UnityAction OnBuildingBuy, OnBuildingSell;

    #endregion

    private void Awake()
    {
        buildingListUI.OnBuildingSlotBuy += BuyBuilding;
        buildingListUI.OnBuildingSlotSell += SellBuilding;
    }

    private void Start()
    {
        InitializeBuildingSlots();
        InitializeBuildingData();
    }

    private void Update()
    {
        checkIfBuildingIsUnlocked();
    }

    #region Building Methods
    public void BuyBuilding(BuildingSO building)
    {
        building.buyBuilding();
        UpdateBuildingSlots();
    }
    public void SellBuilding(BuildingSO building)
    {
        building.sellBuilding();
        UpdateBuildingSlots();
    }

    private void InitializeBuildingData()
    {
        foreach (var building in buildingList.buildingList)
        {
            if(building.originBuildingCost == 0)
                building.originBuildingCost = building.buildingCost;
        }
    }

    #endregion

    #region UI Methods
    public void InitializeBuildingSlots()
    {
        buildingListUI.InitializeBuildingSlots(buildingList);
    }
    public void UpdateBuildingSlots()
    {
        buildingListUI.UpdateBuildingSlots(buildingList);
    }
    #endregion

    #region Data methods
    private void checkIfBuildingIsUnlocked()
    {
        foreach (var building in buildingList.buildingList)
        {
            if (ClickerDataSO.Instance.gearCount >= building.buildingUnlockCost && !building.isUnlocked)
            {
                building.unlockBuilding();
                UpdateBuildingSlots();
            }
        }
    }

    #endregion
}
