using System.Collections.Generic;
using UnityEngine;

public class PlateBox : MonoBehaviour
{
    public Transform spawnPoint; 
    private List<GameObject> ingredientesEnPlato = new List<GameObject>();

    public List<TipoIngrediente> ingredientesPermitidos = new List<TipoIngrediente>
    {
        TipoIngrediente.CebollaCortada,
        TipoIngrediente.TomateCortado
        // agregar mas elementos pal lomo
    };

    public void ColocarEnPlato(IngredienteData data, GameObject originalArrastrado)
    {
        if (!ingredientesPermitidos.Contains(data.tipo))
        {
            originalArrastrado.transform.position = originalArrastrado.GetComponent<DraggableItems>().GetPosicionInicial();
            return;
        }

        GameObject visual = Instantiate(originalArrastrado, GetSiguientePosicion(), Quaternion.identity);
        visual.transform.SetParent(transform);
        visual.transform.localScale = Vector3.one * 0.4f;

        Destroy(visual.GetComponent<Collider2D>());
        Destroy(visual.GetComponent<DraggableItems>());

        ingredientesEnPlato.Add(visual);
        Destroy(originalArrastrado); 
    }

    private Vector3 GetSiguientePosicion()
    {
        float offsetX = 0.3f;
        float offsetY = 0.2f;
        int count = ingredientesEnPlato.Count;

        return spawnPoint.position + new Vector3(offsetX * count, -offsetY * count, 0);
    }
}