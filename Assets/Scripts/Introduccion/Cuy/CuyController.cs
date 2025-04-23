using System;
using TMPro;
using UnityEngine;

public class CuyController : Entity
{
    [SerializeField] private Transform positionFinsh;
    [SerializeField] private Transform positionStart;
    [SerializeField] private DialogueSO DialogueSO;
    private void Start()
    {
        StartMovement(positionFinsh.position);
    }
    protected override void MarcarLlegada()
    {
        Debug.Log("LLego");
    }
    private void OnDrawGizmos()
    {
        
    }
}
