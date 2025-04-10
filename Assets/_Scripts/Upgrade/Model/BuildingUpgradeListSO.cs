using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingUpgradeListSO", menuName = "Scriptable Objects/BuildingUpgradeListSO")]
public class UpgradeListSO : ScriptableObject
{
    [field: SerializeField]
    public List<BuildingUpgradeSO> ListOfUpgrade { get; set; }

    public void getUpgrade()
    {
        ListOfUpgrade = new List<BuildingUpgradeSO>(Resources.LoadAll<BuildingUpgradeSO>("PlayerGearData/Upgrades/"));
    }

    public void RemoveFromUpgradeList(BuildingUpgradeSO upgrade)
    {
        if (ListOfUpgrade.Contains(upgrade))
        {
            ListOfUpgrade.Remove(upgrade);
        }
        else
        {
            Debug.Log("Upgrade not found in the list");
        }
    }
}
