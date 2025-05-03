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
    private PlateBox plateBoxActual;
    private OllaConAgua ollaConAguaActual;
    private Licuadora licuadoraActual;
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
            else if (data.tipo == TipoIngrediente.Exprimidor)
            {
                casillaActual.ExprimirIngrediente();
                transform.position = posicionInicial;
            }
            else if (data.tipo == TipoIngrediente.CamoteEnOlla)
            {
                casillaActual.CocinarIngrediente(data, gameObject);
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
            else if (data.tipo == TipoIngrediente.CarneEnSarten)
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
        else if (ollaConAguaActual != null)
        {
            if (data.tipo == TipoIngrediente.Camote)
            {
                ollaConAguaActual.Cocinar(ollaConAguaActual.camoteData);
                Destroy(gameObject);
            }
            else if (data.tipo == TipoIngrediente.Choclo)
            {
                ollaConAguaActual.Cocinar(ollaConAguaActual.chocloData);
                Destroy(gameObject);
            }
            else
            {
                transform.position = posicionInicial;
            }
        }
        else if (licuadoraActual != null)
        {
            if (data.tipo == TipoIngrediente.RocotoCortado)
            {
                licuadoraActual.Licuar(data);
                Destroy(gameObject);
            }
            else
            {
                transform.position = posicionInicial;
            }
        }
        else if (plateBoxActual != null)
        {
            plateBoxActual.ColocarEnPlato(data, gameObject);
        }
        else
        {
            transform.position = posicionInicial;
        }
    }
    public Vector3 GetPosicionInicial()
    {
        return posicionInicial;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CombinationBox casilla))
        {
            estaEnCasilla = true;
            casillaActual = casilla;

            if (data.tipo != TipoIngrediente.Cuchillo && data.tipo != TipoIngrediente.Exprimidor && !casilla.TieneIngrediente())
            {
                casilla.SetIngrediente(gameObject, data);
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

        if (other.TryGetComponent(out PlateBox plateBox))
        {
            plateBoxActual = plateBox;
        }

        if (other.TryGetComponent(out OllaConAgua ollaAgua))
        {
            ollaConAguaActual = ollaAgua;
        }

        if (other.TryGetComponent(out Licuadora licuadora))
        {
            licuadoraActual = licuadora;
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
        if (other.TryGetComponent(out PlateBox plateBox) && plateBox == plateBoxActual)
        {
            plateBoxActual = null;
        }
        if (other.TryGetComponent(out OllaConAgua ollaAgua) && ollaAgua == ollaConAguaActual)
        {
            ollaConAguaActual = null;
        }
        if (other.TryGetComponent(out Licuadora licuadora) && licuadora == licuadoraActual)
        {
            licuadoraActual = null;
        }
    }
}