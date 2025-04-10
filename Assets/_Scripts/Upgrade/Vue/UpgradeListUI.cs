using System;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeListUI : MonoBehaviour
{
    [SerializeField] private Transform contentTransform;
    [SerializeField] private UpgradeSlotUI upgradeSlotPrefab;
    [SerializeField] private UpgradeListSO upgradeList;

    public UnityAction<BuildingUpgradeSO> OnUpgradeSlotBuy;


    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        foreach (Transform child in contentTransform)
        {
            Destroy(child.gameObject);
        }
        foreach (BuildingUpgradeSO upgradeSO in upgradeList.ListOfUpgrade)
        {
            UpgradeSlotUI upgradeSlot = Instantiate(upgradeSlotPrefab, contentTransform);
            upgradeSlot.Initialize(upgradeSO);
            upgradeSlot.OnUpgradeSlotClick += OnUpgradeSlotBuy;
            upgradeSO.onUpgradeUnlock += upgradeSlot.ShowUpgradeSlot;
            upgradeSO.onUpgradeBuy += removeUpgradeFromList;
        }
    }

    private void removeUpgradeFromList(BuildingUpgradeSO buildingUpgrade)
    {
        foreach (Transform child in contentTransform)
        {
            UpgradeSlotUI upgradeSlot = child.GetComponent<UpgradeSlotUI>();
            if (upgradeSlot != null && upgradeSlot.data == buildingUpgrade)
            {
                upgradeList.RemoveFromUpgradeList(buildingUpgrade);
                Destroy(child.gameObject);
                break;
            }
        }
    }

    public void updateSlotUI(UpgradeListUI upgradeListUI)
    {
        foreach (Transform child in contentTransform)
        {
            Destroy(child.gameObject);
        }
        foreach (BuildingUpgradeSO upgradeSO in upgradeList.ListOfUpgrade)
        {
            UpgradeSlotUI upgradeSlot = Instantiate(upgradeSlotPrefab, contentTransform);
            upgradeSlot.Initialize(upgradeSO);
            upgradeSlot.OnUpgradeSlotClick += OnUpgradeSlotBuy;
            upgradeSO.onUpgradeUnlock += upgradeSlot.ShowUpgradeSlot;
            upgradeSO.onUpgradeBuy += removeUpgradeFromList;
        }
    }
}
