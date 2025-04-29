using NUnit.Framework.Internal.Filters;
using UnityEngine;

public class DraggableItems : MonoBehaviour
{
    public string tipoItem; 
    private Vector3 posicionInicial;
    private bool siendoArrastrado = false;
    private bool estaEnCasilla = false;
    private CombinationBox casillaActual;

    private Sarten sartenActual;
    private Olla ollaActual;
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
            if (tipoItem == "papa" || tipoItem == "cebolla" || tipoItem == "tomate" || tipoItem == "carne" || tipoItem == "papaCortada" || tipoItem == "arroz")
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
        }
        else if (sartenActual != null && tipoItem == "papaCortada")
        {
            sartenActual.CocinarPapaCortada(); 
            Destroy(gameObject);
        }
        else if (sartenActual != null && tipoItem == "carneCortada")
        {
            sartenActual.CocinarCarneCortada();
            Destroy(gameObject);
        }
        else if (ollaActual != null && tipoItem == "arroz")
        {
            ollaActual.CocinarArroz();
            Destroy(gameObject);
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
            Debug.Log("Entrando a casilla: " + casilla.name);
            estaEnCasilla = true;
            casillaActual = casilla;

            if (tipoItem == "papa" || tipoItem == "cebolla" || tipoItem == "tomate" || tipoItem == "carne")
            {
                casilla.SetIngrediente(gameObject, tipoItem);
            }
        }

        Sarten sarten = other.GetComponent<Sarten>();
        if (sarten != null)
        {
            Debug.Log("Entrando a sartén: " + sarten.name);
            sartenActual = sarten;
        }

        Olla olla = other.GetComponent<Olla>();
        if (olla != null)
        {
            Debug.Log("Entrando a olla: " + olla.name);
            ollaActual = olla;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CombinationBox casilla = other.GetComponent<CombinationBox>();
        if (casilla != null && casilla == casillaActual)
        {
            Debug.Log("Saliendo de casilla: " + casilla.name);
            estaEnCasilla = false;
            casilla.QuitarIngrediente();
            casillaActual = null;
        }

        Sarten sarten = other.GetComponent<Sarten>();
        if (sarten != null && sarten == sartenActual)
        {
            Debug.Log("Saliendo de sartén: " + sarten.name);
            sartenActual = null;
        }

        Olla olla = other.GetComponent<Olla>();
        if (olla != null && olla == ollaActual)
        {
            Debug.Log("Saliendo de olla: " + olla.name);
            ollaActual = null;
        }
    }
}