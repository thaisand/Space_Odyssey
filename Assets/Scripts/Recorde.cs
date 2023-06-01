using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.Networking;
using TMPro;

public class Recorde : MonoBehaviour
{
    private static string url = "https://ApiRecorde.pedroaifail11.repl.co/maior-valor";
    private static  int currentMaiorValor;
    private TextMeshProUGUI texto;

    void Start()
    {
        
        StartCoroutine(GetMaiorValor());
    }

    public int retornarMaiorValor()
    {
        return currentMaiorValor;
    }

    IEnumerator GetMaiorValor()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            JSONNode response = JSON.Parse(request.downloadHandler.text);

            currentMaiorValor = response["maior_valor"].AsInt;
            Debug.Log(currentMaiorValor);
            GameObject textoObjeto2 = GameObject.Find("RecordeMundial");
            // Atribua o componente TextMeshProUGUI à variável 'texto'
            texto = textoObjeto2.GetComponent<TextMeshProUGUI>();
            // Atribua o texto inicial
            

            texto.text = "Recorde Mundial: " + currentMaiorValor.ToString();
        }
        else
        {
            Debug.Log(request.error);
        }
    }

    public static    IEnumerator SetMaiorValor(int valor)
    {
        if (valor > currentMaiorValor)
        {
            JSONNode data = JSON.Parse("{\"valor\":" + valor + "}");

            UnityWebRequest request = UnityWebRequest.Post(url, "POST");
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(data.ToString());
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                currentMaiorValor = valor;
            }
            else
            {
                Debug.Log(request.error);
            }
        }
    }
}
