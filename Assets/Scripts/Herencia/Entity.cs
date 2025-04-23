using UnityEngine;
[RequireComponent (typeof(DoMove))]
abstract public class Entity : MonoBehaviour
{
    private DoMove doMove;
    protected bool llego;
    private void Awake()
    {
        doMove = GetComponent<DoMove>();
    }
    protected void StartMovement(Vector3 destination)
    {
        doMove.MoveTo(destination, MarcarLlegada);
    }
    protected void StartMovement(Vector3 destination, float time)
    {
        doMove.MoveTo(destination, time, MarcarLlegada);
    }
    protected abstract void MarcarLlegada();
}
