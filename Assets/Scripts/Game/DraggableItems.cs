using NUnit.Framework.Internal.Filters;
using UnityEngine;

public class DraggableItems : MonoBehaviour
{
    public IngredienteData data;

    private Vector3 posicionInicial;
    private bool siendoArrastrado = false;
    private bool estaEnCasilla = false;

    private CombinationBox casillaActual;
    private Sarten sartenActual;
    private Olla ollaActual;

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
            if (data.tipo == TipoIngrediente.Cuchillo)
            {
                casillaActual.CortarIngrediente();
                transform.position = posicionInicial;
            }
            else
            {
                transform.position = casillaActual.transform.position;
            }
        }
        else if (sartenActual != null)
        {
            if (data.tipo == TipoIngrediente.PapaCortada || data.tipo == TipoIngrediente.CarneCortada)
            {
                sartenActual.Cocinar(data);
                Destroy(gameObject);
            }
            else
            {
                transform.position = posicionInicial;
            }
        }
        else if (ollaActual != null)
        {
            if (data.tipo == TipoIngrediente.Arroz)
            {
                ollaActual.Cocinar(data);
                Destroy(gameObject);
            }
            else
            {
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
        if (other.TryGetComponent(out CombinationBox casilla))
        {
            if (data.tipo == TipoIngrediente.Cuchillo || !casilla.TieneIngrediente())
            {
                estaEnCasilla = true;
                casillaActual = casilla;

                if (data.tipo != TipoIngrediente.Cuchillo)
                {
                    casilla.SetIngrediente(gameObject, data);
                }
            }
        }

        if (other.TryGetComponent(out Sarten sarten))
        {
            sartenActual = sarten;
        }

        if (other.TryGetComponent(out Olla olla))
        {
            ollaActual = olla;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out CombinationBox casilla) && casilla == casillaActual)
        {
            estaEnCasilla = false;
            casilla.QuitarIngrediente();
            casillaActual = null;
        }

        if (other.TryGetComponent(out Sarten sarten) && sarten == sartenActual)
        {
            sartenActual = null;
        }

        if (other.TryGetComponent(out Olla olla) && olla == ollaActual)
        {
            ollaActual = null;
        }
    }
}