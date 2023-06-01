using System.Collections;
using UnityEngine;
using TMPro;

public class CriarBoss : MonoBehaviour
{
    public static bool bossMorto = true;
    [SerializeField]
    private GameObject bossPrefab1; // Primeiro prefab do boss
    [SerializeField]
    private GameObject bossPrefab2; // Segundo prefab do boss

    [SerializeField]
    private TMP_Text prepareTextMesh; // TextMeshPro do "Prepare-se"
    [SerializeField]
    private TMP_Text countdownTextMesh; // TextMeshPro da contagem regressiva

    [SerializeField]
    private float tempoInicial;

    [SerializeField]
    private float intervalo;

    private bool isBossPrefab1Active = true; // Flag para controlar qual prefab do boss está ativo

    private void Start()
    {
        InvokeRepeating(nameof(GerarBoss), tempoInicial, intervalo); // Chama o método GerarBoss a cada intervalo definido
    }

    private IEnumerator ShowPrepareAndCountdown()
    {
        prepareTextMesh.gameObject.SetActive(true);
        countdownTextMesh.gameObject.SetActive(true);

        prepareTextMesh.text = "Prepare-se";

        yield return new WaitForSeconds(1f);

        countdownTextMesh.text = "3";
        yield return new WaitForSeconds(1f);

        countdownTextMesh.text = "2";
        yield return new WaitForSeconds(1f);

        countdownTextMesh.text = "1";
        yield return new WaitForSeconds(1f);

        prepareTextMesh.gameObject.SetActive(false);
        countdownTextMesh.text = "";
        yield return new WaitForSeconds(1f);

        countdownTextMesh.gameObject.SetActive(false);
    }

    private void GerarBoss()
    {
        if (!bossMorto) // Verifica se o boss anterior já foi derrotado
        {
            Debug.Log("Ainda há um boss ativo. Não é possível gerar outro boss.");
            return;
        }

        GameObject bossPrefab;

        if (isBossPrefab1Active)
        {
            bossPrefab = bossPrefab1;
            isBossPrefab1Active = false;
        }
        else
        {
            bossPrefab = bossPrefab2;
            isBossPrefab1Active = true;
        }

        bossPrefab.layer = 6;

        StartCoroutine(ShowPrepareAndCountdown()); // Inicia a exibição dos textos "Prepare-se" e a contagem regressiva

        StartCoroutine(CreateBossAfterDelay(bossPrefab));
    }

    private IEnumerator CreateBossAfterDelay(GameObject bossPrefab)
    {
        yield return new WaitForSeconds(4f); // Aguarda 4 segundos (1 segundo para cada número da contagem regressiva)

        GameObject boss = Instantiate(bossPrefab, transform.position, transform.rotation);
        Gerar.bossCriado = true; // Atualiza a variável para desativar a geração de inimigos em todos os objetos Gerar
        bossMorto = false;

        // Verifica qual prefab do boss foi gerado e aplica a rotação correspondente
        if (bossPrefab == bossPrefab1)
        {
            boss.transform.Rotate(Vector3.up, 180f); // Rotaciona 180 graus no eixo Y
        }
        else if (bossPrefab == bossPrefab2)
        {
            boss.transform.rotation = Quaternion.identity; // Define a rotação como a rotação padrão (0, 0, 0)
        }
    }

    private void OnDestroy()
    {
        bossMorto = true;
        Gerar.bossCriado = false;
    }
}
