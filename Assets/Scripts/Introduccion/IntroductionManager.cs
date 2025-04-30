using UnityEngine;
public class IntroductionManager : InitialMovement
{
    [SerializeField] private CuyController cuy;
    [SerializeField] private MarckController Marck;
    [SerializeField] private float timeTranslationCuy;
    private int indexCuy;
    private int indexMarck;
    private void Reset()
    {
        timeTranslationCuy = 1f;
    }
    private void Start()
    {
        StartDialogueMarck();
    }
    private void StartDialogueCuy()
    {
        //cuy.StartDialogue(indexCuy);
        Debug.Log("aea");
        //++indexCuy;
    }
    private void StartDialogueMarck ()
    {
        Marck.StartDialogue(indexMarck);
        //++indexMarck;
    }
    private void OnEnable()
    {
        CuyController.EventTermDialogue += StartDialogueMarck;
        MarckController.EventTermDialogue += StartDialogueCuy;
    }
    private void OnDisable()
    {
        CuyController.EventTermDialogue -= StartDialogueMarck;
        MarckController.EventTermDialogue -= StartDialogueCuy;
    }
}
