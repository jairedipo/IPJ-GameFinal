using UnityEngine;
using UnityEngine.SceneManagement;

public class Gravador : MonoBehaviour
{
    private static Gravador instance = null;

    public static Gravador Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("Gravador").AddComponent<Gravador>();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("CenaGoop");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("CenaShurtle");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("CenaDog");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("CenaGrunt");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("CenaLich");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("CenaFootman");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("CenaGolem");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SceneManager.LoadScene("Cena4");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("SelecaoDeEstagio");
        }
    }
}
