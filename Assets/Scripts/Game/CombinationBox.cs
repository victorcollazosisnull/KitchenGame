using UnityEngine;

public class CombinationBox : MonoBehaviour
{
    private GameObject ingredienteActual;
    private string tipoIngrediente;

    public GameObject papaCortada;
    public GameObject cebollaCortada;
    public GameObject tomateCortado;

    private void Start()
    {
        papaCortada.SetActive(false);
        cebollaCortada.SetActive(false);
        tomateCortado.SetActive(false);
    }
    public void SetIngrediente(GameObject ingrediente, string tipo)
    {
        ingredienteActual = ingrediente;
        tipoIngrediente = tipo;
    }

    public void QuitarIngrediente()
    {
        ingredienteActual = null;
        tipoIngrediente = null;
    }

    public bool TieneIngrediente()
    {
        return ingredienteActual != null;
    }

    public void CortarIngrediente()
    {
        if (ingredienteActual != null)
        {
            Debug.Log("Cortando: " + tipoIngrediente);

            if (tipoIngrediente == "papa")
            {
                papaCortada.SetActive(true);
                papaCortada.transform.position = transform.position;
                Destroy(ingredienteActual);
            }
            else if (tipoIngrediente == "cebolla")
            {
                cebollaCortada.SetActive(true);
                cebollaCortada.transform.position = transform.position;
                Destroy(ingredienteActual);
            }
            else if (tipoIngrediente == "tomate")
            {
                tomateCortado.SetActive(true);
                tomateCortado.transform.position = transform.position;
                Destroy(ingredienteActual);
            }

            ingredienteActual = null;
            tipoIngrediente = null;
        }
    }
}