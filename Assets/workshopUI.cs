using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class workshopUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text WSText;

    public event UnityAction OnWorkshopNameClick;

    private void Start()
    {
        WSText.text = ClickerDataSO.Instance.workshopName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnWorkshopNameClick?.Invoke();
    }
}
