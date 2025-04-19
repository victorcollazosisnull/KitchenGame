using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class DoFade : MonoBehaviour
{
    private Action<float> fadeIn;
    private Action<float> fadeOut;

    private Image image;
    private TMP_Text text;
    private CanvasGroup canvasGroup;

    [Header("Duración de la transición")]
    [SerializeField] private float timeFadeIN;
    [SerializeField] private float timeFadeOut;

    public float TimeFadeIN => timeFadeIN;
    public float TimeFadeOut => timeFadeOut;

    [Header("Componente a aplicar Fade")]
    [SerializeField] private OptionFade option;
    private void Reset()
    {
        timeFadeIN = 1;
        timeFadeOut = 1;
    }
    private void Awake()
    {
        switch (option)
        {
            case OptionFade.Image:
                image = GetComponent<Image>();
                fadeIn = (t) => image.DOFade(1, t).SetEase(Ease.Linear);
                fadeOut = (t) => image.DOFade(0, t).SetEase(Ease.Linear);
                break;


            case OptionFade.TMP_Text:
                text = GetComponent<TMP_Text>();
                fadeIn = (t) => text.DOFade(1, t).SetEase(Ease.Linear);
                fadeOut = (t) => text.DOFade(0, t).SetEase(Ease.Linear);
                break;

            case OptionFade.CanvasGroup:
                canvasGroup = GetComponent<CanvasGroup>();
                fadeIn = (t) => canvasGroup.DOFade(1, t).SetEase(Ease.Linear);
                fadeOut = (t) => canvasGroup.DOFade(0, t).SetEase(Ease.Linear);
                break;
        }
    }

    public void FadeIN() => fadeIn?.Invoke(timeFadeIN);
    public void FadeOut() => fadeOut?.Invoke(timeFadeOut);
}

public enum OptionFade
{
    Image,
    TMP_Text,
    CanvasGroup
}
