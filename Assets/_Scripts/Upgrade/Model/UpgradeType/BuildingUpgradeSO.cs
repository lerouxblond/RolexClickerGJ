using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "BuildingUpgradeSO", menuName = "Scriptable Objects/BuildingUpgradeSO")]
public class BuildingUpgradeSO : UpradeSO
{
    [field: SerializeField]
    public int upgradeCost { get; set; }
    [field: SerializeField]
    public bool asBeenBuy { get; set; }
    [field: SerializeField]
    public float amountOfBuildingToUnlock { get; set; }
    [field: SerializeField]
    public bool isUnlocked { get; set; }
    [field: SerializeField]
    public BuildingSO buildingToUpgrade { get; set; }

    public UnityAction<BuildingUpgradeSO> onUpgradeBuy;
    public UnityAction<bool> onUpgradeUnlock;

    [field: SerializeField]
    public BuildingUpgrade buildUpgradeBuff { get; set; } = new BuildingUpgrade(1.0f, 1.0f);

    public void BuyUpgrade()
    {
        if(ClickerDataSO.Instance.gearCount >= upgradeCost)
        {
            ClickerDataSO.Instance.gearCount -= upgradeCost;
            upgradeBuildingStats();
            asBeenBuy = true;
            onUpgradeBuy?.Invoke(this);
        }
        else
        {
            Debug.Log("Not enough gear to buy upgrade");
        }
    }

    private void upgradeBuildingStats()
    {
        buildingToUpgrade.buildBuffs = buildingToUpgrade.buildBuffs.gearPerClickBuffMult(buildUpgradeBuff.gearPerClickMultiplier);
        buildingToUpgrade.buildBuffs = buildingToUpgrade.buildBuffs.gearPerSecondBuffMult(buildUpgradeBuff.gearPerSecondMultiplier);
        ClickerDataSO.Instance.setGearPerClick();
        ClickerDataSO.Instance.setGearPerSecond();
    }

    public void unlockUpgrade()
    {
        isUnlocked = true;
        onUpgradeUnlock?.Invoke(isUnlocked);
    }
}

[Serializable]
public struct BuildingUpgrade
{
    public float gearPerClickMultiplier;
    public float gearPerSecondMultiplier;

    public BuildingUpgrade(float gearPerClickMultiplier, float gearPerSecondMultiplier)
    {
        this.gearPerClickMultiplier = gearPerClickMultiplier;
        this.gearPerSecondMultiplier = gearPerSecondMultiplier;
    }
}
