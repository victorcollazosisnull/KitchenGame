using System;
using UnityEngine;

public class CuyController : Entity
{
    [SerializeField] private Transform positionFinsh;
    [SerializeField] private Transform positionStart;
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
