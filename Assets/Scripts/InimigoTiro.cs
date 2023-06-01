using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoTiro : MonoBehaviour
{
    [Header("Tiro")]
    [SerializeField]
    private Transform LugarTiro;

    [SerializeField]
    private GameObject prefabTiro;

    [SerializeField]
    private GameObject flashObject;

    [SerializeField]
    private GameObject hitPrefab;

    [SerializeField]
    private GameObject explosaoPrefab;

    [SerializeField]
    private int healthPoints = 2;

    [SerializeField]
    private float tirodelay = 3f;

    private bool canShoot = true;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            InvokeRepeating(nameof(Tiro), tirodelay, tirodelay);
            canShoot = false;
        }
    }

    private void Tiro()
    {
        Instantiate(prefabTiro, LugarTiro.position, LugarTiro.rotation);
        flashObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bala") && gameObject.tag == "EnemyTiro" || other.CompareTag("Meteoro") && gameObject.tag == "EnemyTiro")
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

                Pontuacao.editPontos = Pontuacao.editPontos + 10;
            }
        }
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }
}
