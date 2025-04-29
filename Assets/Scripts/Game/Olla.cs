using UnityEngine;

public class Olla : MonoBehaviour
{
    public GameObject ollaConArroz;

    private void Start()
    {
        ollaConArroz.SetActive(false);
    }
    public void CocinarArroz()
    {
        ollaConArroz.SetActive(true);
        ollaConArroz.transform.position = transform.position;
        Destroy(gameObject);
    }
}
