using System;
using UnityEngine;
public class BarridoController : MonoBehaviour
{
    [Header("Barrido")]
    [SerializeField] private DoMove imageBarridoUp;
    [SerializeField] private DoMove imageBarridoLeft;
    [SerializeField] private DoMove imageBarridoRight;
    [SerializeField] private DoMove imageBarridoDown;

    private Vector2 InitialPositionUp;
    private Vector2 InitialPositionLeft;
    private Vector2 InitialPositionRight;
    private Vector2 InitialPositionDown;

    private void Start()
    {
        InitialPositionUp = imageBarridoUp.GetAnchoredPosition();
        InitialPositionLeft = imageBarridoLeft.GetAnchoredPosition();
        InitialPositionRight = imageBarridoRight.GetAnchoredPosition();
        InitialPositionDown = imageBarridoDown.GetAnchoredPosition();
    }
    public void ScanningEnter(Action onComplete)
    {
        int finished = 0;
        imageBarridoUp.MoveTo(Vector2.zero, CheckIfAllFinished);
        imageBarridoLeft.MoveTo(Vector2.zero, CheckIfAllFinished);
        imageBarridoRight.MoveTo(Vector2.zero, CheckIfAllFinished);
        imageBarridoDown.MoveTo(Vector2.zero, CheckIfAllFinished);

        void CheckIfAllFinished()
        {
            finished++;
            if (finished >= 4)
            {
                onComplete?.Invoke();
            }
        }
    }
    public void ScanningExit()
    {
        imageBarridoUp.MoveTo(InitialPositionUp);
        imageBarridoLeft.MoveTo(InitialPositionLeft);
        imageBarridoRight.MoveTo(InitialPositionRight);
        imageBarridoDown.MoveTo(InitialPositionDown);
    }
}
