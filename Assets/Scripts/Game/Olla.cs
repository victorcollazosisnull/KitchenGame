using UnityEngine;

public class Olla : MonoBehaviour
{
    public IngredienteData arrozData;
    public Vector3 posicionInicial;
    private void Awake()
    {
        posicionInicial = transform.position;
    }
    private void Start()
    {
        if (arrozData.prefabCocinado)
        {
            arrozData.prefabCocinado.SetActive(false);
        }
    }

    public void Cocinar(IngredienteData data)
    {
        if (data.prefabCocinado != null)
        {
            GameObject obj = Instantiate(data.prefabCocinado, transform.position, Quaternion.identity);
            obj.SetActive(true);

            obj.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

            gameObject.SetActive(false);
        }
    }
}
