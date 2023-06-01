using UnityEngine;
using UnityEngine.UI;

public class ajuda : MonoBehaviour
{
    public GameObject helpImage; // Referência para a imagem de ajuda
    private bool isHelpImageVisible; // Indica se a imagem de ajuda está visível ou não

    private void Start()
    {
        // Certifique-se de que a imagem de ajuda está desativada no início
        helpImage.SetActive(false);
        isHelpImageVisible = false;
    }

    public void ToggleHelpImage()
    {
        
        // Inverte a visibilidade da imagem de ajuda ao clicar no botão
        isHelpImageVisible = !isHelpImageVisible;
        helpImage.SetActive(isHelpImageVisible);
    }
}

