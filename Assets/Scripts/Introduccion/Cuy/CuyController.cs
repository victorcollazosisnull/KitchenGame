using UnityEngine;

public class CuyController : EntityMovile
{
    [SerializeField] private DialogueSO DialogueSO;
    protected override void Arrive()
    {
        Debug.Log("LLego");
    }
    private void OnDrawGizmos()
    {
        
    }
}
