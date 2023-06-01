using UnityEngine;
using System.Collections.Generic;

public class GerarCoins : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public GameObject Coin; // Prefab da moeda
    public int moedas = 0; 

    private bool canSpawn = true;

    void Start()
    {
        if (waypoints.Count > 0)
        {
            SpawnCoin();
        }
        else
        {
            Debug.LogWarning("A lista de waypoints está vazia. Adicione waypoints no editor da Unity.");
        }
    }

    void SpawnCoin()
    {
        if (!canSpawn)
        {
            return;
        }

        if (Coin != null)
        {
            int randomIndex = Random.Range(0, waypoints.Count);
            Transform randomWaypoint = waypoints[randomIndex];
            Instantiate(Coin, randomWaypoint.position, Quaternion.identity);

            waypoints.RemoveAt(randomIndex); // Remove o waypoint utilizado

            if (waypoints.Count == 0)
            {
                canSpawn = false; // Impede novas gerações quando não houver mais waypoints disponíveis
            }
        }
        else
        {
            Debug.LogWarning("O prefab da moeda não foi atribuído no editor da Unity. Adicione o prefab.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Destruir a moeda atual
            CoinManager coinManager = FindObjectOfType<CoinManager>();
            coinManager.SpawnCoin(); // Gerar uma nova moeda
        }
    }
}
