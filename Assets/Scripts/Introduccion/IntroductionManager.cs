using UnityEngine;
public class IntroductionManager : InitialMovement
{
    [SerializeField] private CuyController cuy;
    [SerializeField] private MarckController Marck;
    [SerializeField] private float timeTranslationCuy;
    private void Reset()
    {
        timeTranslationCuy = 1f;
    }
    private void Start()
    {
        Marck.StartDialogue();
    }
}
