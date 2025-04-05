using System;
using UnityEngine;
using UnityEngine.Events;

public class ClickerController : MonoBehaviour
{
    [SerializeField] private gearClickerUI gearUI;

    public event UnityAction informAboutGearCountChange;

    private void Awake()
    {
        gearUI.OnGearClicked += addGearToCounter;
    }

    private void Start()
    {
        InvokeRepeating(nameof(addGearPerSeconds), 0f, 1f);
    }

    private void addGearToCounter()
    {
        ClickerDataSO.Instance.AddGear(ClickerDataSO.Instance.gearPerClick);
        informAboutGearCountChange?.Invoke();
    }

    private void addGearPerSeconds()
    {
        ClickerDataSO.Instance.AddGearPerSecond();
        informAboutGearCountChange?.Invoke();
    }


}
