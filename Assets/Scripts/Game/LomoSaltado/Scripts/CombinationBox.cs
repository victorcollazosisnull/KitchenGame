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
}