using System;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private UpgradeListSO upgradeList;
    [SerializeField] private UpgradeListUI upgradeListUI;


    private void Start()
    {
        upgradeList.getUpgrade();
    }

    private void Awake()
    {
        upgradeListUI.OnUpgradeSlotBuy += BuyUpgrade;
    }

    private void Update()
    {
        checkIfUpgradeIsUnlock();
    }

    private void BuyUpgrade(BuildingUpgradeSO upgrade)
    {
        upgrade.BuyUpgrade();
    }

    private void checkIfUpgradeIsUnlock()
    {
        foreach (BuildingUpgradeSO upgrade in upgradeList.ListOfUpgrade)
        {
            if (upgrade.amountOfBuildingToUnlock == upgrade.buildingToUpgrade.amountOfBuilding && !upgrade.isUnlocked)
            {
                upgrade.unlockUpgrade();
                Debug.Log(upgrade.isUnlocked);
                upgradeListUI.updateSlotUI(upgradeListUI);
            }
            Debug.Log(upgrade.isUnlocked);
        }
    }
}
