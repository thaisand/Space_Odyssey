using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerar : MonoBehaviour
{
    public static bool bossCriado = false;
    [Header("Prefab")]
    [SerializeField]
    private GameObject gerarPrefab;

    [Header("Delay")]
    [SerializeField]
    [Range(0f, 10f)]
    private float inicialDelay = 1f;

    [SerializeField]
    [Range(0f, 10f)]
    private float gerarDelay = 1f;

    [Header("Limite")]
    [SerializeField]
    private Limite limiteX;

    [SerializeField]
    private Limite limiteY;

    private bool geracaoAtiva = true; // Variável para controlar a geração de inimigos

    private void Awake()
    {
        InvokeRepeating(nameof(Gera), inicialDelay, gerarDelay);
    }

    private void Gera()
    {
        if (!geracaoAtiva || Gerar.bossCriado) // Verifica se a geração está desativada ou se o boss já foi criado
        return;

        var randomX = Random.Range(limiteX.min, limiteX.max);
        var randomY = Random.Range(limiteY.min, limiteY.max);

        var position = new Vector3(
            transform.position.x + randomX,
            transform.position.y + randomY,
            transform.position.z
        );

        Instantiate(gerarPrefab, position, transform.rotation);
    }

    // Função para ativar/desativar a geração de inimigos
    public void SetGeracaoAtiva(bool ativa)
    {
        geracaoAtiva = ativa;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    void Update(){
        if (CriarBoss.bossMorto == true){
            bossCriado = false;
        }
    }
    

}
