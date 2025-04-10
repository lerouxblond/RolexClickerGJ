using System;
using TMPro;
using UnityEngine;

public class gearCounterUI : MonoBehaviour
{
    #region UI
    [SerializeField] private TMP_Text countTXT;
    [SerializeField] private TMP_Text GearPerClickTXT;
    #endregion

    [SerializeField] private ClickerController ClickerController;

    private void Awake()
    {
        ClickerController.informAboutGearCountChange += updateGearUI;
        updateGearUI();
    }

    private void updateGearUI()
    {
        float roundedCount = (float)Math.Round(ClickerDataSO.Instance.gearCount, 2);
        countTXT.text = roundedCount.ToString();
        GearPerClickTXT.text = $"{ClickerDataSO.Instance.gearPerSecond} per click";
    }
}
