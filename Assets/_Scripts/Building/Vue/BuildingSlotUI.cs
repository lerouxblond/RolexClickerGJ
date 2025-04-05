using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class BuildingSlotUI : MonoBehaviour, IPointerClickHandler
{
    #region Properties
    [Header("Building Slot UI")]
    [SerializeField] private Image buildingIcon;
    [SerializeField] private TMP_Text buildingNameTXT;
    [SerializeField] private TMP_Text buildingCostTXT;
    [SerializeField] private TMP_Text buildingPossessedTXT;

    [Header("Building Data")]
    private BuildingSO buildingSO;

    #endregion

    #region Events
    public UnityAction<BuildingSO> OnBuildingSlotBuy;
    public UnityAction<BuildingSO> OnBuildingSlotSell;

    #endregion
    public void Initialize(BuildingSO buildingSO)
    {
        this.buildingSO = buildingSO;
        buildingIcon.sprite = buildingSO.buildingIcon;
        buildingNameTXT.text = buildingSO.buildingName;
        buildingCostTXT.text = buildingSO.buildingCost.ToString();
        buildingPossessedTXT.text = buildingSO.amountOfBuilding.ToString();
    }

    public void UpdateBuildingCost()
    {
        buildingCostTXT.text = buildingSO.buildingCost.ToString();
    }

    public void UpdateBuildingPossessed()
    {
        buildingPossessedTXT.text = buildingSO.amountOfBuilding.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left Click");
            OnBuildingSlotBuy?.Invoke(buildingSO);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right Click");
            OnBuildingSlotSell?.Invoke(buildingSO);
        }
    }
}
