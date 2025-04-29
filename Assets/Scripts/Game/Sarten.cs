using UnityEngine;

public class Sarten : MonoBehaviour
{
    public GameObject sartenConPapas;
    public GameObject sartenConCarne;

    private void Start()
    {
        sartenConPapas.SetActive(false);
        sartenConCarne.SetActive(false);
    }

    public void CocinarPapaCortada()
    {
        sartenConPapas.SetActive(true);
        sartenConPapas.transform.position = transform.position;
        Destroy(gameObject);
    }
    public void CocinarCarneCortada()
    {
        sartenConCarne.SetActive(true);
        sartenConCarne.transform.position = transform.position;
        Destroy(gameObject);
    }
}