using UnityEngine;
[RequireComponent(typeof(DoMove))]
abstract public class EntityMovile : Entity
{
    private DoMove doMove;
    private Vector2 previousPosition;
    private void Awake()
    {
        doMove = GetComponent<DoMove>();
    }
    public void StartMovement(Vector3 destination)
    {
        previousPosition = destination;
        doMove.MoveTo(destination, Arrive);
    }
    public void StartMovement(Vector3 destination, float time)
    {
        previousPosition = destination;
        doMove.MoveTo(destination, time, Arrive);
    }
    public void GobBack()
    {
        StartMovement(previousPosition);
    }
    public void GobBack(float time)
    {
        StartMovement(previousPosition,time);
    }
    protected abstract void Arrive();
}
