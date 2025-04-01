using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class gearClickerUI : MonoBehaviour, IPointerClickHandler
{
    #region Input
    [Header("InputReader")]
    public InputReader inputReader;

    #endregion

    #region UI
    [Header("UI")]
    [SerializeField] private Image gearSprite;
    [SerializeField] private Image gearBorder;

    private float animationClickDuration = 0.2f;
    private float scaleFactor = 0.8f;
    private Vector3 originalScale;

    #endregion

    public UnityAction OnGearClicked;

    private void Start()
    {
        gearBorder.enabled = false;
        originalScale = transform.localScale;
    }


    private void OnGearImageClicked()
    {
        StartCoroutine(AnimateClickedButton());
    }

    

    private IEnumerator AnimateClickedButton()
    {
        Vector3 targetScale = originalScale * scaleFactor;
        
        yield return StartCoroutine(ScaleOverTime(targetScale, animationClickDuration / 2));

        yield return StartCoroutine(ScaleOverTime(originalScale, animationClickDuration / 2));
        
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            
            OnGearImageClicked();
            OnGearClicked?.Invoke();
        }
    }

    private IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, targetScale, time / duration);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
