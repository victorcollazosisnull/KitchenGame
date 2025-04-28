using UnityEngine;

public class DraggableItems : MonoBehaviour
{
    public string tipoItem; 
    private Vector3 posicionInicial;
    private bool siendoArrastrado = false;
    private bool estaEnCasilla = false;
    private CombinationBox casillaActual;

    private Sarten sartenActual; 
    //private PlateBox platoActual;

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
            if (tipoItem == "papa" || tipoItem == "cebolla" || tipoItem == "tomate" || tipoItem == "carne")
            {
                transform.position = casillaActual.transform.position;

            }
            else if (tipoItem == "cuchillo")
            {
                if (casillaActual.TieneIngrediente())
                {
                    casillaActual.CortarIngrediente();
                }

                transform.position = posicionInicial;
            }
            else if (tipoItem == "papaCortada")
            {
                // piensa p chato
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

            if (tipoItem == "papa" || tipoItem == "cebolla" || tipoItem == "tomate" || tipoItem == "carne")
            {
                casilla.SetIngrediente(gameObject, tipoItem);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CombinationBox casilla = other.GetComponent<CombinationBox>();
        if (casilla != null && casilla == casillaActual)
        {
            estaEnCasilla = false;

            if (tipoItem == "papa" || tipoItem == "cebolla" || tipoItem == "tomate" || tipoItem == "carne")
            {
                casilla.QuitarIngrediente();
            }
            casillaActual = null;
        }
    }
}