using UnityEngine;

public class inimigo : MonoBehaviour
{
    [SerializeField]
    private ClipWithVolume hitFx;

    [SerializeField]
    private GameObject hitPrefab;

    [SerializeField]
    private GameObject explosaoPrefab;

    [SerializeField]
    private int healthPoints = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bala") && gameObject.tag == "Enemy" || other.CompareTag("Meteoro") && gameObject.tag == "Enemy" || other.CompareTag("Bala") && gameObject.tag == "Meteoro")
        {
            // hit

            Instantiate(hitPrefab, other.transform.position, hitPrefab.transform.rotation);
            Destroy(other.gameObject);

            // Update Health Points

            healthPoints--;

            // Se saude igual ou menor que 0 -> destruir

            if (healthPoints <= 0)
            {

                ControleExplosao.Instance.Create(transform.position, transform.rotation);

                Destroy(gameObject);

                Pontuacao.editPontos = Pontuacao.editPontos + 5;
            }
        }
    }
}
