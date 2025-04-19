using UnityEngine;
using UnityEngine.UI;

public class Cliente : MonoBehaviour
{
    private DoMove doMove;
    [SerializeField] private Image image;
    [SerializeField] private float patience;
    private bool llego;
    private void Awake()
    {
        doMove = GetComponent<DoMove>();
    }
    public void StartMovement(Vector3 destino)
    {
        doMove.MoveTo(destino, MarcarLlegada);
    }
    public void StartMovement(Vector3 destino,float time)
    {
        doMove.MoveTo(destino,time,MarcarLlegada);
    }
    private void Update()
    {
        if (llego)
        {
            patience -= Time.deltaTime;
            image.fillAmount = patience / 5;
        }
    }
    public void MarcarLlegada()
    {
        llego = true;
    }
}
