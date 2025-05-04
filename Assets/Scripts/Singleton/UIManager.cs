using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UIManager : MonoBehaviour
{
    static public UIManager Instance;

    [Header("Fade")]
    [SerializeField] private Image imageFade;

    [Header("Barrido")]
    [SerializeField] private Image imageBarridoUp;
    [SerializeField] private Image imageBarridoLeft;
    [SerializeField] private Image imageBarridoRight;
    [SerializeField] private Image imageBarridoDown;

    [Header("Scenes")]
    public GameObject menu;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void StartFadeIn(float duration)
    {
        StartCoroutine(FadeTo(0f, duration));
    }
    public void StartFadeOut(float duration)
    {
        StartCoroutine(FadeTo(1f, duration));
    }
    public void EfectFade(float duration)
    {
        StartCoroutine(FadeOutIn(duration));
    }
    private IEnumerator FadeTo(float targetAlpha,float duration)
    {
        float startAlpha = imageFade.color.a;
        float time = 0f;
        while (time < duration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            imageFade.color = new Color(imageFade.color.r, imageFade.color.g, imageFade.color.b, newAlpha);
            time += Time.deltaTime;
            yield return null;
        }
        imageFade.color = new Color(imageFade.color.r, imageFade.color.g, imageFade.color.b, targetAlpha);
    }
    private IEnumerator FadeOutIn(float duration)
    {
        yield return StartCoroutine(FadeTo(1f, duration));
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(FadeTo(0f, duration));
    }
}
