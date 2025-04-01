using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class nameSettingUI : MonoBehaviour
{
    [SerializeField] private workshopUI workshopUI;
    [SerializeField] private TMP_InputField inputField;
    private string inputText;

    private void Awake()
    {
        workshopUI.OnWorkshopNameClick += showSettingPanel;
        hideSettingPanel();
    }

    private void showSettingPanel()
    {
        this.gameObject.SetActive(true);
    }

    private void hideSettingPanel()
    {
        this.gameObject.SetActive(false);
    }

    private void Start()
    {
        inputField.onEndEdit.AddListener(OnSubmit);
        inputField.text = ClickerDataSO.Instance.workshopName;
    }

    public void OnSubmit(string value)
    {
        ClickerDataSO.Instance.changeName(inputField.text);
        hideSettingPanel();
    }
}
