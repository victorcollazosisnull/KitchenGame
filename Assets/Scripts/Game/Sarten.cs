using UnityEngine;

public class Sarten : MonoBehaviour
{
    public GameObject onlySarten;
    public GameObject sartenPapas;
    private void Start()
    {
        sartenPapas.SetActive(false);
    }
    public void ColocarSartenPapas()
    {
        onlySarten.SetActive(false);
        sartenPapas.SetActive(true);
    }
}
