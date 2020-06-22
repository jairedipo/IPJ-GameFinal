using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject[] paginas;

    float savedTime;
    bool init;

    int indice;

    void Start()
    {
        indice = 0;
        savedTime = Time.time;
        init = false;
    }

    void Update()
    {
        if(Time.time - savedTime > 0.5f && !init)
        {
            tutorial.SetActive(true);
            paginas[indice].SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void nextPage()
    {
        if (indice < paginas.Length - 1)
        {
            paginas[indice].SetActive(false);
            indice++;
            paginas[indice].SetActive(true);
        }
    }

    public void prevPage()
    {
        if (indice > 0)
        {
            paginas[indice].SetActive(false);
            indice--;
            paginas[indice].SetActive(true);
        }
    }

    public void iniciar()
    {
        init = true;
        Time.timeScale = 1;
        tutorial.SetActive(false);
    }
}
