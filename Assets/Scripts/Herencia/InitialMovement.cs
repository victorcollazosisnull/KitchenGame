using UnityEngine;

public class InitialMovement : MonoBehaviour
{
    [SerializeField] protected Transform positionStart;
    [SerializeField] protected Transform positionFinish;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(positionStart.position, 0.3f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(positionFinish.position, 0.3f);
    }
}
