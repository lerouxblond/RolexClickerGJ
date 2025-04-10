using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeSlotUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Image upgradeIcon;

    [SerializeField] public BuildingUpgradeSO data;

    public UnityAction<BuildingUpgradeSO> OnUpgradeSlotClick;

    private void Start()
    {
        ShowUpgradeSlot(data.isUnlocked);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnUpgradeSlotClick?.Invoke(data);
        }
    }

    public void Initialize(BuildingUpgradeSO data)
    {
        this.data = data;
        upgradeIcon.sprite = data.upgradeIcon;
        costText.text = data.upgradeCost.ToString();
    }

    public void ShowUpgradeSlot(bool isUnlocked)
    {
        if (isUnlocked)
            this.gameObject.SetActive(true);
        else
            this.gameObject.SetActive(false);
    }
}
