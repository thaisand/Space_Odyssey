using UnityEngine;
using System.Collections.Generic;

public class CoinManager : MonoBehaviour
{
    public static bool bossCriado = false;
    public GameObject CoinPrefab; // Prefab da moeda no Unity Inspector
    public List<Transform> Waypoints; // Lista de waypoints no Unity Inspector
    public float spawnInterval = 15f; // Intervalo de tempo entre as gerações em segundos
    public float initialDelay = 10f; // Delay inicial em segundos
    public List<Transform> BossWaypoints; // Lista de waypoints específicos para o boss
    private bool geracaoAtiva = true; // Variável para controlar a geração de coin

    private GameObject currentCoin;
    private List<Transform> availableWaypoints; // Lista de waypoints disponíveis para spawn

    public enum SearchMethod
    {
        DepthFirst,
        BreadthFirst
    }

    public SearchMethod MethodOfSearch = SearchMethod.DepthFirst;

    private void Start()
    {
        availableWaypoints = new List<Transform>(Waypoints);
        Invoke("StartSpawningCoins", initialDelay);
    }

    private void StartSpawningCoins()
    {
        InvokeRepeating("SpawnCoin", 0f, spawnInterval);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<CriarBoss>() == null) // Verifica se o objeto não é o boss
            {
                Destroy(currentCoin);
                SpawnCoin();
            }
        }
    }

    public void SpawnCoin()
    {
        // Verifica se a geração está desativada ou se o boss já foi criado
        if (!geracaoAtiva || Gerar.bossCriado)
        {
            if (CoinPrefab != null && BossWaypoints.Count > 0)
            {
                Transform farthestWaypoint = FindFarthestWaypoint();
                currentCoin = Instantiate(CoinPrefab, farthestWaypoint.position, Quaternion.identity);
                availableWaypoints.Remove(farthestWaypoint);
                Destroy(currentCoin, 10f); // Destruir após 10 segundos
            }
            else
            {
                Debug.LogWarning("O prefab da moeda ou a lista de waypoints do boss não foi atribuída no editor da Unity.");
            }
            return;
        }

        if (CoinPrefab != null && availableWaypoints.Count > 0)
        {
            Transform farthestWaypoint = FindFarthestWaypoint();
            currentCoin = Instantiate(CoinPrefab, farthestWaypoint.position, Quaternion.identity);
            availableWaypoints.Remove(farthestWaypoint);
            Destroy(currentCoin, 10f); // Destruir após 10 segundos
        }
        else
        {
            Debug.LogWarning("O prefab da moeda ou a lista de waypoints não foi atribuída no editor da Unity ou todos os waypoints foram utilizados.");
        }
    }

    private Transform FindFarthestWaypoint()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Escolher o método de busca (Profundidade ou Largura)
        Transform farthestWaypoint;
        if (MethodOfSearch == SearchMethod.DepthFirst)
        {
            farthestWaypoint = DepthFirstSearch(playerTransform);
        }
        else
        {
            farthestWaypoint = BreadthFirstSearch(playerTransform);
        }

        return farthestWaypoint;
    }

    private Transform DepthFirstSearch(Transform playerTransform)
    {
        Transform farthestWaypoint = null;
        float maxDistanceX = float.MinValue;
        float maxDistanceY = float.MinValue;

        foreach (Transform waypoint in availableWaypoints)
        {
            float distanceX = Mathf.Abs(waypoint.position.x - playerTransform.position.x);
            float distanceY = Mathf.Abs(waypoint.position.y - playerTransform.position.y);

            if (distanceX > maxDistanceX || (distanceX == maxDistanceX && distanceY > maxDistanceY))
            {
                maxDistanceX = distanceX;
                maxDistanceY = distanceY;
                farthestWaypoint = waypoint;
            }
        }

        return farthestWaypoint;
    }

    private Transform BreadthFirstSearch(Transform playerTransform)
    {
        Transform farthestWaypoint = null;
        float maxDistance = float.MinValue;
        Queue<Transform> queue = new Queue<Transform>(availableWaypoints);

        while (queue.Count > 0)
        {
            Transform waypoint = queue.Dequeue();
            float distance = Vector3.Distance(waypoint.position, playerTransform.position);

            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthestWaypoint = waypoint;
            }
        }

        return farthestWaypoint;
    }

    // Função para ativar/desativar a geração de inimigos
    public void SetGeracaoAtiva(bool ativa)
    {
        geracaoAtiva = ativa;
    }

    void Update()
    {
        if (CriarBoss.bossMorto == true)
        {
            bossCriado = false;
        }
    }
}
