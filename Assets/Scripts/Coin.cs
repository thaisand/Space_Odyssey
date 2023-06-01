using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinManager coinManager;

    private void Start()
    {
        coinManager = GameObject.FindObjectOfType<CoinManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinManager.SpawnCoin(); // Gerar uma nova moeda
            Destroy(gameObject); // Destruir a moeda atual
        }
    }
}

