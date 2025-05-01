using UnityEngine;

public class CuyController : EntityMovile
{
    private Animator animator;

    [SerializeField] private DialogueSO DialogueSO;
    private StateCuy State;
    protected override void Arrive()
    {
        Debug.Log("LLego");
    }
    private void OnDrawGizmos()
    {
        
    }
}
