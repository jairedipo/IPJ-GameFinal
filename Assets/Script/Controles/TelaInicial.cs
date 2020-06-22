using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicial : MonoBehaviour
{
    public Fader fade;
    float savedTime;

    private void Start()
    {
        savedTime = Time.time;
    }

    void Update()
    {
        if (Input.anyKeyDown && Time.time - savedTime > 3)
        {
            fade.FadeToGame();
            SceneManager.LoadScene("SelecaoDeEstagio");
        }
    }
}
