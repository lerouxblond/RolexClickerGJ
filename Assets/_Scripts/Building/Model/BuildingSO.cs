using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "BuildingSO", menuName = "Scriptable Objects/BuildingSO")]
public class BuildingSO : ScriptableObject
{
    #region Building UI profile
    [field: Header("Building UI Profile")]
    [field: SerializeField]
    public string buildingName { get; private set; }

    [field: SerializeField, TextArea]
    public string buildingDescription { get; private set; }

    [field: SerializeField]
    public Sprite buildingIcon { get; private set; }

    #endregion

    #region Building Data
    [field: Header("Building Data")]

    [field: SerializeField]
    public float buildingCost { get; set; }
    public float originBuildingCost { get; set; }
    private const float BUILDINGCOSTMULTIPLIER = 1.1f;
    [field: SerializeField]
    public int amountOfBuilding { get; set; }

    [field: SerializeField]
    public float buildingUnlockCost { get; set; } = 0.0f;

    [field: SerializeField]
    public bool isUnlocked { get; set; } = false;


    #endregion
    #region Events
    public UnityAction<bool> OnBuildingUnlock;
    public UnityAction OnBuildingBuy;
    public UnityAction OnBuildingSell;
    #endregion

    [field: SerializeField]
    [field: Header("Building Buffs")]
    public BuildingBuffs buildBuffs { get; set; }

    // Later update, this will be a list of building upgrades 


    private float addBuildingCost()
    {
        return (BUILDINGCOSTMULTIPLIER * amountOfBuilding);
    }
    private float subBuildingCost()
    {
        return (BUILDINGCOSTMULTIPLIER * amountOfBuilding);
    }

    public void addBuilding()
    {
        buildingCost += addBuildingCost();
    }

    public void buyBuilding()
    {
        if (ClickerDataSO.Instance.gearCount >= buildingCost)
        {
            ClickerDataSO.Instance.possesedBuilding.addBuildingToList(this);
            addBuilding();
            ClickerDataSO.Instance.RemoveGear(buildingCost);
            ClickerDataSO.Instance.setGearPerClick();
            ClickerDataSO.Instance.setGearPerSecond();
            OnBuildingBuy?.Invoke();
        }
        else
        {
            Debug.Log("Not enough gear to buy building");
        }
    }
    public void sellBuilding()
    {
        if (amountOfBuilding > 0)
        {
            ClickerDataSO.Instance.possesedBuilding.removeBuildingFromList(this);
            removeBuilding();
            ClickerDataSO.Instance.AddGear(buildingCost);
            ClickerDataSO.Instance.setGearPerClick();
            ClickerDataSO.Instance.setGearPerSecond();
            OnBuildingSell?.Invoke();
        }
        else
        {
            Debug.Log("No building to sell");
        }
    }

    public void removeBuilding()
    {
        if (amountOfBuilding == 0 || buildingCost < originBuildingCost)
            buildingCost = originBuildingCost;
        else
            buildingCost -= subBuildingCost();
    }

    public void unlockBuilding()
    {
        isUnlocked = true;
        OnBuildingUnlock?.Invoke(isUnlocked);
    }
}

[Serializable]
public struct BuildingBuffs
{
    public float gearPerClickBuff;
    public float gearPerSecondBuff;

    public BuildingBuffs(float gearPerClickBuff, float gearPerSecondBuff)
    {
        this.gearPerClickBuff = gearPerClickBuff;
        this.gearPerSecondBuff = gearPerSecondBuff;
    }

    public BuildingBuffs gearPerClickBuffMult(float gearPerClickBuff)
    {
        return new BuildingBuffs
        {
            gearPerClickBuff = this.gearPerClickBuff * gearPerClickBuff,
            gearPerSecondBuff = this.gearPerSecondBuff
        };
    }
    public BuildingBuffs gearPerSecondBuffMult(float gearPerSecondBuff)
    {
        return new BuildingBuffs
        {
            gearPerClickBuff = this.gearPerClickBuff,
            gearPerSecondBuff = this.gearPerSecondBuff * gearPerSecondBuff
        };
    }
}