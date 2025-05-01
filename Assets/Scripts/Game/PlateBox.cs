using System.Collections.Generic;
using UnityEngine;

public class PlateBox : MonoBehaviour
{
    public Transform spawnPoint; 
    private List<GameObject> ingredientesEnPlato = new List<GameObject>();

    public List<TipoIngrediente> ingredientesPermitidos = new List<TipoIngrediente>
    {
        TipoIngrediente.CebollaCortada,
        TipoIngrediente.TomateCortado,
        TipoIngrediente.AjiAmarilloCortado,
        TipoIngrediente.CarneEnSarten,
        TipoIngrediente.PapaEnSarten
        // agregar mas elementos pal lomo
    };

    public void ColocarEnPlato(IngredienteData data, GameObject originalArrastrado)
    {
        if (!ingredientesPermitidos.Contains(data.tipo))
        {
            originalArrastrado.transform.position = originalArrastrado.GetComponent<DraggableItems>().GetPosicionInicial();
            return;
        }

        if (data.tipo == TipoIngrediente.CarneEnSarten || data.tipo == TipoIngrediente.PapaEnSarten)
        {
            Sarten sarten = originalArrastrado.GetComponent<Sarten>();
            if (sarten != null)
            {
                sarten.transform.position = sarten.posicionInicial;
            }

            GameObject visual = Instantiate(data.prefabListo, GetSiguientePosicion(), Quaternion.identity);
            visual.transform.SetParent(transform);
            visual.transform.localScale = Vector3.one * 0.4f;

            Destroy(visual.GetComponent<Collider2D>());
            Destroy(visual.GetComponent<DraggableItems>());

            ingredientesEnPlato.Add(visual);
            Destroy(originalArrastrado);
        }
        else
        {
            GameObject visual = Instantiate(originalArrastrado, GetSiguientePosicion(), Quaternion.identity);
            visual.transform.SetParent(transform);
            visual.transform.localScale = Vector3.one * 0.4f;

            Destroy(visual.GetComponent<Collider2D>());
            Destroy(visual.GetComponent<DraggableItems>());

            ingredientesEnPlato.Add(visual);
            Destroy(originalArrastrado);
        }
    }

    private Vector3 GetSiguientePosicion()
    {
        float radio = 0.3f; 
        int count = ingredientesEnPlato.Count;
        float angle = 360f / 8f * count; 

        float radianes = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(radianes) * radio;
        float y = Mathf.Sin(radianes) * radio;

        return spawnPoint.position + new Vector3(x, y, 0);
    }
}