using UnityEngine;

public class BoxItems : MonoBehaviour
{
    private GameObject ingredienteEncima;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ingredienteEncima = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (ingredienteEncima == other.gameObject)
        {
            ingredienteEncima = null;
        }
    }

    public bool EstaEncima(GameObject ingrediente)
    {
        return ingredienteEncima == ingrediente;
    }
}