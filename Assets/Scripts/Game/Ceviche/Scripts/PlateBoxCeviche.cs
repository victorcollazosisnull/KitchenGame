using System.Collections.Generic;
using UnityEngine;

public class PlateBoxCeviche : MonoBehaviour
{
    public GameObject cevicheFinalObject;
    public Transform spawnPoint;

    private List<GameObject> ingredientesEnPlato = new List<GameObject>();

    public List<TipoIngrediente> ingredientesPermitidos = new List<TipoIngrediente>
    {
        TipoIngrediente.PescadoPicado,
        TipoIngrediente.AjiLimoPicado,
        TipoIngrediente.CulantroPicado,
        TipoIngrediente.Sal,
        TipoIngrediente.PastaRocoto,
        TipoIngrediente.JugoLimon,
        TipoIngrediente.GranosChoclo,
        TipoIngrediente.RodajasCamote,
        TipoIngrediente.CebollaCortada
    };

    private readonly List<TipoIngrediente> ingredientesFinales = new List<TipoIngrediente>
    {
        TipoIngrediente.PescadoPicado,
        TipoIngrediente.AjiLimoPicado,
        TipoIngrediente.CulantroPicado,
        TipoIngrediente.Sal,
        TipoIngrediente.PastaRocoto,
        TipoIngrediente.JugoLimon,
        TipoIngrediente.GranosChoclo,
        TipoIngrediente.RodajasCamote,
        TipoIngrediente.CebollaCortada
    };

    private void Start()
    {
        cevicheFinalObject.SetActive(false);
    }

    public void ColocarEnPlato(IngredienteData data, GameObject originalArrastrado)
    {
        if (!ingredientesPermitidos.Contains(data.tipo))
        {
            originalArrastrado.transform.position = originalArrastrado.GetComponent<DraggableItems>().GetPosicionInicial();
            return;
        }

        bool yaEnPlato = ingredientesEnPlato.Exists(i => i.GetComponent<IngredienteEnPlato>().tipo == data.tipo);
        if (yaEnPlato)
        {
            originalArrastrado.transform.position = originalArrastrado.GetComponent<DraggableItems>().GetPosicionInicial();
            return;
        }

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

    private Vector3 GetSiguientePosicion()
    {
        float radio = 0.3f;
        int count = ingredientesEnPlato.Count;
        float angle = 360f / 9f * count;

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
            if (cevicheFinalObject != null && !cevicheFinalObject.activeSelf)
            {
                cevicheFinalObject.SetActive(true);
            }

            for (int i = 0; i < ingredientesEnPlato.Count; i++)
            {
                Destroy(ingredientesEnPlato[i]);
            }

            ingredientesEnPlato.Clear();
        }
    }
}