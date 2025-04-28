using UnityEngine;

public class PlateBox : MonoBehaviour
{
    public GameObject[] ingredientesSobrePlato; 

    public void ColocarEnPlato(GameObject ingrediente)
    {
        for (int i = 0; i < ingredientesSobrePlato.Length; i++)
        {
            if (!ingredientesSobrePlato[i].activeSelf)
            {
                ingredientesSobrePlato[i].SetActive(true);
                ingredientesSobrePlato[i].transform.position = transform.position;
                ingrediente.SetActive(false);
                break; 
            }
        }
    }
}