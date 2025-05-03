using UnityEngine;

[CreateAssetMenu(menuName = "Cocina/Ingrediente")]
public class IngredienteData : ScriptableObject
{
    public TipoIngrediente tipo;
    public GameObject prefabCortado;
    public GameObject prefabCocinado;
    public GameObject prefabListo;

    public GameObject prefabExprimido;
}