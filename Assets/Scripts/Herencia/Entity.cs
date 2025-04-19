using UnityEngine;
[RequireComponent (typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    protected void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
}
