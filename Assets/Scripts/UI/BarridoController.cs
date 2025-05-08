using System;
using UnityEngine;
public class BarridoController : MonoBehaviour
{
    [Header("Barrido")]
    [SerializeField] private DoMove imageBarridoUp;
    [SerializeField] private DoMove imageBarridoLeft;
    [SerializeField] private DoMove imageBarridoRight;
    [SerializeField] private DoMove imageBarridoDown;
    [SerializeField] private float timeScaning;


    private Vector2 InitialPositionUp;
    private Vector2 InitialPositionLeft;
    private Vector2 InitialPositionRight;
    private Vector2 InitialPositionDown;

    int finished;
    private void Reset()
    {
        timeScaning = 0.5f;
    }
    private void Start()
    {
        InitialPositionUp = imageBarridoUp.GetAnchoredPosition();
        InitialPositionLeft = imageBarridoLeft.GetAnchoredPosition();
        InitialPositionRight = imageBarridoRight.GetAnchoredPosition();
        InitialPositionDown = imageBarridoDown.GetAnchoredPosition();
    }
    public void ScanningEnter(Action onComplete)
    {
        finished = 0;
        imageBarridoUp.MoveTo(Vector2.zero, timeScaning, CheckIfAllFinished);
        imageBarridoLeft.MoveTo(Vector2.zero, timeScaning, CheckIfAllFinished);
        imageBarridoRight.MoveTo(Vector2.zero, timeScaning, CheckIfAllFinished);
        imageBarridoDown.MoveTo(Vector2.zero, timeScaning, CheckIfAllFinished);

        void CheckIfAllFinished()
        {
            finished++;
            if (finished >= 4)
            {
                onComplete?.Invoke();
            }
        }
    }
    public void ScanningExit(Action onComplete)
    {
        finished = 0;
        imageBarridoUp.MoveTo(InitialPositionUp,timeScaning,CheckIfAllFinished);
        imageBarridoLeft.MoveTo(InitialPositionLeft, timeScaning, CheckIfAllFinished);
        imageBarridoRight.MoveTo(InitialPositionRight, timeScaning, CheckIfAllFinished);
        imageBarridoDown.MoveTo(InitialPositionDown, timeScaning, CheckIfAllFinished);
        void CheckIfAllFinished()
        {
            finished++;
            if (finished >= 4)
            {
                onComplete?.Invoke();
            }
        }
    }
}
