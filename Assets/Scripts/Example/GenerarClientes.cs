using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GenerarClientes : MonoBehaviour
{
    [SerializeField] private int totalClients;
    [SerializeField] private int expectedcustomers;
    [SerializeField] private float timebetweenClients;
    [SerializeField] private float separationBetweenClients;
    private int countclients;
    private int numberOfClients;

    [SerializeField] private GameObject[] clientsPrefabs;
    [SerializeField] private Transform positionInstantie;
    [SerializeField] private Transform positionFinish;

    private Vector2 queueDestination;

    private Queue<GameObject> clientsQueue=new Queue<GameObject>();
    private void Start()
    {
        StartCoroutine(GenerateClients());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AtenderCliente();
        }
    }
    private IEnumerator GenerateClients()
    {
        while (countclients < totalClients && numberOfClients < expectedcustomers)
        {
            GameObject go = Instantiate(GetClient(), positionInstantie.position, transform.rotation);

            if (clientsQueue.Count == 0)
                go.GetComponent<Cliente>().StartMovement(positionFinish.position);
            else
            {
                queueDestination = new Vector2(
                    positionFinish.position.x + separationBetweenClients * clientsQueue.Count,
                    positionFinish.position.y
                );
                go.GetComponent<Cliente>().StartMovement(queueDestination);
            }
            clientsQueue.Enqueue(go);
            ++countclients;
            ++numberOfClients;

            yield return new WaitForSeconds(timebetweenClients);
        }

        Debug.Log("Se alcanzó el número máximo de clientes.");
    }
    private GameObject GetClient()
    {
        return clientsPrefabs[Random.Range(0,clientsPrefabs.Length)];
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(positionInstantie.transform.position, 0.3f);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(positionFinish.transform.position, 0.3f);
    }
    public void AtenderCliente()
    {
        if (clientsQueue.Count == 0) return;

        GameObject clienteAtendido = clientsQueue.Dequeue();
        Destroy(clienteAtendido); 

        int index = 0;
        foreach (GameObject cliente in clientsQueue)
        {
            Vector2 nuevaPosicion = new Vector2(
                positionFinish.position.x + separationBetweenClients * index,
                positionFinish.position.y
            );
            cliente.GetComponent<Cliente>().StartMovement(nuevaPosicion);
            index++;
        }

        numberOfClients--;
        StartCoroutine(GenerateClients());
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {

    }
}
