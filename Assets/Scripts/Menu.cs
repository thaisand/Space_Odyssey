using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void LoadScene(int indexScene)
    {

        SceneManager.LoadScene(indexScene);
        Pontuacao.editPontos = 0;
        
    }

    public void SairJogo(){
        Application.Quit();
    }
}
