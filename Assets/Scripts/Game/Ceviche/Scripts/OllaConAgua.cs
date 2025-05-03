using UnityEngine;

public class OllaConAgua : MonoBehaviour
{
    public IngredienteData camoteData;
    public IngredienteData chocloData;

    private void Start()
    {
        if (camoteData.prefabCocinado != null)
            camoteData.prefabCocinado.SetActive(false);

        if (chocloData.prefabCocinado != null)
            chocloData.prefabCocinado.SetActive(false);
    }

    public void Cocinar(IngredienteData data)
    {
        if (data.prefabCocinado == null)
        {
            return;
        }
        GameObject obj = Instantiate(data.prefabCocinado, transform.position, Quaternion.identity);
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        obj.SetActive(true);

        gameObject.SetActive(false);
    }
}