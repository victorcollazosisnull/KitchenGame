using System.Collections.Generic;
using UnityEngine;

public class PlateBox : MonoBehaviour
{
    public GameObject lomoSaltadoObject;

    public Transform spawnPoint;
    private List<GameObject> ingredientesEnPlato = new List<GameObject>();

    public List<TipoIngrediente> ingredientesPermitidos = new List<TipoIngrediente>
    {
        TipoIngrediente.CebollaCortada,
        TipoIngrediente.TomateCortado,
        TipoIngrediente.AjiAmarilloCortado,
        TipoIngrediente.CarneEnSarten,
        TipoIngrediente.PapaEnSarten,
        TipoIngrediente.OllaConArroz,
        TipoIngrediente.Culantro,
        TipoIngrediente.Premix,
        TipoIngrediente.Nage,
        TipoIngrediente.Salsa
    };
    private readonly List<TipoIngrediente> ingredientesFinales = new List<TipoIngrediente>
{
    TipoIngrediente.CebollaCortada,
    TipoIngrediente.TomateCortado,
    TipoIngrediente.AjiAmarilloCortado,
    TipoIngrediente.CarneEnSarten,
    TipoIngrediente.PapaEnSarten,
    TipoIngrediente.OllaConArroz,
    TipoIngrediente.Culantro,
    TipoIngrediente.Premix,
    TipoIngrediente.Nage,
    TipoIngrediente.Salsa
};
    private void Start()
    {
        lomoSaltadoObject.SetActive(false);
    }

    public void ColocarEnPlato(IngredienteData data, GameObject originalArrastrado)
    {
        if (!ingredientesPermitidos.Contains(data.tipo))
        {
            originalArrastrado.transform.position = originalArrastrado.GetComponent<DraggableItems>().GetPosicionInicial();
            return;
        }

        if (data.tipo == TipoIngrediente.Culantro || data.tipo == TipoIngrediente.Premix || data.tipo == TipoIngrediente.Nage || data.tipo == TipoIngrediente.Salsa)
        {
            bool yaEnPlato = ingredientesEnPlato.Exists(i => i.GetComponent<IngredienteEnPlato>().tipo == data.tipo);

            if (yaEnPlato)
            {
                originalArrastrado.transform.position = originalArrastrado.GetComponent<DraggableItems>().GetPosicionInicial();
                return;
            }

            GameObject visual = new GameObject();
            IngredienteEnPlato iep = visual.AddComponent<IngredienteEnPlato>();
            iep.tipo = data.tipo;

            // Posicionamos y agregamos al plato
            visual.transform.position = GetSiguientePosicion();
            visual.transform.SetParent(transform);
            visual.transform.localScale = Vector3.one * 0.4f;

            ingredientesEnPlato.Add(visual);
            VerificarPlatoCompleto();

            Destroy(originalArrastrado);
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

            IngredienteEnPlato iep = visual.AddComponent<IngredienteEnPlato>();
            iep.tipo = data.tipo;

            ingredientesEnPlato.Add(visual);
            VerificarPlatoCompleto();
            Destroy(originalArrastrado);
        }
        else if (data.tipo == TipoIngrediente.OllaConArroz)
        {
            Olla olla = originalArrastrado.GetComponent<Olla>();
            if (olla != null)
            {
                olla.transform.position = olla.posicionInicial;
            }

            GameObject visual = Instantiate(data.prefabListo, GetSiguientePosicion(), Quaternion.identity);
            visual.transform.SetParent(transform);
            visual.transform.localScale = Vector3.one * 0.4f;

            Destroy(visual.GetComponent<Collider2D>());
            Destroy(visual.GetComponent<DraggableItems>());

            IngredienteEnPlato iep = visual.AddComponent<IngredienteEnPlato>();
            iep.tipo = data.tipo;

            ingredientesEnPlato.Add(visual);
            VerificarPlatoCompleto();
            Destroy(originalArrastrado);
        }
        else
        {
            GameObject visual = Instantiate(originalArrastrado, GetSiguientePosicion(), Quaternion.identity);
            visual.transform.SetParent(transform);
            visual.transform.localScale = Vector3.one * 0.4f;

            Destroy(visual.GetComponent<Collider2D>());
            Destroy(visual.GetComponent<DraggableItems>());

            IngredienteEnPlato iep = visual.AddComponent<IngredienteEnPlato>();
            iep.tipo = data.tipo;

            ingredientesEnPlato.Add(visual);
            VerificarPlatoCompleto();
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
    private void VerificarPlatoCompleto()
    {
        List<TipoIngrediente> tiposEnPlato = new List<TipoIngrediente>();

        for (int i = 0; i < ingredientesEnPlato.Count; i++)
        {
            IngredienteEnPlato iep = ingredientesEnPlato[i].GetComponent<IngredienteEnPlato>();
            if (iep != null)
            {
                Debug.Log(iep.tipo.ToString());
                tiposEnPlato.Add(iep.tipo);
            }
        }

        bool completo = true;

        for (int i = 0; i < ingredientesFinales.Count; i++)
        {
            if (!tiposEnPlato.Contains(ingredientesFinales[i]))
            {
                completo = false;
                break;
            }
        }

        if (completo)
        {
            if (lomoSaltadoObject != null && !lomoSaltadoObject.activeSelf)
            {
                lomoSaltadoObject.SetActive(true);
            }

            for (int i = 0; i < ingredientesEnPlato.Count; i++)
            {
                Destroy(ingredientesEnPlato[i]);
            }
            ingredientesEnPlato.Clear();
        }
    }
}