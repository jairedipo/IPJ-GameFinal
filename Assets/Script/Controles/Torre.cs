using UnityEngine;

public class Torre : MonoBehaviour
{
    public int HP;
    public int HPMax;
    public bool destruiu = false;

    public GameObject torreDestruida;
    public ParticleSystem part;

    void Start()
    {
        HP = HPMax = 20000;

        part = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (HP < 0)
        {
            HP = 0;
        }
        
    }

    public void receberDano(int dano)
    {
        HP -= dano;
        if (HP <= 0)
        {
            HP = 0;
            destruiu = true;
            torreDestruida.SetActive(true);
            gameObject.SetActive(false);
        }
        part.Play();
    }
}
