using UnityEngine;

public class CuyController : EntityMovile
{
    private Animator animator;

    private StateCuy State;

    protected override void Arrive()
    {
        Debug.Log("LLego");
    }
    private void OnDrawGizmos()
    {
        
    }
}
