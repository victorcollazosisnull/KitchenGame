using System;
using UnityEngine;
using DG.Tweening;

public class DoMove : MonoBehaviour
{
    private Action<Vector2, float, Action> moveTo;

    private Transform targetTransform;
    private RectTransform targetRectTransform;

    [SerializeField] private float moveDuration = 1f;
    [SerializeField] private OptionMove optionMove;

    private Tween currentTween;

    private void Awake()
    {
        switch (optionMove)
        {
            case OptionMove.Transform:
                targetTransform = GetComponent<Transform>();
                moveTo = (pos, dur, onComplete) =>
                {
                    currentTween?.Kill(); 
                    currentTween = targetTransform.DOMove(pos, dur)
                        .SetEase(Ease.Linear)
                        .OnComplete(() => onComplete?.Invoke());
                };
                break;

            case OptionMove.RectTransform:
                targetRectTransform = GetComponent<RectTransform>();
                moveTo = (pos, dur, onComplete) =>
                {
                    currentTween?.Kill();
                    currentTween = targetRectTransform.DOAnchorPos(pos, dur)
                        .SetEase(Ease.Linear)
                        .OnComplete(() => onComplete?.Invoke());
                };
                break;
        }
    }

    public void MoveTo(Vector2 destino, Action onComplete = null)
    {
        moveTo?.Invoke(destino, moveDuration, onComplete);
    }

    public void MoveTo(Vector2 destino, float duracionPersonalizada, Action onComplete = null)
    {
        moveTo?.Invoke(destino, duracionPersonalizada, onComplete);
    }

    private void OnDestroy()
    {
        currentTween?.Kill();
    }
    public Vector2 GetAnchoredPosition()
    {
        return optionMove == OptionMove.RectTransform
            ? targetRectTransform.anchoredPosition
            : (Vector2)targetTransform.position;
    }
}


public enum OptionMove
{
    Transform,
    RectTransform
}
