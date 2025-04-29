using UnityEngine;

public class Sarten : MonoBehaviour
{
    public GameObject sartenConPapas;

    private void Start()
    {
        sartenConPapas.SetActive(false);
    }

    public void CocinarPapaCortada()
    {
        sartenConPapas.SetActive(true);
        sartenConPapas.transform.position = transform.position;
        Destroy(gameObject);
    }
}