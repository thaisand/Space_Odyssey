using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    private static int recorde;
    private TextMeshProUGUI texto;
    private TextMeshProUGUI texto2;

    public static int pontos = 0;


    void Start()
    {
        // Encontre o objeto com o componente TextMeshProUGUI
        GameObject textoObjeto = GameObject.Find("Pontos");
        // Atribua o componente TextMeshProUGUI à variável 'texto'
        texto = textoObjeto.GetComponent<TextMeshProUGUI>();
        // Atribua o texto inicial
        texto.text = "Pontos: " + pontos.ToString();

        

        // Encontre o objeto com o componente TextMeshProUGUI
        GameObject textoObjeto2 = GameObject.Find("Recorde");
        // Atribua o componente TextMeshProUGUI à variável 'texto'
        texto2 = textoObjeto2.GetComponent<TextMeshProUGUI>();
        // Atribua o texto inicial
        texto2.text = "Recorde: " + recorde.ToString();


    }

    void Update()
    {
        texto.text = "Pontos: " + pontos.ToString();
    }

    public static int editPontos
    {
        get { return pontos; }
        set
        {
            pontos = value;
            if (pontos < 0)
            {
                pontos = 0;
            }

            if (pontos > recorde)
            {
                recorde = pontos;
                PlayerPrefs.SetInt("HighScore", recorde);
            }
        }
    }


}
