using UnityEngine;

public class CombinationBox : MonoBehaviour
{
    private GameObject papaActual;
    public GameObject papaCortadaPrefab;

    public void SetPapa(GameObject papa)
    {
        papaActual = papa;
    }

    public void QuitarPapa()
    {
        papaActual = null;
    }

    public bool TienePapa()
    {
        return papaActual != null;
    }

    public void CortarPapa()
    {
        if (papaActual != null)
        {
            Vector3 posicion = transform.position;
            Destroy(papaActual);
            Instantiate(papaCortadaPrefab, posicion, Quaternion.identity);
            papaActual = null;
        }
    }
}