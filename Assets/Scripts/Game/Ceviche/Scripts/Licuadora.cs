using UnityEngine;

public class Licuadora : MonoBehaviour
{
    public IngredienteData rocotoCortadoData;

    private void Start()
    {
        if (rocotoCortadoData.prefabLicuado != null)
            rocotoCortadoData.prefabLicuado.SetActive(false);
    }

    public void Licuar(IngredienteData data)
    {
        if (data.prefabLicuado == null)
        {
            Debug.Log("Esto no se licua.");
            return;
        }

        GameObject obj = Instantiate(data.prefabLicuado, transform.position, Quaternion.identity);
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        obj.SetActive(true);

        gameObject.SetActive(false); 
    }
}