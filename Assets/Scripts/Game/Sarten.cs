using UnityEngine;

public class Sarten : MonoBehaviour
{
    public IngredienteData papaData;
    public IngredienteData carneData;

    public Vector3 posicionInicial;
    private void Start()
    {
        posicionInicial = transform.position;

        if (papaData.prefabCocinado != null)
        {
            papaData.prefabCocinado.SetActive(false);
        }
        if (carneData.prefabCocinado != null)
        {
            carneData.prefabCocinado.SetActive(false);
        }
    }

    public void Cocinar(IngredienteData data)
    {
        if (data.prefabCocinado != null)
        {
            GameObject obj = Instantiate(data.prefabCocinado, transform.position, Quaternion.identity);
            obj.SetActive(true);

            obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); 

            gameObject.SetActive(false);
        }
    }
}