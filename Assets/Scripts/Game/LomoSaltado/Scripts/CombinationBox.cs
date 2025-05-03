using UnityEngine;

public class CombinationBox : MonoBehaviour
{
    private GameObject ingredienteActual;
    private IngredienteData dataIngrediente;

    public void SetIngrediente(GameObject ingrediente, IngredienteData data)
    {
        ingredienteActual = ingrediente;
        dataIngrediente = data;
    }

    public void QuitarIngrediente()
    {
        ingredienteActual = null;
        dataIngrediente = null;
    }

    public bool TieneIngrediente()
    {
        return ingredienteActual != null;
    }

    public void CortarIngrediente()
    {
        if (ingredienteActual != null && dataIngrediente != null && dataIngrediente.prefabCortado != null)
        {
            GameObject cortado = Instantiate(dataIngrediente.prefabCortado, transform.position, Quaternion.identity);
            Destroy(ingredienteActual);

            ingredienteActual = null;
            dataIngrediente = null;
        }
    }
    public void ExprimirIngrediente()
    {
        Debug.Log("Exprimeteeee");

        if (ingredienteActual != null && dataIngrediente != null)
        {
            if (dataIngrediente.tipo == TipoIngrediente.Limon && dataIngrediente.prefabExprimido != null)
            {
                Debug.Log("Exprimido finosamente");
                GameObject jugo = Instantiate(dataIngrediente.prefabExprimido, transform.position, Quaternion.identity);
                Destroy(ingredienteActual);

                ingredienteActual = null;
                dataIngrediente = null;
            }
            else
            {
                Debug.Log("aea");
            }
        }
        else
        {
            Debug.Log("No hay nada xd");
        }
    }
}