using UnityEngine;

public class DraggableItems : MonoBehaviour
{
    private bool siendoArrastrado = false;
    private Vector3 posicionInicial;
    private BoxItems casillaAsignada;

    private void Start()
    {
        posicionInicial = transform.position;
        casillaAsignada = transform.parent.GetComponent<BoxItems>();
    }

    private void OnMouseDown()
    {
        siendoArrastrado = true;
    }

    private void OnMouseDrag()
    {
        if (siendoArrastrado)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnMouseUp()
    {
        siendoArrastrado = false;

        if (casillaAsignada != null && casillaAsignada.EstaEncima(gameObject))
        {
            transform.position = casillaAsignada.transform.position;
        }
        else
        {
            transform.position = posicionInicial;
        }
    }
}
