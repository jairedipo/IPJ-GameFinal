using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aparecer : MonoBehaviour
{
    public GameObject[] clones;
    float savedTime;
    int i;

    void Start()
    {
        TempoDePartida.start = true;
        savedTime = Time.time;
        i = 0;
    }

    
    void Update()
    {
        if(Time.time - savedTime > 0.5f && i < clones.Length)
        {
            clones[i].SetActive(true);
            i++;
            savedTime = Time.time;
        }
    }
}
