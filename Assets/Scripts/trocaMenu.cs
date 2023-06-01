using UnityEngine;
using UnityEngine.SceneManagement;

public class trocaMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject painelOpcoes;
    
    [SerializeField]
    private GameObject painelInicial;

    [SerializeField]
    private GameObject painelAjuda;
    

        void Start()
    {

        painelOpcoes.SetActive(false);
        painelAjuda.SetActive(false);
    }

    public void AbrirInicio(){
        painelInicial.SetActive(true);
        painelOpcoes.SetActive(false);
        painelAjuda.SetActive(false);
    }

    public void AbrirOpcoes (){
        painelInicial.SetActive(false);
        painelAjuda.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void AbrirAjuda(){
        painelInicial.SetActive(false);
        painelAjuda.SetActive(true);
        painelOpcoes.SetActive(false);
    }


public GameObject DifficultyToggles;



    public void ConfirmarOpcoes (){
        painelOpcoes.SetActive(false);
        painelInicial.SetActive(true);
    }

    #region Difficulty
public void SetEasyDifficulty(bool isOn)
{
if (isOn)
GameValues.Difficulty = GameValues.Difficulties.Easy;
}

public void SetMediumDifficulty(bool isOn)
{
if (isOn)
GameValues.Difficulty = GameValues.Difficulties.Medium;
}

public void SetHardDifficulty(bool isOn)
{
if (isOn)
GameValues.Difficulty = GameValues.Difficulties.Hard;
}
#endregion


}
