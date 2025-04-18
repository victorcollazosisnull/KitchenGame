using UnityEngine;

public class DraggableItems : MonoBehaviour
{
    public string tipoItem;
    private Vector3 posicionInicial;
    private bool siendoArrastrado = false;
    private bool estaEnCasilla = false;
    private CombinationBox casillaActual;

    private void Start()
    {
        posicionInicial = transform.position; 
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

        if (estaEnCasilla)
        {
            if (tipoItem == "papa")
            {
                // papita en nueva posicion
                transform.position = casillaActual.transform.position;
            }
            else if (tipoItem == "cuchillo")
            {
                if (casillaActual.TienePapa())
                {
                    //corte a la papita
                    casillaActual.CortarPapa();
                }
                transform.position = posicionInicial;
            }
        }
        else
        {
            transform.position = posicionInicial;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CombinationBox casilla = other.GetComponent<CombinationBox>();
        if (casilla != null)
        {
            estaEnCasilla = true;
            casillaActual = casilla;

            // si eres una papa, te colocas 
            if (tipoItem == "papa")
                casilla.SetPapa(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CombinationBox casilla = other.GetComponent<CombinationBox>();
        if (casilla != null && casilla == casillaActual)
        {
            estaEnCasilla = false;

            if (tipoItem == "papa")
                casilla.QuitarPapa();

            casillaActual = null;
        }
    }
}