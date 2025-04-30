using UnityEngine;

public class MarckController : Entity
{
    [SerializeField] private CuyController cuy;
    [SerializeField] private IntroductionManager introductionManager;
    
    private void Start()
    {
        StartDialogue();
    }
    protected override void TermDialogue()
    {
        cuy.StartDialogue();
    }
}
