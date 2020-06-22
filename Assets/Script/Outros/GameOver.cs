using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Fader fade;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            fade.FadeToGame();
            SceneManager.LoadScene("TelaDeInicio2");
        }

    }
}
