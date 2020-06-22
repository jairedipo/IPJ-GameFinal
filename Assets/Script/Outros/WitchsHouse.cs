using UnityEngine;
using UnityEngine.SceneManagement;

public class WitchsHouse : MonoBehaviour
{
    public Fader fade;

    private void OnMouseDown()
    {
        fade.FadeToGame();
        SceneManager.LoadScene("InformacoesDePersonagens");
    }

}
